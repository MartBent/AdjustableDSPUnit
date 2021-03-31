/*
 * AnalogDigitalConverter.cpp
 *
 * Created: 17-3-2021 20:20:22
 *  Author: Mart
 */ 
#include "DSPUnit.hpp"
#include "Utility/Debug.hpp"

using namespace I2C;
using namespace DSP;

DSPUnit::DSPUnit()
{
	//Initial equation = Y(k) = X^k-0
	diffEquation = new Term[1];
	equationLength = 1;
	sampleHistory = new uint16_t[1];
	sampleHistory[0] = 0;
	sampleHistoryLength = 1;
	
	diffEquation[0] = Term(100,0,false);
}
void DSPUnit::processEquation()
{
	Debug db = Debug();
	
	//Sample ADC
	uint16_t newDacValue = 0;
	uint16_t sampleValue = getAdcValue();
	//Update sample history
	for (int i=0; i<(sampleHistoryLength - 1); i++)
	{
		sampleHistory[sampleHistoryLength-i-1] = sampleHistory[sampleHistoryLength-i-2] ;
	}
	sampleHistory[0] = sampleValue;
	
	db.UsartPrint(sampleValue);
	
	//Evaluate new DAC value with equation
	for(int i = 0; i < equationLength; i++)
	{
		Term term = diffEquation[i];		
		uint16_t* historyPtr = term.getIsOutput() ? outputHistory : sampleHistory; //Check if the term is a X or Y in the equation
		uint8_t index = term.getExponent()*-1; //Get the sample index and flip sign for indexing
		newDacValue += term.getCoeffecient()*(float)historyPtr[index];
	}
		
	//Output calculated value
	setDacValue(newDacValue);
	
	//Update the output history
	for (int i=0; i<(outputHistoryLength - 1); i++)
	{
		outputHistory[outputHistoryLength-i-1] = outputHistory[outputHistoryLength-i-2] ;
	}
	outputHistory[0] = newDacValue;
	
}
uint16_t DSPUnit::getAdcValue()
{	
	startCondition();
	writeData(adcAdress | 1); //address | 1 for reading
	uint16_t temp = (uint16_t) readData(true) << 8; //send an ack since we want to receive another byte
	temp |= readData(false);
	stopCondition();
	return temp;
}

void DSPUnit::setDacValue(uint16_t value)
{
	startCondition();
	writeData(dacAdress | 0); //address | 0 for writing	
	writeData(0x00);
	writeData(value >> 2);
	writeData(value << 6);
	stopCondition();
}

uint16_t DSPUnit::getDacValue()
{
	startCondition();
	writeData(dacAdress | 0); //address | 1 for reading
	writeData(0x00);
	stopCondition();
	
	startCondition();
	writeData(dacAdress | 1);
	uint16_t value = (uint16_t)readData(true) << 8;
	value |= readData(false);
	stopCondition();
	return value;
}

void DSPUnit::setDifferenceEquation(Term* diffEq, uint8_t eqLength)
{
	if(diffEquation != nullptr)//Remove the current equation
	{
		delete diffEquation;
		diffEquation = nullptr;
	}
	if(sampleHistory != nullptr)//Remove the sample history
	{
		delete sampleHistory;
		sampleHistory = nullptr;
	}
	sampleHistoryLength = 0;
	if(outputHistory != nullptr)//Remove the output history
	{
		delete outputHistory;
		outputHistory = nullptr;
	}
	outputHistoryLength = 0;
	
	equationLength = eqLength;
	diffEquation = diffEq;
	
	int16_t minExpo = 2;
	for(int i = 0; i < eqLength; i++) //Determine lowest exponent for X values
	{
		if(!diffEquation[i].getIsOutput())
		{
			int16_t expo = diffEquation[i].getExponent();
			
			if(expo < minExpo)
			{
				minExpo = expo;
			}
		}
	}
	
	uint8_t newSampleHistoryLength = (minExpo * -1) + 1; //Flip sign
	sampleHistoryLength = newSampleHistoryLength;
	sampleHistory = new uint16_t[newSampleHistoryLength];
	
	memset(sampleHistory,0,newSampleHistoryLength);//Initial values should be 0
	
	minExpo = 2;
	for(int i = 0; i < eqLength; i++) //Determine lowest exponent for Y values
	{
		if(diffEquation[i].getIsOutput())
		{
			int16_t expo = diffEquation[i].getExponent();
			
			if(expo < minExpo)
			{
				minExpo = expo;
			}
		}
	}
	
	uint8_t newOutputHistorylength = (minExpo * -1) + 1; //Flip sign
	outputHistoryLength = newOutputHistorylength;
	outputHistory = new uint16_t[newOutputHistorylength];
	
	memset(outputHistory,0,outputHistoryLength);//Initial values should be 0
}