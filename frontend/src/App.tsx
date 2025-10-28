import { NavLink } from "react-router";
function App() {
    // This should later be turned into a sidebar or something.
    return <div>
        <h1>Algorithms</h1>
        <button> <NavLink to="/bubble-sort">Bubble Sort</NavLink> </button>
    </div>
}

export default App
