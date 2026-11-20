import { useState } from "react";
function useCounter(i=0) {
    const[count,setCount]=useState[i];

    function increase() {
        setCount(prev=> prev+1);
    }

    function decrease() {
        setCount(prev=> prev-1);
    }

    return {count, increase,decrease};
}
export default useCounter;

export function CounerDisplay() {
    const {count,increase,decrease}=useCounter(5);
    return (
        <div>
            <h2>{count}</h2>
            <button onClick={increase}>Add +</button>
            <button onClick={decrease}>Subtract -</button>
        </div>
    );
}

export function AnotherCounter() {
    const {count,increase}=useCounter(10);
    return(
        <button onClick={increase}>
            Another Count: {count}
        </button>
    );
}