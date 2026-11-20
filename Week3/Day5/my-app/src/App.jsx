import { useState } from "react";
import StudentCard from "./components/Greeting";
import Product from "./components/Product";
import CounterButton, { CounterDisplay } from "./components/CounterButton";
import Counter from "./components/Counter";
const name="Charusat University"
const year=2026;
function App(){
  const [count, setCount] = useState(0);

  return (
    <div>
      <div>
        <h1>Student Management System</h1>
        <StudentCard />
      </div>
      <div className="box">
        <h1>Students from {name}</h1>
        <p>Year: {year}</p>
      </div>
      <div>
        <Product name="Keyboard" price={1200} />
        <Product name="Mouse" price={200} />
      </div>
      <h3>Use State</h3>
      <Counter/>
      <section>
        <h2>Lifting State Up</h2>
        <CounterDisplay count={count} />
        <CounterButton
          onIncrement={() => setCount((currentCount) => currentCount + 1)}
        />
      </section>
    </div>
  );
}
export default App;