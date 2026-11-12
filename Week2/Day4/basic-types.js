"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// String
let userName = "Atibali";
// Number
let age = 21;
let price = 499.99;
// Boolean
let isStudent = true;
// Array
let skills = ["Java", "Python", "TypeScript"];
let marks = [85, 90, 95];
// Any (can store any type of value)
let data = "Hello";
data = 100;
data = true;
// Tuple (fixed types and order)
let user = ["Atibali", 21];
// Enum
var Status;
(function (Status) {
    Status[Status["Pending"] = 0] = "Pending";
    Status[Status["Approved"] = 1] = "Approved";
    Status[Status["Rejected"] = 2] = "Rejected";
})(Status || (Status = {}));
let applicationStatus = Status.Approved;
// Output
console.log("Name:", userName);
console.log("Age:", age);
console.log("Price:", price);
console.log("Is Student:", isStudent);
console.log("Skills:", skills);
console.log("Marks:", marks);
console.log("Any Data:", data);
console.log("User:", user);
console.log("Application Status:", applicationStatus);
//# sourceMappingURL=basic-types.js.map