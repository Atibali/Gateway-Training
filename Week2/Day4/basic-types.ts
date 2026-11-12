
// String
let userName: string = "Atibali";

// Number
let age: number = 21;
let price: number = 499.99;

// Boolean
let isStudent: boolean = true;

// Array
let skills: string[] = ["Java", "Python", "TypeScript"];
let marks: number[] = [85, 90, 95];

// Any (can store any type of value)
let data: any = "Hello";
data = 100;
data = true;

// Tuple (fixed types and order)
let user: [string, number] = ["Atibali", 21];

// Enum
enum Status {
    Pending,
    Approved,
    Rejected
}


let applicationStatus: Status = Status.Approved;

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