import "../styles/dropdownButton.css"

function DropdownContent({children, open}: {children: React.ReactElement, open: boolean}) {
    return <div className={`dropdown-content ${open ? "content-open" : ""}`}>{children}</div>
}

export default DropdownContent