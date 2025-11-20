import DropdownButton from "./DropdownButton";
import DropdownContent from "./DropdownContent";
import { useState, useEffect, useRef } from "react";

function Dropdown({
  buttonText,
  content,
}: {
  buttonText: string;
  content: (closeDropdown: () => void) => React.ReactNode;
}) {
  const [open, setOpen] = useState(false);

  const dropdownRef = useRef<HTMLDivElement>(null);

  function toggleDropdown() {
    setOpen((open) => !open);
  }

  const closeDropdown = () => setOpen(false);

  useEffect(() => {
    const handler = (e: MouseEvent) => {
      if (dropdownRef.current && !dropdownRef.current.contains(e.target as Node)) {
        setOpen(false);
      }
    };

    document.addEventListener("click", handler);

    return () => {
      document.removeEventListener("click", handler);
    };
  }, [dropdownRef]);

  return (
    <div className="dropdown" ref={dropdownRef}>
      <DropdownButton toggle={toggleDropdown} open={open}>
        {buttonText}
      </DropdownButton>
      <DropdownContent open={open}>{content(closeDropdown)}</DropdownContent>
    </div>
  );
}

export default Dropdown;
