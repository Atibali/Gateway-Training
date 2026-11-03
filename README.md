# Gateway Training

Training tasks and code are organized by week, then by day:

```text
Week1/
  Day1/
    README.md       # Day 1 instructions and run commands
    Program.cs      # Selects which lesson to run
    Lessons/        # Lesson code
```

## Find a week and day's work

| Week | Day | Tasks and code |
|---|---|---|
| [Week 1](Week1/) | [Day 1](Week1/Day1/) | [Day 1 README](Week1/Day1/README.md) · [Lesson code](Week1/Day1/Lessons/) |

New training days follow the same `WeekN/DayN/` layout. Check that day's README for its tasks and instructions.

## Run a lesson

From the Day 1 folder, run the app with the .NET 10 SDK:

```sh
cd Week1/Day1
dotnet run -- Methods
```

Replace `Methods` with a lesson name such as `HelloWorld`, `Strings`, or `Collections`. See the [Day 1 README](Week1/Day1/README.md) for all available lessons.

## Small code example

The [HelloWorld lesson](Week1/Day1/Lessons/HelloWorld.cs) prints a greeting:

```csharp
Console.WriteLine("Hello, World!");
```
