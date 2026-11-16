console.log('1 — sync');

setTimeout(() => console.log('2 — timer'), 0);

Promise.resolve().then(() => console.log('3 — microtask'));

process.nextTick(() => console.log('4 — nextTick'));

console.log('5 — sync');