# Mars Rovers
## _Communication Console_

This application was created with .Net Core and Angular

## Solution Structure
This solution is composed from three different project which are the responsibles to take the information the Mars Rovers operator needs to send it in order to take move through the Mars Surface.

| Project | Folder | Description |
| ------ | ------ | ------ |
| MarsRovers .Web | 1- Presentation | This is the console where the Mars Rovers user will type the comands to send it once the command is completed |
| MarsRovers.Application | 2-Application | This project is the one that contains the Service used to process the command sending reqeuest and the response received after the message is pocessed by the Rovers  |
| MarsRovers.Channel | 3-Infrastructure | In this project we'll find the all of the obejcts that are neceessary to process the input string, convert it into something that can be processed and managed and finally return a restult|


## Features

- Process list of command from a Text Area and print the results into another text area
- Coordinates, Cardinal Points and Movements validation

#### Building for source

Running this project:

```sh
You only need to open Visual Studio 2019, click run and this will automatically start to restore and install the required packages to make this appplication to run 
```


