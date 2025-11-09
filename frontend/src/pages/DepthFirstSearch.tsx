import { useState } from "react";
import type { Log, SearchRequest } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import Sidebar from "../components/Sidebar";

function DepthFirstGraph() {
  const [logMsg, setLogMsg] = useState<string[]>();
  const list = [2, 5, 8, 11, 13, 15, 17, 20, 22, 23];
  const [currentList, setCurrentList] = useState<number[]>(list);
  const [highlight, setHighlight] = useState<number[]>();

  const searchRequest: SearchRequest = { list: list, target: 17 };

  const handleSearch = async () => {
    const response = await fetch("/api/search/binary", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(searchRequest),
    });

    if (response.ok) {
      const data: Log[] = await response.json();
      startVisualiser(data);
    } else {
      console.error("Failed to fetch logs");
    }
  };

  const handleTraverse = async () => {
    const response = await fetch("/api/search/binary", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(searchRequest),
    });

    if (response.ok) {
      const data: Log[] = await response.json();
      startVisualiser(data);
    } else {
      console.error("Failed to fetch logs");
    }
  };

  function startVisualiser(data: Log[]) {
    for (let i = 0; i < data.length; i++) {
      setTimeout(() => {
        setCurrentList(data[i].list);
        setHighlight(data[i].extras?.highlight || []);
        setLogMsg((prev) => [...(prev || []), data[i].msg]);
      }, i * 1000);
    }
  }

  return (
    <div className="container">
      <Sidebar />
      <div className="visualiser-container">
        <h1>Depth First Search</h1>
        <TransformWrapper>
          <TransformComponent>
            <div className="sorting-wrapper">
              <svg width="700" height="500">
              {/* Lines adjusted to stop at circle edges */}
              <line x1="100" y1="350" x2="100" y2="100" stroke="black" stroke-width="2" />
              <line x1="100" y1="100" x2="350" y2="100" stroke="black" stroke-width="2" /> 
              <line x1="350" y1="100" x2="350" y2="350" stroke="black" stroke-width="2" /> 
              <line x1="350" y1="100" x2="600" y2="200" stroke="black" stroke-width="2" /> 
              <line x1="350" y1="100" x2="100" y2="350" stroke="black" stroke-width="2" /> 

              {/* Circles and labels */}
              <circle cx="100" cy="100" r="60" stroke="black" fill="none" />
              <text x="100" y="100" text-anchor="middle" dominant-baseline="middle" font-size="20">1</text>

              <circle cx="350" cy="100" r="60" stroke="black" fill="none" />
              <text x="350" y="100" text-anchor="middle" dominant-baseline="middle" font-size="20">2</text>

              <circle cx="350" cy="350" r="60" stroke="black" fill="none" />
              <text x="350" y="350" text-anchor="middle" dominant-baseline="middle" font-size="20">3</text>

              <circle cx="100" cy="350" r="60" stroke="black" fill="none" />
              <text x="100" y="350" text-anchor="middle" dominant-baseline="middle" font-size="20">0</text>

              <circle cx="600" cy="200" r="60" stroke="black" fill="none" />
              <text x="600" y="200" text-anchor="middle" dominant-baseline="middle" font-size="20">4</text>
            </svg>
          </div>
          </TransformComponent>
        </TransformWrapper>
        <button onClick={handleSearch}>Search</button>
        <button onClick={handleTraverse}>Traverse</button>
        <div className="log-tracker">
          {logMsg?.map((msg, idx) => (
            <p key={idx}>{msg}</p>
          ))}
        </div>
      </div>
    </div>
  );
}

//https://media.geeksforgeeks.org/wp-content/uploads/20251014173018632936/frame_3148.webp

/* 
 <svg width="200" height="200">
              <circle cx="100" cy="100" r="60" stroke="black" fill="none" />
              <text
                x="100"
                y="100"
                text-anchor="middle"
                dominant-baseline="middle"
                font-size="20"
              >
                Hello
              </text>
            </svg>
*/

export default DepthFirstGraph;
