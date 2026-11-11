# Week 2: Day 3 - JavaScript Fundamentals and Async Patterns

Day 3 focused on JavaScript core concepts that are important for automation, browser scripting, and asynchronous programming. The exercises in this folder cover functions, closures, callbacks, promises, fetch, and event-loop behavior.

## Topics covered

### JavaScript basics

- Understand function declarations, function expressions, and arrow functions.
- Explore default parameters, rest parameters, and spread syntax.
- Practice variable scoping and how `var` differs from `let` and `const`.
- Learn about objects, arrays, and how JavaScript handles primitive vs. object values.

### Closures and higher-order functions

- Create functions that retain access to outer variables.
- Use closures to build counters and simple stateful objects.
- Understand how callback functions are used in JavaScript APIs.

### Asynchronous JavaScript

- Use `setTimeout` to simulate delayed work.
- Understand callback order and the difference between synchronous and asynchronous execution.
- Work with nested callbacks and recognize why they can become difficult to maintain.
- Explore `Promise` chaining, `Promise.all`, `Promise.race`, `Promise.allSettled`, and `Promise.any`.
- Use `fetch` to make HTTP requests and handle success and failure cases.

### Practice files in this folder

- `functions.js` - function declarations, arrow functions, default params, rest params, closures
- `callbacks.js` - nested callback example showing callback-based flow
- `event-loop.js` - synchronous vs. microtask/macrotask execution order
- `fetch.js` - HTTP requests using `fetch` and `async/await`
- `promises.js` - promise creation and promise combinators
- `variables.js` - `var`/`let` behavior and scope examples
- `primitives-vs-objects.js` - primitive vs. reference value behavior

## Learning outcome

By the end of this day, the goal was to become comfortable with JavaScript fundamentals and to understand the asynchronous nature of modern front-end and automation workflows.
