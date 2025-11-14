import { useState } from "react";
import type { Log, SearchRequest } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import Sidebar from "../components/Sidebar";

function BinarySearch() {
  const [logMsg, setLogMsg] = useState<string[]>();
  const list = [2, 5, 8, 11, 13, 15, 17, 20, 22, 23];
  const [currentList, setCurrentList] = useState<number[]>(list);
  const [highlight, setHighlight] = useState<number[]>();

  const searchRequest: SearchRequest = {list: list, target: 17};

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
    for (let i = 0; i < data.length; i++) {
      setTimeout(() => {
        setCurrentList(data[i].list);
        setHighlight(data[i].extras?.highlight || []);
        setLogMsg(prev => [...(prev || []), data[i].msg]);
      }, i * 1000);
    }
  }

  return (
    <div className="container">
      <Sidebar />
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
        <button onClick={handleSearch}>Search</button>
        <div className="log-tracker">
          {logMsg?.map((msg, idx) => (
            <p key={idx}>{msg}</p>
          ))}
        </div>
      </div>
    </div>
  );
}

export default BinarySearch;
