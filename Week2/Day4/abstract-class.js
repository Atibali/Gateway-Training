"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Animal {
    name;
    constructor(name) {
        this.name = name;
    }
    describe() {
        return `${this.name} says ${this.speak()}`;
    }
}
class Dog extends Animal {
    speak() { return 'Woof Woof...'; }
}
const d = new Dog('Rex');
console.log(d.describe());
//# sourceMappingURL=abstract-class.js.map