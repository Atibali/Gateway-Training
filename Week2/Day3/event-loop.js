console.log("1: synchronous");

setTimeout(() => console.log("2: macrotask (setTimeout)"), 0);

Promise.resolve().then(() => console.log("3: microtask (promise)"));

queueMicrotask(() => console.log("4: microtask (queueMicrotask)"));

console.log("5: synchronous");