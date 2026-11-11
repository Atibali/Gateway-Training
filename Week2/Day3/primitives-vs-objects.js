// Primitives vs Objects
let a = "hello";
let b = "hello";
console.log(a === b); // true (value comparison)

let obj1 = { name: "Alice" };
let obj2 = { name: "Alice" };
console.log(obj1 === obj2); // false (reference comparison)
console.log(obj1 === obj1); // true

// Primitives are immutable
let str = "abc";
str[0] = "z"; // silently fails (no error, no change)
console.log(str); // "abc"

// Truthy / Falsy
console.log(Boolean(0));         
console.log(Boolean(""));        
console.log(Boolean(null));      
console.log(Boolean(undefined)); 
console.log(Boolean(NaN));       
console.log(Boolean("0"));   
console.log(Boolean([]));        
console.log(Boolean({}));        

// Common pitfall:
if ([]) console.log("[] is truthy"); // runs!

// == vs === 
console.log(1 == "1");
console.log(1 === "1"); 
console.log(null == undefined);  
console.log(null === undefined);
console.log(0 == false); 
console.log(0 === false);
console.log(NaN == NaN); 
console.log("" == 0);