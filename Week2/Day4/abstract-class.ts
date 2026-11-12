abstract class Animal {
    constructor (protected name: string){}
    abstract speak(): string;
    describe(): string {
        return `${this.name} says ${this.speak()}`;
    }
}

class Dog extends Animal {
    speak(): string {return 'Woof Woof...';}
}
const d=new Dog('Rex');
console.log(d.describe());