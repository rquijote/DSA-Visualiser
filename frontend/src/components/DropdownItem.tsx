import "../styles/dropdownButton.css";

function DropdownItem({ children, onClick }: { children: React.ReactNode; onClick: () => void }) {
  return (
    <div className="dropdown-item" onClick={onClick}>
      {children}
    </div>
  );
}

export default DropdownItem;