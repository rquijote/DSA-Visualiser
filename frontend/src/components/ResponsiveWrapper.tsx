import { useState, useEffect } from "react";

interface ResponsiveWrapperProps {
  children: React.ReactNode;
  minWidth?: number;
}

// If page is smaller than the visualiser size.
export default function ResponsiveWrapper({ children, minWidth = 705 }: ResponsiveWrapperProps) {
  const [isTooSmall, setIsTooSmall] = useState(window.innerWidth < minWidth);

  useEffect(() => {
    const handleResize = () => {
      setIsTooSmall(window.innerWidth < minWidth);
    };

    window.addEventListener("resize", handleResize);
    return () => window.removeEventListener("resize", handleResize);
  }, [minWidth]);

  if (isTooSmall) {
    return (
      <div style={{ textAlign: "center", padding: "2rem", color: "red" }}>
        Please expand your screen to see visualiser properly.
      </div>
    );
  }

  return <>{children}</>;
}
