import React from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav>
      <div className="NavbarList">
        <Link to="/create" className="NavbarListItem">
          <div>Create</div>
        </Link>
        <Link to="/load" className="NavbarListItem">
          <div>Load example</div>
        </Link>
        <Link to="/algorithm" className="NavbarListItem">
          <div>Algorithm</div>
        </Link>
        <Link to="/" className="NavbarListItem">
          <div>About</div>
        </Link>
      </div>
    </nav>
  );
};

export default Navbar;
