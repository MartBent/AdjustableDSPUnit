/*
 * MCP3221.cpp
 *
 * Created: 17-3-2021 20:06:36
 *  Author: Mart
 */ 
#include "I2CBus.hpp"
#include <stdlib.h>
#include <string.h>

using namespace I2C;
namespace DSP
{
	class Term
	{
		int16_t coeffecient = 0;
		int16_t exponent = 0;
		bool isOutput = false;//True is the symbol in equation is Y
		
		public:
		Term(int16_t coeffecient, int16_t exponent, bool isOutput) 
		{
			this->coeffecient = coeffecient;
			this->exponent = exponent;
			this->isOutput = isOutput;
		}
		Term() {}
		float getCoeffecient()
		{
			return (float)coeffecient/100;
		}
		int16_t getExponent()
		{
			return exponent;
		}
		bool getIsOutput()
		{
			return isOutput;
		}
	};
	
	class DSPUnit : public I2CBus
	{		
		static const uint8_t adcAdress = 0x9A;
		static const uint8_t dacAdress = 0x90;
		
		
		uint8_t equationLength = 0;
		
		uint8_t sampleHistoryLength = 0; //Determined by the difference equation
		uint16_t* sampleHistory = nullptr;
		
		uint8_t outputHistoryLength = 0; //Determined by the difference equation
		uint16_t* outputHistory = nullptr;
		
		public:
		Term* diffEquation = nullptr;
		DSPUnit();
		void processEquation();
		void setDifferenceEquation(Term* diffEq, uint8_t eqLength);
		
		uint16_t getAdcValue();
		void setDacValue(uint16_t value);
		uint16_t getDacValue();
	};
}