import "../styles/controlPanel.css";

interface PanelTypes {
  handleSort?: () => void;
  handleTraverse?: () => void;
  handleSearch?: () => void;
  algorithmType: "sort" | "search" | "pathfind";
  targetNum?: number;
  setTargetNum?: (num: number) => void;
  speed?: number;
  setSpeed?: React.Dispatch<React.SetStateAction<number>>;
}

function ControlPanel({
  handleSort,
  handleTraverse,
  handleSearch,
  algorithmType,
  targetNum,
  setTargetNum,
  speed,
  setSpeed,
}: PanelTypes) {
  function renderSpeedBtns() {
    return (
      <div className="speed-controls">
        <button
          className="controlpanel-btn-secondary"
          onClick={() =>
            setSpeed &&
            setSpeed((prev) =>
              prev ? (prev + 1000 > 10000 ? 10000 : prev + 1000) : 1000
            )
          }
        >
          +
        </button>
        <span>{speed}ms</span>
        <button
          className="controlpanel-btn-secondary"
          onClick={() =>
            setSpeed &&
            setSpeed((prev) =>
              prev && prev - 1000 < 1000 ? 1000 : prev - 1000
            )
          }
        >
          -
        </button>
      </div>
    );
  }

  function renderPanel() {
    switch (algorithmType) {
      case "sort":
        return (
          <div className="controlpanel-div">
            <button className="controlpanel-btn-primary" onClick={handleSort}>
              Sort
            </button>
            {renderSpeedBtns()}
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
            {renderSpeedBtns()}
          </div>
        );
      case "pathfind":
        return (
          <div className="controlpanel-div">
            <button
              className="controlpanel-btn-primary"
              onClick={handleTraverse}
            >
              Traverse
            </button>
            <button
              className="controlpanel-btn-secondary"
              onClick={handleSearch}
            >
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
            {renderSpeedBtns()}
          </div>
        );
      default:
        return null;
    }
  }

  return <>{renderPanel()}</>;
}

export default ControlPanel;
