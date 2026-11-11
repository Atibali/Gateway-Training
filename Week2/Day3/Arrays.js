const users=[
    {id:1,name:'Alice',age: 30,active:true},
    {id:2,name:'Bob',age: 25,active:false},
    {id:3,name:'Charlie',age: 35,active:true},
    {id:4,name:'David',age: 28,active:false}
]

// map
const names=users.map(user => user.name);
console.log(names); 

//reduce
const totalAge=users.reduce((sum,user)=>sum+user.age,0);
console.log(totalAge);

// Group by property
const byActive=users.reduce((group,user)=>{
    const key=user.active?'active':'inactive';
    if(!group[key]){
        group[key]=[];
    }
    group[key].push(user);
    return group;
}, {});
console.log(byActive);

// Find
const bob=users.find(user=>user.name==='Bob');
console.log(bob);

// Every
console.log(users.some(user=>user.age>20));
console.log(users.every(user=>user.age>30));
console.log(users.some(user=>user.age>30));

// sort
console.log([10,9,1,2].sort());

const nums=[10,9,1,2];
nums.sort((a,b)=>a-b);
console.log(nums);

// sort objects
const sortedByAge=[...users].sort((a,b)=>a.age-b.age);
console.log(sortedByAge);

// for each
users.forEach(user=>console.log(user.name));

// Chaining
const activeNames=users.filter(user=>user.active).map(user=>user.name);
console.log(activeNames);