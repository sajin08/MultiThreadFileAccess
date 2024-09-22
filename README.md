# MultiThreadFileAccess
## Overview
An example of multi threading application where multiple threads access one single file to write on it and generate a out.txt file with a pattern `<lineno>, <threadid>, <timestamp>`. It creates initial document with initial value `0, 0, <timestamp>` if the file does not exists and append new rows to the text file else if the file exists it will append the new rows to existing file. It also demonstrate error handling with custom errors and default error. 

This application is written in C# language with .Net 6 framework.

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/sajin08/MultiThreadFileAccess.git
   cd MultiThreadFileAccess
2. Open the solution: Open the MultiThreadFileAccess.sln file in Visual Studio.
3. Build the solution: Build the solution to restore the necessary packages and compile the code.
4. Run the application: Run the application to see the multi-threading in action.

## Prerequisites
- .NET 6 SDK installed
- Visual Studio or a compatible text editor
