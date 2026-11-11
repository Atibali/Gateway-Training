// Named imports
import { add, subtract, PI } from "./math-export.js";
console.log(add(2, 3));
console.log(PI);

// Default import (any name)
import greetFromFile from "./greet.js";
console.log(greetFromFile("Alice"));

// Mixed default + named
import greetFromExport, { version } from "./greet-export.js";
console.log(greetFromExport("Bob"));
console.log(version);

// Import everything as namespace
import * as math from "./math-export.js";
console.log(math.add(1, 2));
console.log(math.PI);

// Dynamic import (returns a Promise)
async function loadMath() {
  const { add } = await import("./math-export.js");
  console.log(add(10, 20));
}

loadMath();