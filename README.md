# Martian Robots

A C#/.NET implementation of the Martian Robots coding challenge.

The application processes robots moving around a bounded Mars grid using `L`, `R` and `F` instructions, including the lost robot and scent behaviour described in the challenge.

## Tech Stack

- C#
- .NET 10
- xUnit
- Shouldly
- Command Pattern
- Manual constructor injection

## Project Structure

```text
src/MartianRobots/
├── Commands/
│   ├── IRobotCommand.cs
│   ├── TurnLeftCommand.cs
│   ├── TurnRightCommand.cs
│   └── MoveForwardCommand.cs
│
├── Domain/
│   ├── Direction.cs
│   ├── DirectionExtensions.cs
│   ├── MarsGrid.cs
│   ├── Position.cs
│   └── Robot.cs
│
├── Helpers/
│   └── InputParser.cs
│
├── Processors/
│   ├── MartianRobotsProcessor.cs
│   └── RobotCommandProcessor.cs
│
└── Program.cs

tests/MartianRobots.Tests/
├── Domain/
│   ├── MarsGridTests.cs
│   └── RobotTests.cs
│
└── Processor/
    ├── MartianRobotsProcessorTests.cs
    └── RobotCommandProcessorTests.cs
```

## How It Works

1. The first input line creates the `MarsGrid`.
2. Each robot is created from its starting position and direction.
3. Robot instructions are processed one at a time by `RobotCommandProcessor`.
4. Each instruction maps to an `IRobotCommand` implementation.
5. `Robot` handles movement and rotation while `MarsGrid` handles boundaries and scents.
6. Robots are processed sequentially, allowing scents left by lost robots to affect later robots.

## Run

From the solution root:

```bash
dotnet run --project src/MartianRobots
```

Enter the grid followed by each robot's starting position and instructions:

```text
5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL
```

When all input has been entered:

**Windows**

```text
Ctrl + Z
Enter
```

**macOS / Linux**

```text
Ctrl + D
```

Expected output:

```text
1 1 E
3 3 N LOST
2 3 S
```

## Tests

Run all tests with:

```bash
dotnet test
```

The tests cover the main domain rules, command processing and the supplied sample scenario.

## Design Decisions

### Domain

`Robot` owns behaviour related to an individual robot, including movement, direction and lost state.

`MarsGrid` owns the grid boundaries and scent locations shared between robots.

`Position` is implemented as a `record struct` because it represents a value and is also suitable for scent lookup using `HashSet<Position>`.

### Command Pattern

Robot instructions are represented using the Command Pattern:

```text
L -> TurnLeftCommand
R -> TurnRightCommand
F -> MoveForwardCommand
```

Each command implements `IRobotCommand`.

A simple switch statement would work for the current three instructions, but the challenge mentions that additional command types may be required in the future.

Using commands allows another instruction to be introduced without changing the command-processing loop.

### Dependency Injection

Dependencies are wired manually using constructor injection.

A DI container was intentionally not introduced as it would add unnecessary complexity for a small console application.

## Scent Behaviour

When a robot moves off the grid, it is marked as `LOST` and a scent is left at its last valid position.

If a later robot attempts to move off the grid from that same position, the forward instruction is ignored and the robot continues processing its remaining instructions.