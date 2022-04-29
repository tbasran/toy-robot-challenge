FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

COPY src/ToyRobotConsoleApp/ToyRobotConsoleApp.csproj /app/src/ToyRobotConsoleApp/ToyRobotConsoleApp.csproj
COPY src/ToyRobotConsoleApp.IntegrationTest/ToyRobotConsoleApp.IntegrationTest.csproj /app/src/ToyRobotConsoleApp.IntegrationTest/ToyRobotConsoleApp.IntegrationTest.csproj
COPY src/ToyRobotConsoleApp.Test/ToyRobotConsoleApp.Test.csproj /app/src/ToyRobotConsoleApp.Test/ToyRobotConsoleApp.Test.csproj
COPY src/ToyRobotLib/ToyRobotLib.csproj /app/src/ToyRobotLib/ToyRobotLib.csproj
COPY src/ToyRobotLib.Test/ToyRobotLib.Test.csproj /app/src/ToyRobotLib.Test/ToyRobotLib.Test.csproj
COPY src/ToyRobot.sln /app/src/ToyRobot.sln

WORKDIR /app/src

RUN dotnet restore

RUN rm /app/src/ToyRobotConsoleApp/ToyRobotConsoleApp.csproj
RUN rm /app/src/ToyRobotConsoleApp.IntegrationTest/ToyRobotConsoleApp.IntegrationTest.csproj
RUN rm /app/src/ToyRobotConsoleApp.Test/ToyRobotConsoleApp.Test.csproj
RUN rm /app/src/ToyRobotLib/ToyRobotLib.csproj
RUN rm /app/src/ToyRobotLib.Test/ToyRobotLib.Test.csproj
RUN rm /app/src/ToyRobot.sln

RUN dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.1.5

ENV PATH="${PATH}:/root/.dotnet/tools"

