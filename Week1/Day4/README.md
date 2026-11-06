# Day 4: Programming for Testers

Day 4 focuses on writing and checking login-page test scenarios in C#. The project includes a simple login model and a set of validation tests for valid and invalid login flows. It requires the .NET 10 SDK.

## Run the practice project

From the repository root, run:

```powershell
dotnet run --project Week1/Day4/ProgrammingForTesters/ProgrammingForTesters.csproj
```

This runs the sample tests in `Program.cs` and prints PASS/FAIL results for:

- valid login
- invalid email
- empty email
- empty password
- invalid password

## Project files

- `ProgrammingForTesters/Program.cs` runs the test scenarios
- `ProgrammingForTesters/LoginPage.cs` contains the login validation logic
- `ProgrammingForTesters/LoginTests.cs` defines the test cases
- `GitPractice.md` contains the Git command practice transcript for testers

## Git practice for testers

See [GitPractice.md](GitPractice.md) for the Git command practice transcript.
