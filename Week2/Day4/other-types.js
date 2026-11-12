"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Enums
var Color;
(function (Color) {
    Color[Color["Red"] = 0] = "Red";
    Color[Color["Green"] = 1] = "Green";
    Color[Color["Blue"] = 2] = "Blue";
})(Color || (Color = {}));
var Status;
(function (Status) {
    Status["Pending"] = "P";
    Status["Success"] = "S";
    Status["Error"] = "E";
})(Status || (Status = {}));
console.log(Status.Success);
console.log(Color.Blue);
function identityAny(arg) {
    return arg;
}
// Generics
function identity(arg) {
    return arg;
}
const s1 = identityAny('Hello');
const n1 = identityAny(44);
const s2 = identity('Hello');
const n2 = identity(44);
console.log(`Type of s1: ${typeof (s1)}`);
console.log(`Type of s2: ${typeof (s2)}`);
console.log(`Type of n1: ${typeof (n1)}`);
console.log(`Type of n2: ${typeof (n2)}`);
// Demonstrating type safety
s2.toUpperCase(); // Valid: TypeScript knows s2 is string
// s1.toUpperCase(); // Also allowed, but TypeScript cannot verify it safely
function firstItem(arr) {
    return arr[0];
}
console.log(firstItem([1, 3, 5]));
const stringBox = { value: 'Hello World' };
console.log(stringBox.value);
// Type Narrowing
function format(value) {
    if (typeof value == 'string') {
        return value.toUpperCase();
    }
    return value.toFixed(2);
}
console.log(format("Jacob is great"));
console.log(format(1007));
// Null checks
function length(s) {
    if (s === null)
        return 0;
    return s.length; // narrowed to string
}
console.log(length(null));
// Custom Type Guard
function isString(v) {
    return typeof v === 'string';
}
console.log(isString(7.8));
//# sourceMappingURL=other-types.js.map