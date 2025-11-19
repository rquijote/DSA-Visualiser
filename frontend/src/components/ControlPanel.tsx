import "../styles/controlPanel.css";

interface PanelTypes {
  handleSort?: () => void;
  handleTraverse?: () => void;
  handleSearch?: () => void;
  algorithmType: "sort" | "search" | "pathfind";
  targetNum?: number;
  setTargetNum?: (num: number) => void;
}

function ControlPanel({
  handleSort,
  handleTraverse,
  handleSearch,
  algorithmType,
  targetNum,
  setTargetNum,
}: PanelTypes) {
  function renderPanel() {
    switch (algorithmType) {
      case "sort":
        return (
          <div className="controlpanel-div">
            <button className="controlpanel-btn-primary" onClick={handleSort}>
              Sort
            </button>
          </div>
        );
      case "search":
        return (
          <div className="controlpanel-div">
            <button className="controlpanel-btn-primary" onClick={handleSearch}>
              Search
            </button>
            <input
              type="number"
              className="controlpanel-input"
              value={targetNum}
              onChange={(e) =>
                setTargetNum && setTargetNum(Number(e.target.value))
              }
              min={1}
            />
          </div>
        );
      case "pathfind":
        return (
         <div className="controlpanel-div">
            <button className="controlpanel-btn-primary" onClick={handleTraverse}>
              Traverse
            </button>
            <button className="controlpanel-btn-secondary" onClick={handleSearch}>
              Search
            </button>
            <input
              type="number"
              className="controlpanel-input"
              value={targetNum}
              onChange={(e) =>
                setTargetNum && setTargetNum(Number(e.target.value))
              }
              min={1}
            />
          </div>
        );
      default:
        return null;
    }
  }

  return <>{renderPanel()}</>;
}

export default ControlPanel;
