/*
 * Final Assignment.cpp
 *
 * Created: 17-3-2021 13:42:19
 * Author : Mart
 */ 

#define F_CPU 16000000UL

#include <util/delay.h>
#include <string.h>
#include <avr/interrupt.h>
#include <stdlib.h>

#include "Utility/CppCore.hpp"
#include "DSPUnit.hpp"
#include "Utility/Debug.hpp"

using namespace I2C;
using namespace DSP;

DSPUnit dsp = DSPUnit(); //I2C initialized in constructor

//Variables for usart receiving
uint8_t* rxBuffer = nullptr;
uint8_t termAmount = 0;
uint8_t rxAmount = 0;

int main(void)
{	
	sei();
	
    while(1) 
    {
		dsp.processEquation();
    }
}
ISR(USART_RX_vect)
{
	uint8_t data = UDR0;
	if(termAmount == 0) //This byte will determine the length.
	{
		if(rxBuffer !=  nullptr)
		{
			delete rxBuffer;
			rxBuffer = nullptr;
		}
		
		termAmount = data;
		rxBuffer = new uint8_t[termAmount*sizeof(Term)]; 
	}
	else if(rxAmount != termAmount*sizeof(Term))//Keep adding bytes to buffer until length has been reached
	{
		rxBuffer[rxAmount++] = data;
	}
	if(rxAmount == termAmount*sizeof(Term)) //Whole message has been received
	{		
		uint8_t cursor = 0;
		Term* equation = new Term[termAmount];
		
		for(uint8_t i = 0; i < termAmount*sizeof(Term); i+=5)
		{
			//Adjust equation
			int16_t coef = (uint16_t)rxBuffer[i] << 8 | rxBuffer[i+1];
			int16_t expo = (uint16_t)rxBuffer[i+2] << 8 | rxBuffer[i+3];
			bool isOutput = rxBuffer[i+4] > 0;
			Term term = Term(coef,expo, isOutput);
			equation[cursor++] = term;
		}
		
		dsp.setDifferenceEquation(equation, cursor);
			
		termAmount = 0;
		rxAmount = 0;
		delete rxBuffer;
		rxBuffer = nullptr;
	}
}
