import { NavLink } from "react-router";

function App() {
  return (
    <div className="home-container">
      <div className="home-content-container">
        <h1 className="main-title">Algorithms</h1>

        <div className="home-section">
          <h2 className="home-h2">Sorting Algorithms</h2>
          <div className="home-button-grid">
            <NavLink className="home-alg-btn primary" to="/bubble-sort">
              Bubble Sort
            </NavLink>
            <NavLink className="home-alg-btn secondary" to="/insertion-sort">
              Insertion Sort
            </NavLink>
            <NavLink className="home-alg-btn tertiary" to="/selection-sort">
              Selection Sort
            </NavLink>
            <NavLink className="home-alg-btn quaternary" to="/merge-sort">
              Merge Sort
            </NavLink>
            <NavLink className="home-alg-btn primary" to="/quick-sort">
              Quick Sort
            </NavLink>
          </div>
        </div>

        <div className="home-section">
          <h2 className="home-h2">Searching Algorithms</h2>
          <div className="home-button-grid">
            <NavLink className="home-alg-btn secondary" to="/linear-search">
              Linear Search
            </NavLink>
            <NavLink className="home-alg-btn tertiary" to="/binary-search">
              Binary Search
            </NavLink>
          </div>
        </div>

        <div className="home-section">
          <h2 className="home-h2">Pathfinding Algorithms</h2>
          <div className="home-button-grid">
            <NavLink className="home-alg-btn quaternary" to="/dfs">
              Depth First Search
            </NavLink>
            <NavLink className="home-alg-btn primary" to="/bfs">
              Breadth First Search
            </NavLink>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
