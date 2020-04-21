#						#
# Team: IVS and chill				#
#						#
# Members:	Jan Chaloupka			#
#	   	Michal Halabica			#
#	   	Marek Václavík			#
#	   	Richard Hrmo			#
#						#


CWD=$(shell cd)

PROJECT_NAME=Calculator
PROJECT_TEST=MathLibTests
PROJECT_LIBRARY=MathLib
PROJECT_PROFILER=MathLibProfiler
PROJECT=$(PROJECT_NAME)\bin\Release\netcoreapp3.1\$(PROJECT_NAME)

PROFILER=$(PROJECT_PROFILER)\bin\Release\netcoreapp3.1\$(PROJECT_PROFILER)
PROFILER_DATA=..\profiling\Data\input_1000

DOC=$(CWD)\..\dokumentace

PACK_NAME=xchalo16_xhalab00_xvacla26_xhrmor00
PACK_DIR=$(CWD)\..\..\$(PACK_NAME)
PACK=$(PACK_DIR).zip
PACK_DOC=$(PACK_DIR)\doc
PACK_INSTALL=$(PACK_DIR)\install
PACK_REPO=$(PACK_DIR)\repo

.PHONY: all build pack clean test run profile help

all: run
	
build:
	dotnet build -c Release

pack:
	if exist "$(PACK_DIR)" del /f /s /q "$(PACK_DIR)"  1>nul & rmdir /s /q "$(PACK_DIR)" 
	mkdir "$(PACK_DIR)"
	mkdir "$(PACK_INSTALL)"
	mkdir "$(PACK_DOC)"
	mkdir "$(PACK_REPO)"
	
	make clean
	xcopy /s "$(CWD)\.." "$(PACK_REPO)"
	xcopy /s "$(DOC).pdf" "$(PACK_DIR)\doc"

	cd "$(PACK_DIR)\.." && zip -r "$(PACK)" $(PACK_NAME)
	rmdir /s /q "$(PACK_DIR)"

clean:
	if exist "..\.vs" rmdir /q /s ..\.vs
	if exist "..\.github" rmdir /q /s ..\.github

	if exist "$(PROJECT_NAME)\bin" rmdir /q /s  $(PROJECT_NAME)\bin
	if exist "$(PROJECT_NAME)\obj" rmdir /q /s  $(PROJECT_NAME)\obj
	if exist "$(PROJECT_NAME)\$(PROJECT_NAME).csproj.user" del $(PROJECT_NAME)\$(PROJECT_NAME).csproj.user

	if exist "$(PROJECT_TEST)\bin" rmdir /q /s  $(PROJECT_TEST)\bin
	if exist "$(PROJECT_TEST)\obj" rmdir /q /s  $(PROJECT_TEST)\obj
	if exist "$(PROJECT_TEST)\$(PROJECT_TEST).csproj.user" del $(PROJECT_TEST)\$(PROJECT_TEST).csproj.user

	if exist "$(PROJECT_LIBRARY)\bin" rmdir /q /s  $(PROJECT_LIBRARY)\bin
	if exist "$(PROJECT_LIBRARY)\obj" rmdir /q /s  $(PROJECT_LIBRARY)\obj
	if exist "$(PROJECT_LIBRARY)\$(PROJECT_LIBRARY).csproj.user" del $(PROJECT_LIBRARY)\$(PROJECT_LIBRARY).csproj.user

	if exist "$(PROJECT_PROFILER)\bin" rmdir /q /s  $(PROJECT_PROFILER)\bin
	if exist "$(PROJECT_PROFILER)\obj" rmdir /q /s  $(PROJECT_PROFILER)\obj
	if exist "$(PROJECT_PROFILER)\$(PROJECT_PROFILER).csproj.user" del $(PROJECT_PROFILER)\$(PROJECT_PROFILER).csproj.user
	
	if exist "TestResult" rmdir /q /s TestResult
	if exist "IVS-Calculator.sln.DotSettings.user" del IVS-Calculator.sln.DotSettings.user

test:
	dotnet test
	rmdir /q /s TestResults

run:
	IF NOT EXIST "$(PROJECT).exe" make build
	$(PROJECT).exe

profile:
	if not exist "$(PROFILER).dll" make build
	dotnet $(PROFILER).dll < $(PROFILER_DATA).txt
	
help:
	@echo To be able to build the project you need ".NET Core 3.1" utility. For more information see "README.md".
	@echo all: default parameter, runs the aplication
	@echo build: builds the aplication
	@echo pack: packs the program into zip file
	@echo clean: deletes all unnecessery files and folders
	@echo test: runs tests for Math Library
	@echo run: runs the aplication
	@echo profile: runs profiling
	@echo help: prints out help