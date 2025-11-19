import { useState, useRef, useEffect } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import ControlPanel from "../components/ControlPanel";
import Logtracker from "../components/LogTracker";

function MergeSort() {
  const list = [5, 2, 9, 2, 8, 1, 5, 14];
  const [logMsg, setLogMsg] = useState<string[]>([]);
  const [allLogs, setAllLogs] = useState<Log[]>([{ list, msg: "Initial list" }]);
  const [highlight, setHighlight] = useState<number[]>();
  const sortingRef = useRef<HTMLDivElement>(null);
  const logRef = useRef<HTMLDivElement>(null);

  const timeoutsRef = useRef<number[]>([]);

  const handleSort = async () => {
    const response = await fetch("/api/sort/merge", {
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
      const updatedLogs = prev.filter((log) => (log.extras?.depth ?? 0) < newDepth);
      return [...updatedLogs, newLog];
    });
  }

  function startVisualiser(data: Log[]) {
    // Stop any existing animations
    timeoutsRef.current.forEach(clearTimeout);
    timeoutsRef.current = [];

    // Reset state including initial list
    setAllLogs([{ list, msg: "Initial list" }]);
    setHighlight([]);
    setLogMsg([]);

    for (let i = 0; i < data.length; i++) {
      const timeout = setTimeout(() => {
        processLog(data[i]);
        setHighlight(data[i].extras?.highlight || []);
        setLogMsg((prev) => [...prev, data[i].msg]);
      }, i * 1500);

      timeoutsRef.current.push(timeout);
    }
  }

  useEffect(() => {
    if (sortingRef.current) {
      sortingRef.current.scrollTop = sortingRef.current.scrollHeight;
    }
  }, [allLogs]);

  useEffect(() => {
    if (logRef.current) {
      logRef.current.scrollTop = logRef.current.scrollHeight;
    }
  }, [logMsg]);

  return (
    <div className="container">
      <div className="visualiser-container">
        <h1>Merge Sort</h1>
        <TransformWrapper>
          <TransformComponent>
            <div ref={sortingRef} className="sorting-wrapper-merge-sort">
              {allLogs.map((log, logIdx) => {
                const isBottomRow = logIdx === allLogs.length - 1;
                return (
                  <div className="sorting-div-merge-sort" key={logIdx}>
                    {log.list.map((number, index) => (
                      <div
                        key={index}
                        className={`sorting-numbox ${
                          highlight?.includes(index) && isBottomRow ? "highlight" : ""
                        }`}
                      >
                        {number}
                      </div>
                    ))}
                  </div>
                );
              })}
            </div>
          </TransformComponent>
        </TransformWrapper>
        <ControlPanel handleSort={handleSort} algorithmType="sort" />
        <Logtracker logMsg={logMsg} />
      </div>
    </div>
  );
}

export default MergeSort;
