import { NavLink } from "react-router";

function App() {
    // This should later be turned into a sidebar or something.
    return <div>
        <h1>Algorithms</h1>

        <h2>Sorting Algorithms</h2>
        <button><NavLink to="/bubble-sort">Bubble Sort</NavLink></button>
        <button><NavLink to="/insertion-sort">Insertion Sort</NavLink></button>
        <button><NavLink to="/merge-sort">Merge Sort</NavLink></button>
        <button><NavLink to="/quick-sort">Quick Sort</NavLink></button>
        <button><NavLink to="/selection-sort">Selection Sort</NavLink></button>

        <h2>Searching Algorithms</h2>
        <button><NavLink to="/linear-search">Linear Search</NavLink></button>
        <button><NavLink to="/binary-search">Binary Search</NavLink></button>

        <h2>Pathfinding Algorithms</h2>
        <button><NavLink to="/dfs">Depth First Search</NavLink></button>
        <button><NavLink to="/bfs">Breadth First Search</NavLink></button>
    </div>
}

export default App
