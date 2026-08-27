using MartianRobots.Commands;
using MartianRobots.Processors;

// Register the supported robot commands.
// Additional commands can be added here without changing the command processor.
IRobotCommand[] commands =
[
    new TurnLeftCommand(),
    new TurnRightCommand(),
    new MoveForwardCommand()
];

// Wire the application dependencies using simple constructor injection.
var commandProcessor = new RobotCommandProcessor(commands);
var processor = new MartianRobotsProcessor(commandProcessor);

// Read input from console until end of file
var input = new List<string>();
string? line;

while ((line = Console.ReadLine()) is not null)
{
    input.Add(line);
}

// Process the Mars grid and robots sequentially.
var robots = processor.Execute(input);

// Output each robot's final position and status.
foreach (var robot in robots)
{
    Console.WriteLine(robot);
}