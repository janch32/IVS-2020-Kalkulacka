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

TEST=$(PROJECT_TEST)\bin\Release\netcoreapp3.1\$(PROJECT_TEST)

PROFILER=$(PROJECT_PROFILER)\bin\Release\netcoreapp3.1\$(PROJECT_PROFILER)
PROFILER_DATA1=..\profiling\Data\input_10
PROFILER_DATA2=..\profiling\Data\input_100
PROFILER_DATA3=..\profiling\Data\input_1000

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
	dotnet build --configuration Release $(PROJECT_NAME)
	dotnet build --configuration Release $(PROJECT_TEST)
	dotnet build --configuration Release $(PROJECT_PROFILER)

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
	
	if exist "TestsResult" rmdir /q /s TestsResult
	if exist "IVS-Calculator.sln.DotSettings.user" del IVS-Calculator.sln.DotSettings.user

test:
	IF NOT EXIST "$(TEST).dll" make build
	dotnet test $(TEST).dll
	rmdir /q /s TestResults

run:
	IF NOT EXIST "$(PROJECT).exe" make build
	$(PROJECT).exe

profile:
	if not exist "$(PROFILER).dll" make build
	dotnet $(PROFILER).dll < $(PROFILER_DATA1).txt
	dotnet $(PROFILER).dll < $(PROFILER_DATA2).txt
	dotnet $(PROFILER).dll < $(PROFILER_DATA3).txt
help:
	
	$(info all: default parameter, runs the aplication)
	$(info build: builds the aplication)
	$(info pack: packs the program into zip file)
	$(info clean: deletes all unnecessery files and folders)
	$(info test: runs tests for Math Library)
	$(info run: runs the aplication)
	$(info profile: runs profiling)
	$(info help: prints out help)