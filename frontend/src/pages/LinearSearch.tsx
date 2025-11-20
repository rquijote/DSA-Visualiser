import { useState, useRef } from "react";
import type { Log, SearchRequest } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import ControlPanel from "../components/ControlPanel";
import Logtracker from "../components/LogTracker";

function LinearSearch() {
  const [logMsg, setLogMsg] = useState<string[]>([]);
  const list = [2, 5, 8, 11, 13, 15, 17, 20, 22, 23];
  const [currentList, setCurrentList] = useState<number[]>(list);
  const [highlight, setHighlight] = useState<number[]>();
  const [targetNum, setTargetNum] = useState<number>(0);
  const [alertHighlight, setAlertHighlight] = useState<number[]>();
  const [speed, setSpeed] = useState(1000);

  const timeoutsRef = useRef<number[]>([]);

  const searchRequest: SearchRequest = { list, target: targetNum };

  const handleSearch = async () => {
    const response = await fetch("/api/search/linear", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(searchRequest),
    });

    if (response.ok) {
      const data: Log[] = await response.json();
      startVisualiser(data);
    } else {
      console.error("Failed to fetch logs", response);
    }
  };

  function startVisualiser(data: Log[]) {
    timeoutsRef.current.forEach(clearTimeout);
    timeoutsRef.current = [];

    setCurrentList(list);
    setHighlight([]);
    setLogMsg([]);
    setAlertHighlight([]);

    for (let i = 0; i < data.length; i++) {
      const timeout = setTimeout(() => {
        setCurrentList(data[i].list);
        setHighlight(data[i].extras?.highlight || []);
        setAlertHighlight(data[i].extras?.alertHighlight || []);
        setLogMsg((prev) => [...prev, data[i].msg]);
      }, i * speed);

      timeoutsRef.current.push(timeout);
    }
  }

  return (
    <div className="container">
      <div className="visualiser-container">
        <h1>Linear Search</h1>
        <TransformWrapper>
          <TransformComponent>
            <div className="sorting-wrapper">
              <div className="sorting-div">
                {currentList.map((number, idx) => (
                      <div
                        key={idx}
                        className={`sorting-numbox ${
                          alertHighlight?.includes(idx)
                            ? "alert-highlight"
                            : highlight?.includes(idx)
                            ? "highlight"
                            : ""
                        }`}
                      >
                        {number}
                      </div>
                    ))}
              </div>
            </div>
          </TransformComponent>
        </TransformWrapper>
        <ControlPanel
          algorithmType="search"
          handleSearch={handleSearch}
          setTargetNum={setTargetNum}
          speed={speed}
          setSpeed={setSpeed}
        />
        <Logtracker logMsg={logMsg} />
      </div>
    </div>
  );
}

export default LinearSearch;
