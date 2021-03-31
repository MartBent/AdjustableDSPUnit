#ifndef I2CBUS_CPP
#define I2CBUS_CPP
/*
 * I2CBus.cpp
 *
 * Created: 17-3-2021 19:39:00
 *  Author: Mart
 */ 
#include "I2CBus.hpp"
using namespace I2C;

I2CBus::I2CBus()
{
	TWBR = 72; //  16m/(16+2(72)*(1)) = 100Khz
	TWCR = (1<<TWEN); //enable the module
}
void I2CBus::waitUntilAvailable()
{
	while ((TWCR & (1<<TWINT)) == 0); //Wait until TWINT is set to 1
}
void I2CBus::startCondition()
{
	TWCR = (1 << TWINT) | (1 << TWEN)  | (1 << TWSTA);//Clear TWINT and set TWSTA to set the start condition on the line
	waitUntilAvailable();
}
void I2CBus::stopCondition()
{
	TWCR = (1 << TWINT) | (1 << TWEN)  | (1 << TWSTO); //Clear TWINT and set TWSTO to set the stop condition on the line
}
void I2CBus::writeData(uint8_t data)
{
	
	TWDR = data; //put data on the line
	TWCR = (1<<TWINT)| (1 << TWEN) ; //Clear TWINT
	waitUntilAvailable();
}
uint8_t I2CBus::readData(bool ack)
{
	TWCR = (1 << TWINT) | (1 << TWEN) | (ack << TWEA); //Clear TWINT and put a acknowledge on the line if needed
	waitUntilAvailable();
	return TWDR; //returns data from data register
}
#endif