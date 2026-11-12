"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const user = {
    id: 1,
    name: "Alice Wonderland",
    email: "alice@example.com",
    createdAt: new Date("2026-11-12")
};
// user.createdAt = new Date(); // Error: readonly property
console.log("User:", user.name);
console.log("Email:", user.email);
console.log("Created At:", user.createdAt.toDateString());
const point = {
    x: 10,
    y: 20
};
console.log("Point X:", point.x);
console.log("Point Y:", point.y);
function findById(id) {
    console.log("Searching for ID:", id);
}
findById(101);
findById("USER-101");
let direction = "north";
console.log("Direction:", direction);
// direction = "up"; // Error: Invalid direction
//# sourceMappingURL=shaping-data.js.map