import { useState } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import Sidebar from "../components/Sidebar";

function MergeSort() {
  const [logMsg, setLogMsg] = useState<string[]>();
  const list = [1, 5, 8, 9, 2, 4, 11, 6];
  //const [currentList, setCurrentList] = useState<number[]>(list);
  //const [highlight, setHighlight] = useState<number[]>();
  const [allLists, setAllLists] = useState<number[][][]>([]);

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

  function structureAllLists(data: Log[]) {
    const newAllLists: number[][][] = [];
    const originalLength = data[0].list.length;

    for (const log of data) {
      // rowIndex is bias rounded down to the nearest int using the original 
      // length divided by the log.list.length
      const rowIndex = Math.floor(Math.log2(originalLength/ log.list.length));

      if (!newAllLists[rowIndex]) {
        newAllLists[rowIndex] = [];
      }

      newAllLists[rowIndex].push(log.list);
    }
    return newAllLists;
  } 

  function startVisualiser(data: Log[]) {
    const structured = structureAllLists(data);
    console.log(structured);
    setAllLists(structured);

    for (let i = 0; i < data.length; i++) {
      setTimeout(() => {
        setLogMsg((prev) => [...(prev || []), data[i].msg]);
      }, i * 1000);
    }
  }

  function printAllLists() {
    return allLists.map((row, rowIndex) => (
      <div
        key={rowIndex}
        className="merge-sort-row"
        style={{ gridTemplateColumns: `repeat(${row.length}, 1fr)` }}
      >
        {row.map((subArray, subIndex) => (
          <div key={subIndex} className="sorting-div merge-sort">
            {subArray.map((num, numIndex) => (
              <div key={numIndex} className="sorting-numbox">
                {num}
              </div>
            ))}
          </div>
        ))}
      </div>
    ));
  }

  return (
    <div className="container">
      <Sidebar />
      <div className="visualiser-container">
        <h1>Merge Sort</h1>
        <TransformWrapper>
          <TransformComponent>
            <div
              className="sorting-wrapper merge-sort"
              style={{ gridTemplateRows: `repeat(${allLists.length}, 1fr)` }}
            >
              {printAllLists()}
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

export default MergeSort;
