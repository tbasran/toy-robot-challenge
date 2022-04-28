# Toy Robot Code Challenge

Welcome to my solution to the Toy Robot Code Challenge.

## Description and requirements

The application is a simulation of a toy robot moving on a square table top, of dimensions 5 units x 5 units. There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.

The solution is a console application that can read in commands of the following form:

- PLACE X,Y,F
- MOVE
- LEFT
- RIGHT
- REPORT

PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The origin (0,0) can be considered to be the SOUTH WEST most corner. It is required that the first command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed. MOVE will move the toy robot one unit forward in the direction it is currently facing.
LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot. REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient. A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands. Input is from standard input.

## Constraints

The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot. Any move that would cause the robot to fall must be ignored.

## Requirements

- Docker

## Solution

The solution is a dotnet core 3.1 console application written in c#. It comprises of the following projects:

- [ToyRobotLib](./src/ToyRobotLib/): Core business logic for the application.

- [ToyRobotLib.Test](./src/ToyRobotLib.Test/): Unit tests for the core business logic.

- [ToyRobotConsoleApp](./src/ToyRobotConsoleApp/): The console application. Reads and executes toy robot commands from the console.  

- [ToyRobotConsoleApp.Test](./src/ToyRobotConsoleApp.Test/): Unit tests for the console application.

- [ToyRobotConsoleApp.IntegrationTest](./src/ToyRobotConsoleApp.IntegrationTest/): Integration tests for the console application.

## Getting started

To open the developer/execution environment run: `docker-compose run --rm dotnet`

### Running the unit and integration tests

To execute the tests and produce code coverage reports run:`./run-tests.sh`

- [Unit tests](./src/coverage-report/unit/index.html)
- [Integration tests](./src/coverage-report/integration/index.html)

### Running the application

To run the toy robot simulation run: `dotnet run -p ./ToyRobotConsoleApp -c Release`

#### Example Input and Output

```bash
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
Output: 3,3,NORTH
```
