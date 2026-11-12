// 1. Interface - Defines the structure of an object
interface User {
    id: number;
    name: string;
    email?: string; // Optional property
    readonly createdAt: Date; // Cannot be reassigned
}

const user: User = {
    id: 1,
    name: "Alice Wonderland",
    email: "alice@example.com",
    createdAt: new Date("2026-11-12")
};

// user.createdAt = new Date(); // Error: readonly property

console.log("User:", user.name);
console.log("Email:", user.email);
console.log("Created At:", user.createdAt.toDateString());


// 2. Type Alias - Defines a custom type
type Point = {
    x: number;
    y: number;
};

const point: Point = {
    x: 10,
    y: 20
};

console.log("Point X:", point.x);
console.log("Point Y:", point.y);


// 3. Union Types - Allows multiple possible types
type ID = string | number;

function findById(id: ID): void {
    console.log("Searching for ID:", id);
}

findById(101);
findById("USER-101");


// 4. Literal Types - Allows only specific values
type Direction = "north" | "south" | "east" | "west";

let direction: Direction = "north";

console.log("Direction:", direction);

// direction = "up"; // Error: Invalid direction