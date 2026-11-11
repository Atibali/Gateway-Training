class Animal {
  constructor(name, sound) {
    this.name = name;
    this.sound = sound;
  }

  speak() {
    return `${this.name} says ${this.sound}`;
  }

  describe() {
    return `I am ${this.name}.`;
  }
}

class Dog extends Animal {
  constructor(name, breed) {
    super(name, "woof"); // must call super before using `this`
    this.breed = breed;
  }

  // Override
  describe() {
    return `${super.describe()} I'm a ${this.breed}.`;
  }

  fetch() {
    return `${this.name} fetches the ball!`;
  }
}

const bob = new Dog("Bob", "Labrador");
console.log(bob.speak());  
console.log(bob.describe());
console.log(bob.fetch());


console.log(bob instanceof Dog); 
console.log(bob instanceof Animal);