# theMatrix
This is a demo REST API that performs algebraic operations on matricies. The algebraic logic is written in C and is imported by the gateway logic, written both in C# or Python, depending on the branch selected.

## Building and Running

To compile the C code into a .NET readable DLL the following [tools](https://visualstudio.microsoft.com/de/thank-you-downloading-visual-studio/?sku=BuildTools&rel=16) are required. Building and running the the project with the scripts provided requires the [dotnet cli](https://docs.microsoft.com/en-us/dotnet/core/tools/). After installation, run `dev.bat` to access the vs developer command prompt and requisite tools from the standard install location, followed by `build.bat` to build the project and dependencies. The project can then be run with `run.bat`.
