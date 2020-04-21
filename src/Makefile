#							#
# Team: IVS and chill		#
#							#
# Members:					#
#		Jan Chaloupka		#
#	   	Michal Halabica		#
#	   	Marek Václavík		#
#	   	Richard Hrmo		#
#							#


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

build: $(PROJECT).exe

pack: clean
	if exist "$(PACK_DIR)" del /f /s /q "$(PACK_DIR)"  1>nul & rmdir /s /q "$(PACK_DIR)"
	mkdir "$(PACK_DIR)"
	mkdir "$(PACK_INSTALL)"
	mkdir "$(PACK_DOC)"
	mkdir "$(PACK_REPO)"

	xcopy /s "$(CWD)\.." "$(PACK_REPO)"
	xcopy /s "$(DOC).pdf" "$(PACK_DIR)\doc"

	cd "$(PACK_DIR)\.." && zip -r "$(PACK)" $(PACK_NAME)
	rmdir /s /q "$(PACK_DIR)"

clean:
	for /r %%i in (*.user) do if exist "%%i" del "%%i"
	for /d /r %%i in (.vs, bin, obj, TestResults) do if exist "%%i\" @rmdir /q /s "%%i"

test:
	dotnet test

run: $(PROJECT).exe
	$(PROJECT).exe

profile: $(PROFILER).dll
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

$(PROFILER).dll $(PROJECT).exe:
	dotnet build -c Release
