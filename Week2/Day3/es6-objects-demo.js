// Object Literal
const person = {
    name: 'Atibali',
    age: 21,
    address: { city: "Ahmedabad", state: "Gujarat" },
    greet: function() {
        console.log(`Hello, my name is ${this.name}`);
    }
};
console.log(person.name);
console.log(person.address.city);
person.greet();

// Destructuring
const { name, age } = person;
console.log(name, age);

// Rename & Default Value
const { name: fullName, email = "saiyedatibali@gmail.com" } = person;
console.log(fullName, email);

// Nested Destructuring
const { address: { city } } = person;
console.log(city);

// In Function Params (Fixed: used backticks instead of single quotes)
function display({ name, age }) {
    console.log(`${name} is ${age}`);
}
display(person);


// Spread Operator (Fixed: corrected spelling to 'defaults')
const defaults = { theme: "light", lang: "en", fontSize: 14 };
const userPrefs = { theme: "dark", fontSize: 16 };
const merged = { ...defaults, ...userPrefs };
console.log(merged);

// --- Optional chaining ---
const user1 = { name: "Bob", address: null };
console.log(user1.address?.city); 
console.log(user1.address?.city ?? "Unknown city");

// With method calls:
const api = { getUser: () => ({ name: "Alice" }) };
console.log(api.getUser?.().name); // Alice

// --- Object.keys / values / entries ---
const scores = { Alice: 90, Bob: 85, Charlie: 92 };

console.log(Object.keys(scores));  
console.log(Object.values(scores));
console.log(Object.entries(scores));

// Iterate entries:
for (const [name, score] of Object.entries(scores)) {
  console.log(`${name}: ${score}`);
}

// Transform object with entries + map + fromEntries:
const doubled = Object.fromEntries(
  Object.entries(scores).map(([k, v]) => [k, v * 2])
);
console.log(doubled); // { Alice: 180, Bob: 170, Charlie: 184 }