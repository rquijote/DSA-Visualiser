import { useState } from "react";
import type { Log, PathfindingRequest } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import ControlPanel from "../components/ControlPanel";

function DepthFirstGraph() {
  const [logMsg, setLogMsg] = useState<string[]>();
  const [visited, setVisited] = useState<number[]>();
  const [toVisit, setToVisit] = useState<number[]>();
  const [searchNode, setSearchNode] = useState<number>(0);

  const graph: Record<number, number[]> = {
    "1": [2, 7],
    "2": [3, 4, 5],
    "3": [],
    "4": [],
    "5": [6],
    "6": [],
    "7": [8],
    "8": [9],
    "9": [],
  };

  const positions: Record<number, { x: number; y: number }> = {
    1: { x: 350, y: 60 },
    2: { x: 180, y: 180 },
    3: { x: 90, y: 300 },
    4: { x: 180, y: 300 },
    5: { x: 270, y: 300 },
    6: { x: 270, y: 400 },
    7: { x: 520, y: 180 },
    8: { x: 440, y: 300 },
    9: { x: 440, y: 400 },
  };

  const pathfindingRequest: PathfindingRequest = {
    graph: graph,
    startNode: 1,
    targetNode: searchNode
  };

  const handleSearch = async () => {
    const response = await fetch("/api/pathfinding/dfs-search", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(pathfindingRequest),
    });

    if (response.ok) {
      const data: Log[] = await response.json();
      startVisualiser(data);
    } else {
      console.error("Failed to fetch logs");
    }
  };

  const handleTraverse = async () => {
    console.log(pathfindingRequest);
    const response = await fetch("/api/pathfinding/dfs-traverse", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(pathfindingRequest),
    });

    if (response.ok) {
      const data: Log[] = await response.json();
      startVisualiser(data);
    } else {
      console.error("Failed to fetch logs");
      console.error(response);
    }
  };

  function startVisualiser(data: Log[]) {
    for (let i = 0; i < data.length; i++) {
      setTimeout(() => {
        console.log(data[i]);
        setVisited(data[i].extras?.visitedHighlight || [])
        setToVisit(data[i].extras?.toVisitHighlight || [])
        setLogMsg((prev) => [...(prev || []), data[i].msg]);
      }, i * 1000);
    }
  }

  return (
    <div className="container">
      <div className="visualiser-container">
        <h1>Depth First Search</h1>
        <TransformWrapper>
          <TransformComponent>
            <div className="sorting-wrapper">
              <svg width="700" height="500">
                {/* Lines */}
                {Object.entries(graph).map(([from, toList]) =>
                  toList.map((to) => {
                    const fromPos = positions[Number(from)];
                    const toPos = positions[to];
                    return (
                      <line
                        key={`${from}-${to}`}
                        x1={fromPos.x}
                        y1={fromPos.y}
                        x2={toPos.x}
                        y2={toPos.y}
                        stroke="black"
                        strokeWidth={2}
                      />
                    );
                  })
                )}
                {/* Circles and Text */}
                {Object.entries(positions).map(([node, positions]) => (
                  <g key={node}>
                    <circle cx={positions.x} cy={positions.y} r={40} stroke="black" fill={visited?.includes(Number(node)) ? "black" : toVisit?.includes(Number(node)) ? "lightgrey" : "white"}  strokeWidth={2}/>
                    <text x={positions.x} y={positions.y} textAnchor="middle" dominantBaseline="middle" fill={visited?.includes(Number(node)) ? "white" : "black"} fontSize={22}>{node}</text>
                  </g>
                ))}
              </svg>
            </div>
          </TransformComponent>
        </TransformWrapper>
        <ControlPanel algorithmType="pathfind" setTargetNum={setSearchNode} handleSearch={handleSearch} handleTraverse={handleTraverse}/>
        <div className="log-tracker">
          {logMsg?.map((msg, idx) => (
            <p key={idx}>{msg}</p>
          ))}
        </div>
      </div>
    </div>
  );
}

export default DepthFirstGraph;
