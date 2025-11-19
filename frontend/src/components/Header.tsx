import "../styles/header.css";
import { NavLink, useNavigate } from "react-router";
import Dropdown from "./Dropdown";
import DropdownItem from "./DropdownItem";

function Header() {
  const navigateRouter = useNavigate();

  const sortingAlgorithms = [
    "Bubble",
    "Insertion",
    "Selection",
    "Merge",
    "Quick",
  ];
  const searchingAlgorithms = ["Linear", "Binary"];
  const pathfindingAlgorithms = ["Depth First Search", "Breadth First Search"];

  function navigate(algorithm: string, type: "sort" | "search" | "pathfind") {
    const lowercaseAlgorithm = algorithm.toLowerCase();

    switch (type) {
      case "sort":
        navigateRouter(`/${lowercaseAlgorithm}-sort`);
        break;
      case "search":
        navigateRouter(`/${lowercaseAlgorithm}-search`);
        break;
      case "pathfind":
        if (lowercaseAlgorithm == "depth first search") {
          navigateRouter("/dfs");
        } else {
          navigateRouter("/bfs");
        }
        break;
    }
  }

  return (
    <header className="header">
      <p ><NavLink to="/" className="header-nav">Home</NavLink></p>
      <Dropdown
        buttonText="Sorting Algorithms"
        content={
          <>
            {sortingAlgorithms.map((algorithm) => (
              <DropdownItem
                key={algorithm}
                onClick={() => navigate(algorithm, "sort")}
              >{`${algorithm} Sort`}</DropdownItem>
            ))}
          </>
        }
      />
      <Dropdown
        buttonText="Searching Algorithms"
        content={
          <>
            {searchingAlgorithms.map((algorithm) => (
              <DropdownItem
                key={algorithm}
                onClick={() => navigate(algorithm, "search")}
              >{`${algorithm} Search`}</DropdownItem>
            ))}
          </>
        }
      />
      <Dropdown
        buttonText="Pathfinding Algorithms"
        content={
          <>
            {pathfindingAlgorithms.map((algorithm) => (
              <DropdownItem
                key={algorithm}
                onClick={() => navigate(algorithm, "pathfind")}
              >{`${algorithm}`}</DropdownItem>
            ))}
          </>
        }
      />
    </header>
  );
}

export default Header;
