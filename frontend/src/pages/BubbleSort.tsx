import { useState } from "react";
import type { Log } from "../Interfaces";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";
import "../styles/visualiser.css";
import Sidebar from "../components/Sidebar";

function BubbleSort() {
  //const [list, setList] = useState();
  const [logs, setLogs] = useState<Log[]>([]);
  const list = [1, 5, 8, 9, 2, 8, 11, 6];

  const handleSort = async () => {
    const response = await fetch("/api/sort/bubble", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(list),
    });

    if (response.ok) {
      const data: Log[] = await response.json();
      setLogs(data);
      console.log(data);
    } else {
      console.error("Failed to fetch logs");
    }
  };

  return (
    <div className="container">
      <Sidebar />
        <div className="visualiser-container">
          <h1>Bubble Sort</h1>
          <TransformWrapper>
            <TransformComponent>
              <div className="sorting-wrapper">
                <div className="sorting-div">
                  {list.map((number) => {
                    return <div className="sorting-numbox">{number}</div>;
                  })}
                </div>
              </div>
            </TransformComponent>
          </TransformWrapper>
          <button onClick={handleSort}>Sort</button>
          <div>
            {logs.map((log, idx) => (
              <div key={idx}>
                <div>List: [{log.list.join(", ")}]</div>
                <div>Message: {log.msg}</div>
                <hr />
              </div>
            ))}
          </div>
        </div>
    </div>
  );
}

export default BubbleSort;
