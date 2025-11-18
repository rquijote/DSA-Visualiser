import DropdownButton from "./DropdownButton";
import DropdownContent from "./DropdownContent";
import { useState } from "react";

function Dropdown({
  buttonText,
  content,
}: {
  buttonText: string;
  content: React.ReactNode;
}) {
  const [open, setOpen] = useState(false);

  function toggleDropdown() {
    setOpen((open) => !open);
  }

  return (
    <div className="dropdown">
      <DropdownButton toggle={toggleDropdown} open={open}>
        {buttonText}
      </DropdownButton>
      <DropdownContent open={open}>{content}</DropdownContent>
    </div>
  );
}

export default Dropdown;
