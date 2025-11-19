import "../styles/controlPanel.css"

interface PanelTypes {
  handleSort?: () => void;
  handleTraverse?: () => void;
  handleSearch?: () => void;
  algorithmType: "sort" | "search" | "pathfind";
}

function ControlPanel({
  handleSort,
  handleTraverse,
  handleSearch,
  algorithmType,
}: PanelTypes) {

  function renderPanel() {
    switch (algorithmType) {
      case "sort":
        return <button className="controlpanel-btn" onClick={handleSort}>Sort</button>
      case "search":
        return <button className="controlpanel-btn" onClick={handleSearch}>Search</button>
      case "pathfind":
        return <button className="controlpanel-btn">Traverse</button>
    }
  }

  return <div>{renderPanel()}</div>;
}

export default ControlPanel;
