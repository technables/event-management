import React, { Component } from "react";
import Logo from "../../../logo.svg";

import { connect, useSelector } from "react-redux";
import "./header.css";
const Header = () => {
  const logoClick = () => {};

  const btnClick = () => {};

  const LogoutClick = () => {
    const { dispatch, history } = this.props;
    //dispatch(actionList.logout(history));
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
        {!auth.isAuthenticated  && (
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
              <span className="btn btn-warning " >
                Logout
              </span>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default Header;
