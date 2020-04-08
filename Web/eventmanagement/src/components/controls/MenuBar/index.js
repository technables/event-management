import React from "react";
import { connect, useSelector } from "react-redux";

import { NavLink } from "react-router-dom";
import {
  ROUTE_SITE_ROOT,
  ROUTE_SITE_EVENTS,
  ROUTE_ADMIN_DASHBOARD,
  ROUTE_ADMIN_SETTINGS,
  ROUTE_MERCHANT_DASHBOARD,
  ROUTE_MERCHANT_PROFILE,
  ROUTE_USER_DASHBOARD,
  ROUTE_USER_PROFILE,
} from "../../../data/constants/routenames";

const MenuBar = () => {
  const auth = useSelector((state) => state.authReducer);


  const guestLinks = () => {
    return (
      <ul className="navbar-nav">
        <li className="nav-item active">
          <NavLink className="nav-link" to={ROUTE_SITE_ROOT}>
            Home 
          </NavLink>
        </li>
        <li className="nav-item">
          <NavLink className="nav-link" to={ROUTE_SITE_EVENTS}>
            Events
          </NavLink>
        </li>
      </ul>
    );
  };

  const adminLinks = () => {
    return (
      <ul className="navbar-nav ">
        <li className="nav-item">
          <NavLink className="nav-link" to={ROUTE_ADMIN_DASHBOARD}>
            Dashboard
          </NavLink>
        </li>
        <li className="nav-item">
          <NavLink className="nav-link" to={ROUTE_ADMIN_SETTINGS}>
            Settings
          </NavLink>
        </li>
      </ul>
    );
  };

  const merchantLinks = () => {
    return (
      <ul className="navbar-nav">
        <li className="nav-item">
          <NavLink className="nav-link" to={ROUTE_MERCHANT_DASHBOARD}>
            Dashboard
          </NavLink>
        </li>
        <li className="nav-item">
          <NavLink className="nav-link" to={ROUTE_MERCHANT_PROFILE}>
            Profile
          </NavLink>
        </li>
      </ul>
    );
  };

  const userLinks = () => {
    return (
      <ul className="navbar-nav">
        <li className="nav-item">
          <NavLink className="nav-link" to={ROUTE_USER_DASHBOARD}>
            Dashboard
          </NavLink>
        </li>
        <li className="nav-item">
          <NavLink className="nav-link" to={ROUTE_USER_PROFILE}>
            Profile
          </NavLink>
        </li>
      </ul>
    );
  };

  const getAuthenticatedLinks = () => {
    switch (auth.userRole) {
      case "admin":
       return adminLinks();
      case "merchant":
        return  merchantLinks();
        
      case "user":
        return userLinks();
        

      default:
        break;
    }
  };

  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container">
        <button
          className="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarColor02"
          aria-controls="navbarColor02"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarColor02">
          {guestLinks()}
          {auth.isAuthenticated ? getAuthenticatedLinks() : ""}
        </div>
      </div>
    </nav>
  );
};

export default MenuBar;
