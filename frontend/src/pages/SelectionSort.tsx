import { useState, useRef } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import ControlPanel from "../components/ControlPanel";
import Logtracker from "../components/LogTracker";

function SelectionSort() {
  const initialList = [1, 5, 8, 9, 2, 4, 11, 6];
  const [logMsg, setLogMsg] = useState<string[]>([]);
  const [currentList, setCurrentList] = useState<number[]>(initialList);
  const [highlight, setHighlight] = useState<number[]>();
  const timeoutsRef = useRef<number[]>([]);

  const handleSort = async () => {
    const response = await fetch("/api/sort/selection", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(initialList),
    });

    if (response.ok) {
      const data: Log[] = await response.json();
      startVisualiser(data);
    } else {
      console.error("Failed to fetch logs");
    }
  };

  function startVisualiser(data: Log[]) {
    // Clear previous timeouts
    timeoutsRef.current.forEach(clearTimeout);
    timeoutsRef.current = [];

    setCurrentList(initialList);
    setHighlight([]);
    setLogMsg([]);

    data.forEach((log, i) => {
      const timeout = setTimeout(() => {
        setCurrentList(log.list);
        setHighlight(log.extras?.highlight || []);
        setLogMsg((prev) => [...prev, log.msg]);
      }, i * 1000);

      timeoutsRef.current.push(timeout);
    });
  }

  return (
    <div className="container">
      <div className="visualiser-container">
        <h1>Selection Sort</h1>
        <TransformWrapper>
          <TransformComponent>
            <div className="sorting-wrapper">
              <div className="sorting-div">
                {currentList.map((number, idx) => (
                  <div
                    key={idx}
                    className={`sorting-numbox ${
                      highlight?.includes(idx) ? "highlight" : ""
                    }`}
                  >
                    {number}
                  </div>
                ))}
              </div>
            </div>
          </TransformComponent>
        </TransformWrapper>
        <ControlPanel handleSort={handleSort} algorithmType="sort" />
        <Logtracker logMsg={logMsg} />
      </div>
    </div>
  );
}

export default SelectionSort;
