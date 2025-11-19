import { useState, useRef } from "react";
import type { Log, SearchRequest } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import ControlPanel from "../components/ControlPanel";
import Logtracker from "../components/LogTracker";

function BinarySearch() {
  const list = [2, 5, 8, 11, 13, 15, 17, 20, 22, 23];
  const [logMsg, setLogMsg] = useState<string[]>([]);
  const [currentList, setCurrentList] = useState<number[]>(list);
  const [highlight, setHighlight] = useState<number[]>();
  const [targetNum, setTargetNum] = useState<number>(0);
  const timeoutsRef = useRef<number[]>([]);

  const searchRequest: SearchRequest = { list, target: targetNum };

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

  function startVisualiser(data: Log[]) {
    // Clear previous timeouts
    timeoutsRef.current.forEach(clearTimeout);
    timeoutsRef.current = [];
    setCurrentList(list);
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
        <h1>Binary Search</h1>
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
        <ControlPanel
          algorithmType="search"
          handleSearch={handleSearch}
          setTargetNum={setTargetNum}
        />
        <Logtracker logMsg={logMsg} />
      </div>
    </div>
  );
}

export default BinarySearch;
