SOLUTION = ivs-proj.sln
CALC_PROJ = Calculator
TESTS_PROJ = CalculatorTests
PROFILING_PROJ = Profiling

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

pack:

help:

clean:
