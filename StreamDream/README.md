
# StreamDream

Here I'll show you the steps to run this project and the VisualStudio and Python versions used.


## Documentation

[Report in Italian](https://github.com/eliovinciguerra/portfolio/blob/main/Relazione.pdf)


## Installation

Install mongoDB:

Guide [to mongoDB download](https://www.mongodb.com/docs/manual/installation/) 
    

## Run Locally
Run mongoDB

1.Start mongoDB on port 27017

Start the go (it's the server) script in  "\DreamStream\Server"
```bash
  go run .
```

Before starting the application change the PATH of the ToPython.cs, opening the file at code line 11 you will have a variable called 'script' enter the correct integer file path:
```bash
your\path\StreamDream\ProgettoAPL\Python\" + programName
```

The application can be started from the sln file that will lead to the VisualStudio IDE19
or via the ProjectAPL.exe file contained in the
 "\DreamStream\ProgettoAPL\bin\Debug\net5.0-windows"




## Authors

- Maria Roggio
- Elio Vinciguerra

