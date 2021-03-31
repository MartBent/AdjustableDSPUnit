/*
 * Debug.cpp
 *
 * Created: 17-3-2021 20:31:08
 *  Author: Mart
 */ 
#define F_CPU 16000000UL
#define USART_BAUDRATE 9600
#define BAUD_PRESCALER (((F_CPU / (USART_BAUDRATE * 16UL))) - 1)

#include "../I2CBus.hpp"

using namespace I2C;

class Debug : public I2CBus
{	
	public:
	void Initialize()
	{		
		UBRR0L = (BAUD_PRESCALER);	//Set the defined baudrate, UBRR0H doenst have to be set since baudprescaler < 255
		UCSR0C =  (1 << UCSZ01) | (1 << UCSZ00);// 8N1 (8 Bits, No parity, 1 stop bit) frame format
		UCSR0B |= (1 << RXEN0) | (1 << TXEN0) | (1 << RXCIE0);// Enable Transmitter and receiver along with the rx interrupt
		DDRD = (1 << PORTD0); //Set the Tx pin to output for serial communication
		
		startCondition();
		writeData(0x40 | 0); //address | 0 for writing
		writeData(0x00); //0x00 for DDR
		writeData(0x00); //set io register
		stopCondition();
	}
	void UsartPrint(uint8_t msg)
	{
		while (!( UCSR0A & (1<<UDRE0))); //Send the data if the USART is ready.
		UDR0 = msg;
	}
	void setOutputLatch(uint8_t value)
	{
		startCondition();
		writeData(0x40 | 0); //address | 0 for writing
		writeData(0x09); //0x09 for GPIO
		writeData(value); //set io register
		stopCondition();
	}
};