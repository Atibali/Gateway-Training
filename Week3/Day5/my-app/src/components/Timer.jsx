import { useEffect } from "react";
function Timer() {
    useEffect(()=> {
        const timer =setInterval(()=> {
            console.log("Timer Running...");
        },1000);

        return ()=> {
            clearInterval(timer);
        };
    },[]);
    return <h2>Timer Started</h2>;
}

export default Timer;