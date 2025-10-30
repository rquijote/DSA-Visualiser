import { NavLink } from "react-router";
import "../styles/sidebar.css";

export default function Sidebar() {
  return (
    <div className="sidebar-container">
        <div className="sidebar-column">
          <h4>Sorting Algorithms</h4>
          <button>
            <NavLink to="/bubble-sort">Bubble Sort</NavLink>
          </button>
          <button>
            <NavLink to="/insertion-sort">Insertion Sort</NavLink>
          </button>
          <button>
            <NavLink to="/merge-sort">Merge Sort</NavLink>
          </button>
          <button>
            <NavLink to="/quick-sort">Quick Sort</NavLink>
          </button>
          <button>
            <NavLink to="/selection-sort">Selection Sort</NavLink>
          </button>
        </div>

        <div className="sidebar-column">
          <h4>Searching Algorithms</h4>
          <button>
            <NavLink to="/linear-search">Linear Search</NavLink>
          </button>
          <button>
            <NavLink to="/binary-search">Binary Search</NavLink>
          </button>
        </div>

        <div className="sidebar-column">
          <h4>Pathfinding Algorithms</h4>
          <button>
            <NavLink to="/dfs">Depth First Search</NavLink>
          </button>
          <button>
            <NavLink to="/bfs">Breadth First Search</NavLink>
          </button>
        </div>
    </div>
  );
}
