import { useEffect, useRef } from "react";

function Logtracker({ logMsg }: { logMsg: string[] }) {
  const containerRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    if (containerRef.current) {
      containerRef.current.scrollTop = containerRef.current.scrollHeight;
    }
  }, [logMsg]);

  return (
    <div ref={containerRef} className="log-tracker">
      {logMsg?.map((msg, idx) => (
        <p key={idx}>{msg}</p>
      ))}{" "}
    </div>
  );
}

export default Logtracker;
