import { NavLink } from "react-router";

function App() {
  return (
    <div className="home-container">
      <div className="home-content-container">
        <h1 className="main-title">Algorithm Visualiser</h1>

        <div className="home-section">
          <h2 className="home-h2">Sorting</h2>
          <div className="home-button-grid">
            <NavLink className="home-alg-btn" to="/bubble-sort">
              Bubble Sort
            </NavLink>
            <NavLink className="home-alg-btn" to="/insertion-sort">
              Insertion Sort
            </NavLink>
            <NavLink className="home-alg-btn" to="/selection-sort">
              Selection Sort
            </NavLink>
            <NavLink className="home-alg-btn" to="/merge-sort">
              Merge Sort
            </NavLink>
            <NavLink className="home-alg-btn" to="/quick-sort">
              Quick Sort
            </NavLink>
          </div>
        </div>

        <div className="home-section">
          <h2 className="home-h2">Searching</h2>
          <div className="home-button-grid">
            <NavLink className="home-alg-btn" to="/linear-search">
              Linear Search
            </NavLink>
            <NavLink className="home-alg-btn" to="/binary-search">
              Binary Search
            </NavLink>
          </div>
        </div>

        <div className="home-section">
          <h2 className="home-h2">Pathfinding</h2>
          <div className="home-button-grid">
            <NavLink className="home-alg-btn" to="/dfs">
              Depth First Search
            </NavLink>
            <NavLink className="home-alg-btn" to="/bfs">
              Breadth First Search
            </NavLink>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
