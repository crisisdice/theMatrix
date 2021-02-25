#include<stdio.h>
#include"export.h"

EXPORT void multiply(int matrixA[], int matrixB[], int aColumns, int bColumns, int cLength, int *matrixC)
{
	for (int arrayIndex = 0; arrayIndex < cLength; arrayIndex++)
	{
		int columnPosition = arrayIndex % bColumns;
		int rowPosition = arrayIndex / bColumns;
	
		int entry = 0;
	
		for(int summationIndex = 0; summationIndex < aColumns; summationIndex++)
		{
			int aIndex = rowPosition * aColumns + summationIndex;
			int bIndex = summationIndex * bColumns + columnPosition;
			
			int aEntry = matrixA[aIndex];
			int bEntry = matrixB[bIndex];

			int cEntry = aEntry * bEntry;
	
			entry = entry + cEntry;
		}
		
		matrixC[arrayIndex] = entry;
	}
}
