// Declaration (hoisted)
console.log(add(2, 3));
function add(a,b)
{
    return a+b;
}

// Expression (not hoisted)
// console.log(sub(5,1))
function sub(a,b)
{
    return a-b;
}
console.log((sub(5,1)));

// Arrow Function
const multiply=(a,b)=> a*b;
const greetHello=()=> console.log("Hello");
const square=(x)=> x*x;
console.log(multiply(2,3));
greetHello();
console.log(square(4));

// Arrow This Inheritance
const counter={
    count:0,
    icrement(){
        setTimeout(() => {
            this.count++;
            console.log(this.count);    
        }, 100);
    }
};
counter.icrement();

// Defualt Parameters
function greet(name="Guest",greeting="Hello") {
    return '${greeting},${name}!';
}
console.log(greet());
console.log(greet("Alice"));

// Rest Parameters
function sum(...numbers) {
    return numbers.reduce((total,n)=>total+n,0);
}
console.log(sum(1,2,3,4));

// Spraed
const arr1=[1,2,3];
const arr2=[4,5,6];
console.log(...arr1,...arr2)
console.log(Math.max(...arr1));


// Closure
function makeCounter(){
    let count=0;
    return function() {
        count++;
        return count;
    };
}
const counter2=makeCounter();
console.log(counter2());
console.log(counter2());
console.log(counter2());

// Classic Closure Example
function createBankAccount(intialBalance){
    let balance=intialBalance;
    return {
        deposit: (amt) => {balance+=amt; return balance;},
        withdraw: (amt)=> {balance-=amt; return balance;},
        getBalance: ()=> balance,
    };
}
const account=createBankAccount(1000);
console.log(account.deposit(250));
console.log(account.getBalance());

// Callbacks
function fetchData(callback) {
    setTimeout(() => {
        const data= {id:1, name: "Alice"};
        callback(null,data);
    },500);
}
fetchData((err,data)=> {
    if(err) return console.error(err);
    console.log("Received: ",data)
});