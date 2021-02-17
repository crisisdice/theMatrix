cl /LD ..\..\matrixCalc\matrixCalc.c /DWINDOWS

copy matrixCalc.dll ..\..\matrixApi\lib

del matrixCalc.*

exit
