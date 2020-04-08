import React, { Component } from "react";
import Logo from "../../../logo.svg";

import { connect, useSelector, useDispatch } from "react-redux";
import "./header.css";
import { ROUTE_SITE_LOGIN } from "../../../data/constants/routenames";
import history from '../History'
import { logout } from "../../../data/services/actionlist/authAction";
const Header = (props) => {
  const logoClick = () => {};

  const dispatch = useDispatch();

  const btnClick = () => {
    history.push(ROUTE_SITE_LOGIN);
  };

  const LogoutClick = () => {
    dispatch(logout());
  };

  const auth = useSelector((state) => state.authReducer);

  return (
    <div className="logo-wrapper flex">
      <div className="row">
        <div className="col-8 logo-container">
          <img
            src={Logo}
            className="logo"
            alt="sageflick"
            onClick={logoClick}
          />
          <span className="h3">Event Management</span>
        </div>
        {!auth.isAuthenticated && (
          <div className="col-4 text-right">
            <span className="btn btn-info" onClick={btnClick}>
              Login
            </span>
          </div>
        )}

        {auth.isAuthenticated && (
          <div className="col-4 text-right align-items-center">
            <div className="row align-items-center">
              <p className="font-italic font-weight-normal col-6 spnUserName">
                Welcome {auth.userRole}
              </p>
              <span className="btn btn-warning " onClick={LogoutClick}>Logout</span>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default Header;
