import React from "react";
import "./App.css";
import { connect } from "react-redux";
import { Switch, Route } from "react-router-dom";

import MenuBar from "./components/controls/MenuBar";
import Header from "./components/controls/Header";

import {
  DefaultRoutes,
  AdminRoutes,
  UserRoutes,
  MerchantRoutes,
} from "./routes/index";

import AdminRoute from "./components/controls/AdminRoute";
import UserRoute from "./components/controls/UserRoute";
import MerchantRoute from "./components/controls/MerchantRoute";

class App extends React.Component {
  render() {
    const dRoute = DefaultRoutes.map((route, index) => {
      return route.component ? (
        <Route
          key={index}
          path={route.path}
          exact={route.exact}
          name={route.name}
          render={(props) => <route.component {...props} />}
        />
      ) : null;
    });

    const aRoutes = AdminRoutes.map((route, index) => {
      return route.component ? (
        <AdminRoute
          key={index}
          path={route.path}
          exact={route.exact}
          name={route.name}
          component={route.component}
        />
      ) : null;
    });

    const mRoutes = MerchantRoutes.map((route, index) => {
      return route.component ? (
        <MerchantRoute
          key={index}
          path={route.path}
          exact={route.exact}
          name={route.name}
          component={route.component}
        />
      ) : null;
    });

    const uRoutes = UserRoutes.map((route, index) => {
      return route.component ? (
        <UserRoute
          key={index}
          path={route.path}
          exact={route.exact}
          name={route.name}
          component={route.component}
        />
      ) : null;
    });

    return (
      <Switch>
        <React.Fragment>
          <div className="container">
            <Header />
            <MenuBar />
            {dRoute}
            {aRoutes}
            {mRoutes}
            {uRoutes}
          </div>
        </React.Fragment>
      </Switch>
    );
  }
}

function mapStateToProps(state) {
  return state;
}

App = connect(mapStateToProps)(App);

export default App;
