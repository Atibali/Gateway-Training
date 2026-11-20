import { useContext } from "react";
import { ThemeContext } from "./components/ThemeContext";

function Navbar() {
    const {theme,setTheme}=useContext(ThemeContext);
    return (
        <div>
            <p>Current Theme: {theme}</p>
            <button
                onClick={()=>
                    setTheme(theme==="light" ? "dark": "light")
                }
            >
                Toogle Theme
            </button>
        </div>
    );
}

export default Navbar;