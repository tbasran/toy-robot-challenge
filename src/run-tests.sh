#!/bin/sh

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover

reportgenerator \
    "-reports:ToyRobotLib.Test/coverage.opencover.xml;ToyRobotConsoleApp.Test/coverage.opencover.xml" \
    -reporttypes:HTML \
    -targetdir:coverage-report/unit -title:"Unit tests";

reportgenerator \
    "-reports:ToyRobotConsoleApp.IntegrationTest/coverage.opencover.xml" \
    -reporttypes:HTML \
    -targetdir:coverage-report/integration \
    -title:"Integration tests";