"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Parameters and return type
function add(a, b) {
    return a + b;
}
console.log(add(10, 8));
function greet(name, greeting) {
    return `${greeting ?? 'Hello'}, ${name}!`;
}
console.log(greet('Atib'));
console.log(greet('atib', 'hi'));
// Default Parameters
function pow(base, exp = 2) {
    return base ** exp;
}
console.log(pow(10, 2));
// Arrow functions
const multiply = (a, b) => a * b;
console.log(multiply(5, 6));
function lopPrint(msg) {
    throw new Error(msg);
}
//# sourceMappingURL=functions.js.map