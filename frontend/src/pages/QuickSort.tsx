import { useState, useRef, useEffect } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import ControlPanel from "../components/ControlPanel";
import Logtracker from "../components/LogTracker";

function QuickSort() {
  const list = [5, 2, 9, 2, 8, 1, 5, 4];
  const [logMsg, setLogMsg] = useState<string[]>([]);
  const [allLogs, setAllLogs] = useState<Log[]>([{ list, msg: "" }]);
  const [highlight, setHighlight] = useState<number[]>();
  const [alertHighlight, setAlertHighlight] = useState<number[]>();
  const [bgHighlight, setBgHighlight] = useState<number[]>();
  const sortingRef = useRef<HTMLDivElement>(null);
  const [speed, setSpeed] = useState(1000);

  const timeoutsRef = useRef<number[]>([]);

  const handleSort = async () => {
    const response = await fetch("/api/sort/quick", {
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

  function processLog(newLog: Log) {
    setAllLogs((prev) => {
      const newDepth = newLog.extras?.depth ?? 0;
      const updatedLogs = prev.filter(
        (log) => (log.extras?.depth ?? 0) < newDepth
      );
      return [...updatedLogs, newLog];
    });
  }

  function startVisualiser(data: Log[]) {
    timeoutsRef.current.forEach(clearTimeout);
    timeoutsRef.current = [];

    setAllLogs([]);
    setHighlight([]);
    setAlertHighlight([]);
    setBgHighlight([]);
    setLogMsg([]);

    for (let i = 0; i < data.length; i++) {
      const timeout = setTimeout(() => {
        processLog(data[i]);
        setHighlight(data[i].extras?.highlight || []);
        setAlertHighlight(data[i].extras?.alertHighlight || []);
        setBgHighlight(data[i].extras?.bgHighlight || []);
        setLogMsg((prev) => [...prev, data[i].msg]);
      }, i * speed);

      timeoutsRef.current.push(timeout);
    }
  }

  useEffect(() => {
    if (sortingRef.current) {
      sortingRef.current.scrollTop = sortingRef.current.scrollHeight;
    }
  }, [allLogs]);

  return (
    <div className="container">
      <div className="visualiser-container">
        <h1>Quick Sort</h1>
        <TransformWrapper>
          <TransformComponent>
            <div ref={sortingRef} className="sorting-wrapper-merge-sort">
              {allLogs.map((log, logIdx) => {
                const isBottomRow = logIdx === allLogs.length - 1;
                return (
                  <div className="sorting-div-merge-sort" key={logIdx}>
                    {log.list.map((number, index) => {
                      const isHighlight =
                        highlight?.includes(index) && isBottomRow;
                      const isAlert =
                        alertHighlight?.includes(index) && isBottomRow;
                      const isBg = bgHighlight?.includes(index) && isBottomRow;

                      return (
                        <div
                          key={index}
                          className={`sorting-numbox ${
                            isAlert
                              ? "alert-highlight"
                              : isHighlight
                              ? "highlight"
                              : isBg
                              ? "bg-highlight"
                              : ""
                          }`}
                        >
                          {number}
                        </div>
                      );
                    })}
                  </div>
                );
              })}
            </div>
          </TransformComponent>
        </TransformWrapper>
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

export default QuickSort;
