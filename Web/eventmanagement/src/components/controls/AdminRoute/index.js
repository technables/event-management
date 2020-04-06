import React from "react";
import { Route, Redirect } from "react-router-dom";
import {
  ROUTE_SITE_LOGIN,
  ROUTE_SITE_UNAUTHORIZED,
} from "../../../data/constants/routenames";
import { useSelector, useDispatch } from "react-redux";

function AdminRoute({ component: Component, ...rest }) {
  const auth = useSelector((state) => state.authReducer);

  return (
    <Route
      exact
      {...rest}
      render={(props) => {
        if (auth.isLoading) {
          return <h2>Loading...</h2>;
        } else if (!auth.isAuthenticated) {
          return <Redirect to={ROUTE_SITE_LOGIN} />;
        } else if (auth.userRole !== "admin") {
          return <Redirect to={ROUTE_SITE_UNAUTHORIZED} />;
        } else {
          return <Component {...props} />;
        }
      }}
    />
  );
}

export default AdminRoute;
