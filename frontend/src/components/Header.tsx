import "../styles/header.css";
import { useNavigate } from "react-router";
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
  const pathfindingAlgorithms = ["dfs", "bfs"];

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
        navigateRouter(`/${lowercaseAlgorithm}-pathfind`);
        break;
    }
  }

  return (
    <header className="header">
      <p>Header</p>
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
            {sortingAlgorithms.map((algorithm) => (
              <DropdownItem
                key={algorithm}
                onClick={() => navigate(algorithm, "search")}
              >{`${algorithm} Sort`}</DropdownItem>
            ))}
          </>
        }
      />
      <Dropdown
        buttonText="Pathfinding Algorithms"
        content={
          <>
            {sortingAlgorithms.map((algorithm) => (
              <DropdownItem
                key={algorithm}
                onClick={() => navigate(algorithm, "pathfind")}
              >{`${algorithm} Sort`}</DropdownItem>
            ))}
          </>
        }
      />
    </header>
  );
}

export default Header;
