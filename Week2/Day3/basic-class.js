class Person {
    constructor(name,age) {
        this.name=name;
        this.age=age;
    }
    greet() {
        return `Hi, I am ${this.name}, age ${this.age}`;
    }

    // Getter
    get info() {
        return `${this.name} (${this.age})`;
    }

    set age(value){
        if(value<0) throw new Error("Age cannot be negative");
        this._age=value;
    }

    get age(){
        return this._age;
    }
}

const alice = new Person("Virat Kholi", 30);
console.log(alice.greet());
console.log(alice.info);
alice.age = 31;
console.log(alice.age);