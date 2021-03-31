#ifndef I2CCPP
#define I2CCPP
/*
 * I2CBus.cpp
 *
 * Created: 17-3-2021 19:33:53
 *  Author: Mart
 */ 
#include <avr/io.h>

namespace I2C
{	
	class I2CBus
	{
		protected:
		I2CBus();
		void startCondition();
		void stopCondition();
		void waitUntilAvailable();
		uint8_t readData(bool ack);	
		void writeData(uint8_t data);
	};
	
}
#endif