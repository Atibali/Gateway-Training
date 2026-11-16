# Week 3 · Day 1

## Topics Covered

### C# and LINQ
- Query syntax and method syntax for filtering, sorting, and projecting data.
- Grouping and joining collections, including left joins.
- Quantifier and element operators such as `Any`, `All`, `First`, and `Single`.
- Asynchronous methods, `Task.WhenAll`, and cancellation tokens.
- Generic repository constraints, delegates, lambdas, and callbacks.

### Node.js and Express
- Node.js event-loop ordering for synchronous work, microtasks, timers, and `process.nextTick`.
- Using the built-in `os` module.
- A typed Express health endpoint with JSON middleware and error handling.

## Project Work

- Created the [LogiDesk project](https://github.com/Atibali/LogiDesk) and added its initial documentation.

## Running the Examples

Run each C# file separately from the repository root:

```powershell
dotnet run --file .\Week3\Day1\c#\LinqOperationsDemo.cs
dotnet run --file .\Week3\Day1\c#\Product.cs
```

Run the Node.js examples from the repository root:

```powershell
node .\Week3\Day1\NodeJS\event-loop.js
node .\Week3\Day1\NodeJS\modules.js
npx tsx .\Week3\Day1\NodeJS\express-ts.ts
```

The Express server listens on port `3000` by default. Check it at
`http://localhost:3000/api/health`; set the `PORT` environment variable to use
a different port. Stop the server with `Ctrl+C`.
