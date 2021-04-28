SOLUTION = ivs-proj.sln
CALC_PROJ = Calculator
TESTS_PROJ = CalculatorTests
PROFILING_PROJ = Profiling
DOC = doc
SRC = src
BIN = bin
OBJ = obj
PROPERTIES = Properties
INSTALL = install
PACKAGE = xvarte00_xbarto0e_xchudy06_xkurti03

EXE_PATH = bin\Debug\netcoreapp3.1

all: build-all run

run:
	$(CALC_PROJ)\$(EXE_PATH)\$(CALC_PROJ).exe

profile: build-profiling
	$(PROFILING_PROJ)\$(EXE_PATH)\$(PROFILING_PROJ).exe

build-all:
	dotnet build $(SOLUTION) --no-dependencies

build-calc:
	dotnet build $(CALC_PROJ)\$(CALC_PROJ).csproj

build-tests:
	dotnet build $(TESTS_PROJ)\$(TESTS_PROJ).csproj

build-profiling:
	dotnet build $(PROFILING_PROJ)\$(PROFILING_PROJ).csproj

pack: clean
	
	@mkdir ..\$(PACKAGE)\doc
	@mkdir ..\$(PACKAGE)\install
	@mkdir ..\$(PACKAGE)\repo
	@xcopy ..\..\$(DOC) ..\$(PACKAGE)\doc /E
	@xcopy ..\$(SRC) ..\$(PACKAGE)\repo /E
	@xcopy ..\..\$(INSTALL) ..\$(PACKAGE)\repo /E
	@cd ..\ && tar -c -f $(PACKAGE).zip $(PACKAGE)
help:
	@echo "In order to run this program you need .NET core installed"
	@echo "Commands for make:"
	@echo "all - makes all and then calls make run"
	@echo "run - runs program"
	@echo "profile - makes profiler"
	@echo "pack - Creates archive of the project"
	@echo "clean - Cleanses all unnecessary files for clean build"
	
clean:
	@if exist ..\$(PACKAGE) rmdir /Q /S ..\$(PACKAGE)
	@rmdir /Q /S "$(CALC_PROJ)\$(BIN)"
	@rmdir /Q /S "$(CALC_PROJ)\$(OBJ)"
	@rmdir /Q /S "$(TESTS_PROJ)\$(BIN)"
	@rmdir /Q /S "$(TESTS_PROJ)\$(OBJ)"
	@rmdir /Q /S "$(PROFILING_PROJ)\$(BIN)"
	@rmdir /Q /S "$(PROFILING_PROJ)\$(OBJ)"