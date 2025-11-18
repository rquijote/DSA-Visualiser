import "../styles/dropdownButton.css"

function DropdownContent({children, open}: {children: React.ReactNode, open: boolean}) {
    if (!open) return null;
    return <div className={`dropdown-content ${open ? "content-open" : ""}`}>{children}</div>
}

export default DropdownContent