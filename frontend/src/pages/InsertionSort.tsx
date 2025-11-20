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
  const [alertHighlight, setAlertHighlight] = useState<number[]>();
  const [speed, setSpeed] = useState(1000); // speed state

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
    setAlertHighlight([]);
    setLogMsg([]);

    data.forEach((log, i) => {
      const timeout = setTimeout(() => {
        setCurrentList(log.list);
        setHighlight(log.extras?.highlight || []);
        setAlertHighlight(log.extras?.alertHighlight || []);
        setLogMsg((prev) => [...prev, log.msg]);
      }, i * speed); // use speed here

      timeoutsRef.current.push(timeout);
    });
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

        {/* Pass speed and setSpeed to ControlPanel */}
        <ControlPanel
          handleSort={handleSort}
          algorithmType="sort"
          speed={speed}
          setSpeed={setSpeed}
        />

        <Logtracker logMsg={logMsg} />
      </div>
    </div>
  );
}

export default InsertionSort;
