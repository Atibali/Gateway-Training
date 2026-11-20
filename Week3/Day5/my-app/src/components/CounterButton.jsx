function CounterButton({ onIncrement }) {
    return <button onClick={onIncrement}>Increase</button>;
}

export function CounterDisplay({ count }) {
    return <h2>Count: {count}</h2>;
}

export default CounterButton;