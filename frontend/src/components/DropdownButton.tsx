import { FaChevronDown, FaChevronUp } from "react-icons/fa";
import "../styles/dropdownButton.css"

function DropdownButton({ children, open, toggle }: { children: React.ReactNode, open: boolean, toggle: () => void}) {
  return (
    <div className={`dropdown-btn ${open ? "button-open" : ""}`} onClick={toggle}>
      {children}
      <span className="toggle-icon">{open ? <FaChevronUp /> : <FaChevronDown />}</span>
    </div>
  );
}

export default DropdownButton;
