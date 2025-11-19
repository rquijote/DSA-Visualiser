import { useState, useRef } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import ControlPanel from "../components/ControlPanel";
import Logtracker from "../components/LogTracker";

function InsertionSort() {
  const [logMsg, setLogMsg] = useState<string[]>([]);
  const list = [1, 5, 8, 9, 2, 4, 11, 6];
  const [currentList, setCurrentList] = useState<number[]>(list);
  const [highlight, setHighlight] = useState<number[]>();

  const timeoutsRef = useRef<number[]>([]);

  const handleSort = async () => {
    const response = await fetch("/api/sort/insertion", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(list),
    });

    if (response.ok) {
      const data: Log[] = await response.json();
      startVisualiser(data);
    } else {
      console.error("Failed to fetch logs");
    }
  };

  function startVisualiser(data: Log[]) {
    timeoutsRef.current.forEach(clearTimeout);
    timeoutsRef.current = [];

    setCurrentList(list);
    setHighlight([]);
    setLogMsg([]);

    for (let i = 0; i < data.length; i++) {
      const timeout = setTimeout(() => {
        setCurrentList(data[i].list);
        setHighlight(data[i].extras?.highlight || []);
        setLogMsg((prev) => [...prev, data[i].msg]);
      }, i * 1000);

      timeoutsRef.current.push(timeout);
    }
  }

  return (
    <div className="container">
      <div className="visualiser-container">
        <h1>Insertion Sort</h1>
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

export default InsertionSort;
