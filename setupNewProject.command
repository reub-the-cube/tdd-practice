#! /bin/bash

dotnet new sln -o $1

cd ./$1

dotnet new classlib -o $1

testProject=$1.Tests
echo $testProject

dotnet new xunit -o $testProject

dotnet sln add ./$1/$1.csproj
dotnet sln add ./$testProject/$testProject.csproj

cd ./$testProject

dotnet add reference .././$1/$1.csproj
dotnet add package FluentAssertions

cd ..

code ./
