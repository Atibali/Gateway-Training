// Interface - Defines required methods
interface Shape {
    area(): number;
    perimeter(): number;
}

// Circle class implements Shape interface
class Circle implements Shape {
    constructor(private radius: number) {}

    area(): number {
        return Math.PI * this.radius ** 2;
    }

    perimeter(): number {
        return 2 * Math.PI * this.radius;
    }
}

// Create Circle object
const circle = new Circle(5);

// Calculate and display results
console.log("Circle Radius:", 5);
console.log("Area:", circle.area().toFixed(2));
console.log("Perimeter:", circle.perimeter().toFixed(2));
