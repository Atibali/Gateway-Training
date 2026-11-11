// Creating a promise
function delay(ms) {
  return new Promise((resolve) => setTimeout(resolve, ms));
}

// Chaining
delay(500)
  .then(() => {
    console.log("500ms passed");
    return delay(300);
  })
  .then(() => console.log("another 300ms passed"))
  .catch((err) => console.error("Error:", err))
  .finally(() => console.log("Done"));

// Promise combinators
const p1 = delay(100).then(() => "one");
const p2 = delay(200).then(() => "two");
const p3 = delay(50).then(() => "three");

// Promise.all — wait for all (rejects if any fails)
Promise.all([p1, p2, p3]).then(console.log);

// Promise.race — first to settle
Promise.race([p1, p2, p3]).then(console.log);

// Promise.allSettled — wait for all regardless of outcome
Promise.allSettled([p1, Promise.reject("fail")]).then(console.log);

// Promise.any — first to fulfill (ignores rejections)
Promise.any([Promise.reject("x"), p2]).then(console.log);