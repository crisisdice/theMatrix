# theMatrix
This is a demo REST API that performs algebraic operations on matricies. The algebraic logic is written in C and is imported by the gateway logic, written both in C# or Python, depending on the branch selected.

## Building and Running

This project is built on the [Django](https://www.djangoproject.com/) python framework. Information on setup and running the development server can be found [here](https://docs.djangoproject.com/en/3.1/intro/tutorial01/). Compiling the C source code from the `matrixCalc` directory is accomplished with `gcc -fPIC -shared -o ../matrixApi/matrixCalc.so matrixCalc.c`. 
