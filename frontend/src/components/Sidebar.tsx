import "../styles/sidebar.css";

interface SidebarOptions {
  handleSort?: () => void,
  handleSearch?: () => void,
  handleTraverse?: () => void
}

function Sidebar({ handleSort, handleSearch, handleTraverse }: SidebarOptions) {
  return (
    <div className="sidebar-container">
      <div className="sidebar-column">
        {handleSort && <button onClick={handleSort}>Sort</button>}
        {handleSearch && <button onClick={handleSearch}>Search</button>}
        {handleTraverse && <button onClick={handleTraverse}>Traverse</button>}
      </div>
    </div>
  );
}

export default Sidebar
