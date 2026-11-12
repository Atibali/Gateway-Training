// Parameters and return type
function add(a: number,b: number): number {
    return a+b
}
console.log(add(10,8));

function greet(name:string,greeting?: string): string {
    return `${greeting ?? 'Hello'}, ${name}!`;    
}
console.log(greet('Atib'));
console.log(greet('atib','hi'));

// Default Parameters
function pow(base: number,exp: number=2): number {
    return base**exp;
}
console.log(pow(10,2));

// Arrow functions
const multiply= (a: number,b: number): number=> a*b;
console.log(multiply(5,6));

function lopPrint(msg: string): never{
    throw new Error(msg);
}