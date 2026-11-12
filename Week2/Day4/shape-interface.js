"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// Circle class implements Shape interface
class Circle {
    radius;
    constructor(radius) {
        this.radius = radius;
    }
    area() {
        return Math.PI * this.radius ** 2;
    }
    perimeter() {
        return 2 * Math.PI * this.radius;
    }
}
// Create Circle object
const circle = new Circle(5);
// Calculate and display results
console.log("Circle Radius:", 5);
console.log("Area:", circle.area().toFixed(2));
console.log("Perimeter:", circle.perimeter().toFixed(2));
//# sourceMappingURL=shape-interface.js.map