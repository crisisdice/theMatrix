cl /LD ..\..\src\matrixCalc\matrixCalc.c /DWINDOWS

copy matrixCalc.dll ..\..\src\matrixApi\lib

del matrixCalc.*

exit
