# Day 2: Exceptions, Date/Time, and SQL

Day 2 contains C# examples for exception handling and date/time operations, plus SQL practice scripts. The C# examples require the .NET 10 SDK.

## C# programs

From the repository root, run one C# program at a time:

```sh
dotnet run --file Week1/Day2/TryCatchFinally.cs
```

Replace `TryCatchFinally.cs` with the program you want to run:

| Program | Topic |
|---|---|
| `TryCatchFinally.cs` | `try`, `catch`, and `finally` |
| `MultipleCatchBlocks.cs` | Handling different exception types |
| `ThrowingExceptions.cs` | Throwing an exception |
| `CustomException.cs` | Defining and handling a custom exception |
| `DateTimeExample.cs` | Reading the current date and time |
| `DatesOperations.cs` | Adding days, months, and hours to dates |
| `TimeSpanExample.cs` | Calculating the duration between two dates |
| `DateTimeOffsetExample.cs` | Comparing `DateTime` and `DateTimeOffset` |
| `UTC.cs` | Reading local and UTC time |

Each command compiles and runs only the selected source file.

## SQL scripts

The scripts in `Sql/` use the sample customer, order, and product tables. Load `sqlpractice.sql` into a MySQL or MariaDB database first, then run the practice script you want with a MySQL/MariaDB client.

| Script | Topic |
|---|---|
| `sqlpractice.sql` | Creating and populating the sample database |
| `ReadingData.sql` | Filtering, sorting, and selecting data |
| `ChangingData.sql` | Inserting, updating, and deleting data |
| `Joins.sql` | Joining related tables |
| `Aggregates.sql` | Aggregate functions, grouping, and filtering groups |
