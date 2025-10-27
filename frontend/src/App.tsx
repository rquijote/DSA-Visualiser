import { useState } from "react";

interface Log {
    list: number[];
    msg: string;
}

function App() {
    const [input, setInput] = useState("");
    const [logs, setLogs] = useState<Log[]>([]);

    const handleSort = async () => {
        // Convert comma-separated string to number array
        const numbers = input.split(",").map(n => parseInt(n.trim(), 10)).filter(n => !isNaN(n));

        const response = await fetch("/api/sort/bubble", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(numbers)
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
            <input
                type="text"
                value={input}
                onChange={e => setInput(e.target.value)}
                placeholder="Enter numbers comma-separated"
            />
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
  )
}

export default App
