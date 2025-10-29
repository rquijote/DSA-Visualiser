import { useState } from "react";
import type { Log } from "../Interfaces"
import React from "react";
import { TransformWrapper, TransformComponent } from "react-zoom-pan-pinch";

function BubbleSort() {
    const [list, setList] = useState([1, 5, 8, 9, 2, 8, 5]);
    const [logs, setLogs] = useState<Log[]>([]);

    const handleSort = async () => {
        const response = await fetch("/api/sort/bubble", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(list)
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
        <div>
            <h1>Bubble Sort</h1>
            <button onClick={handleSort}>Sort</button>
            <div className="list-div">{list.map((number) => {
                return <p>{number}</p>
            })}</div>
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
    )
}

export default BubbleSort