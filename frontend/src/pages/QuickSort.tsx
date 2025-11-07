import { useState, useRef, useEffect } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import Sidebar from "../components/Sidebar";

function QuickSort() {
  const list = [5, 2, 9, 2, 8, 1, 5, 14];
  const [logMsg, setLogMsg] = useState<string[]>();
  const [allLists, setAllLists] = useState<number[][]>([]);
  const [highlight, setHighlight] = useState<number[]>();
  const sortingRef = useRef<HTMLDivElement>(null);
  const logRef = useRef<HTMLDivElement>(null);

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

  function startVisualiser(data: Log[]) {
    for (let i = 0; i < data.length; i++) {
      setTimeout(() => {
        console.log(data[i]);
        setHighlight(data[i].highlight);
        setAllLists((prev) => [...prev, data[i].list]);
        setLogMsg((prev) => [...(prev || []), data[i].msg]);
      }, i * 2000);
    }
  }

  useEffect(() => {
    if (sortingRef.current) {
      sortingRef.current.scrollTop = sortingRef.current.scrollHeight;
    }
  }, [allLists]);

  useEffect(() => {
    if (logRef.current) {
      logRef.current.scrollTop = logRef.current.scrollHeight;
    }
  }, [logMsg]);

  return (
    <div className="container">
      <Sidebar />
      <div className="visualiser-container">
        <h1>Quick Sort</h1>
        <TransformWrapper>
          <TransformComponent>
            <div ref={sortingRef} className="sorting-wrapper-merge-sort">
              {allLists.map((list, listIdx) => {
                const isBottomRow = listIdx === allLists.length - 1;
                return (
                  <div className="sorting-div-merge-sort" key={listIdx}>
                    {list.map((number, index) => (
                      <div
                        key={index}
                        className={`sorting-numbox ${
                          highlight?.includes(index) && isBottomRow
                            ? "highlight"
                            : ""
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
        <button onClick={handleSort}>Sort</button>
        <div className="log-tracker">
          {logMsg?.map((msg, idx) => (
            <p key={idx}>{msg}</p>
          ))}
        </div>
      </div>
    </div>
  );
}

export default QuickSort;
