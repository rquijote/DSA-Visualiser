import { useState } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import Sidebar from "../components/Sidebar";
import Header from "../components/Header";

function BubbleSort() {
  const [logMsg, setLogMsg] = useState<string[]>();
  const list = [1, 5, 8, 9, 2, 4, 11, 6];
  const [currentList, setCurrentList] = useState<number[]>(list);
  const [highlight, setHighlight] = useState<number[]>();

  const handleSort = async () => {
    const response = await fetch("/api/sort/bubble", {
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
        setCurrentList(data[i].list);
        setHighlight(data[i].extras?.highlight || []);
        setLogMsg((prev) => [...(prev || []), data[i].msg]);
      }, i * 1000);
    }
  }

  return (
    <div>
      <Header />
      <div className="container">
        <div className="content-container">
          <Sidebar />
          <div className="visualiser-container">
            <h1>Bubble Sort</h1>
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
            <button onClick={handleSort}>Sort</button>
            <div className="log-tracker">
              {logMsg?.map((msg, idx) => (
                <p key={idx}>{msg}</p>
              ))}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default BubbleSort;
