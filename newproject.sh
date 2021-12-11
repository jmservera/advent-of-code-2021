#!/bin/bash

if [ $# -ne 2 ];
then
    echo "Usage: $0 <day> <project name>"
    exit 1
fi

if [[ -f $1/$2/$2.csproj ]]
then
    echo "Project $2 already exists"
    exit 1
fi

echo "Creating project $2 in day $1"
mkdir -p $1
dotnet new classlib -o $1/$2
dotnet sln add $1/$2/$2.csproj
dotnet new xunit -o $1/$2Tests
dotnet sln add $1/$2Tests/$2Tests.csproj
dotnet add $1/$2Tests/$2Tests.csproj reference $1/$2/$2.csproj

echo "Checking build"
dotnet build