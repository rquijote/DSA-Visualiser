import { useState } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import Sidebar from "../components/Sidebar";

function MergeSort() {
  const [logMsg, setLogMsg] = useState<string[]>();
  const [allLists, setAllLists] = useState<number[][]>([]);

  const handleSort = async () => {
    const response = await fetch("/api/sort/merge", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
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
        setLogMsg((prev) => [...(prev || []), data[i].msg]);
        // Start from here onwards. 
        // setAllLists((prevLists) => [...prevLists, data[i].list]);
      }, i * 1000);
    }
  }

  return (
    <div className="container">
      <Sidebar />
      <div className="visualiser-container">
        <h1>Merge Sort</h1>
        <TransformWrapper>
          <TransformComponent>
            // Print from here
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
