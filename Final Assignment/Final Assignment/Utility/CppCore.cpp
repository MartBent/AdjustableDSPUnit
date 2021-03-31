#include "CppCore.hpp"
#include <stdlib.h> 

#ifdef PRINT_ALLOCATIONS
#include <stdio.h>
#endif

inline void* allocate(size_t size)
{
#ifdef PRINT_ALLOCATIONS
	void* allocation = malloc(size);
	printf("Allocating memory.   Address: %p, Size: %lu\n", allocation, size);
	return allocation;
#else
	return malloc(size);
#endif
}

inline void deallocate(void* ptr, unsigned int size)
{
	free(ptr);

#ifdef PRINT_ALLOCATIONS
	if(size == 0)
	{
		printf("Deallocating memory. Address: %p, Size: unknown\n", ptr);
	}
	else
	{
		printf("Deallocating memory. Address: %p, Size: %lu\n", ptr, size);
	}
#endif
}

void *operator new(size_t size)
{
	return allocate(size);
}

void *operator new[](size_t size)
{
	return allocate(size);
}

void operator delete(void * ptr)
{
	deallocate(ptr, 0);
}

void operator delete[](void * ptr)
{
	deallocate(ptr, 0);
}

void operator delete(void * ptr, unsigned int size)
{
	deallocate(ptr, size);
}

void operator delete[](void * ptr, unsigned int size)
{
	deallocate(ptr, size);
}

int __cxa_guard_acquire(__guard *g) {return !*(char *)(g);};
void __cxa_guard_release (__guard *g) {*(char *)g = 1;};
void __cxa_guard_abort (__guard *) {};
	
void __cxa_pure_virtual(void) {};