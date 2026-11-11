// var: function-scoped, hoisted with undefined
function varExample() {
  console.log(x); // undefined (hoisted)
  var x = 10;
  if (true) {
    var x = 20; // same variable! (function scope)
  }
  console.log(x); // 20
}
varExample();

// let: block-scoped
{
  let y = 5;
  console.log(y); // 5
}
// console.log(y); // ReferenceError

// let with TDZ
// console.log(z); // ReferenceError
let z = 3;

// const: cannot be re-assigned
const PI = 3.14;
// PI = 3.15; // TypeError: Assignment to constant variable

// But object contents can change:
const user = { name: "Alice" };
user.name = "Bob"; // ✅ OK
console.log(user); // { name: 'Bob' }

// var vs let
for (var i = 0; i < 3; i++) {
  setTimeout(() => console.log("var i:", i), 0); // 3, 3, 3
}
for (let j = 0; j < 3; j++) {
  setTimeout(() => console.log("let j:", j), 0); // 0, 1, 2
}