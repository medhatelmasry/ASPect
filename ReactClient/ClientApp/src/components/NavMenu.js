import React from "react";
import { Container, Navbar, NavbarBrand, NavItem, NavLink } from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";

const NavMenu = () => {
  const onLogOut = () => {
    console.log("logged out successfully. 'logout' logic will be called here.");
    localStorage.clear();
  };

  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        light
      >
        <Container>
          <NavbarBrand tag={Link} to="/">
            Student Portal
          </NavbarBrand>

          <ul className="navbar-nav flex-grow">
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">
                Home
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/login">
                Login
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/signup">
                Sign Up
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">
                <p onClick={onLogOut}>Log out</p>
              </NavLink>
            </NavItem>
          </ul>
        </Container>
      </Navbar>
    </header>
  );
};

export default NavMenu;
