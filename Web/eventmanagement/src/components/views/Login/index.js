import React, { Component } from "react";
import { useDispatch, useSelector } from "react-redux";

import Logincontrol from "../../controls/LoginControl";
import { login } from "../../../data/services/actionlist/authAction";
import { Redirect } from 'react-router-dom';
import {
  ROUTE_ADMIN_DASHBOARD,
  ROUTE_USER_DASHBOARD,
  ROUTE_MERCHANT_DASHBOARD,
  ROUTE_SITE_ROOT,
} from "../../../data/constants/routenames";

const Login = () => {
  const dispatch = useDispatch();
  const auth = useSelector((state) => state.authReducer);

  const handleClick = (username, password) => {
    if (username && password) {
      let obj = {
        UserName: username,
        Password: password,
      };
      dispatch(login(obj));
    }
  };

  if (auth.isAuthenticated) {
    switch (auth.user.role) {
      case "admin":
        return <Redirect to={ROUTE_ADMIN_DASHBOARD} />;
      case "merchant":
        return <Redirect to={ROUTE_MERCHANT_DASHBOARD} />;

      case "user":
        return <Redirect to={ROUTE_USER_DASHBOARD} />;

      default:
        return <Redirect to={ROUTE_SITE_ROOT} />;
    }
  }

  return <Logincontrol handleClick={handleClick} />;
};

export default Login;
