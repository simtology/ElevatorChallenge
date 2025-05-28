# ElevatorSimulator
A C# console application simulating elevator movement in a multi-floor building, built with clean architecture, SOLID principles, appropriate design patterns, unit testing with Test Driven Development (TDD) using XUnit, NSubstitute, and AutoFixture. Supports multiple elevator types and efficient dispatching.

## Features
- Real-time elevator status (floor, direction, passenger count/weight).
- Interactive elevator control via console.
- Support for multiple floors and elevators.
- Type-aware dispatching (Passenger, Freight, HighSpeed).
- Passenger/weight limit handling.
- Extensible via Factory Pattern.

## Setup
1. **Prerequisites**:
    - .NET 9 SDK
    - Git
    - GitHub CLI (`gh`)
    - Visual Studio 2022
    - Visual Studio Code (VS Code)
2. **Clone Repository**:
   ```bash
    git clone https://github.com/simtology/ElevatorChallenge.git
    cd ElevatorChallenge

   **Restore and Build**
    dotnet restore
    dotnet build

    **Run Tests**
    dotnet test

    **Run Application**
    dotnet run