import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";

import "bootstrap/dist/css/bootstrap.min.css";
import { Provider } from "react-redux";
import { BrowserRouter } from "react-router-dom";
import configureStore from "./data/configureStore";
import { ROUTE_SITE_ROOT } from "./data/constants/routenames";
import { Router } from "react-router-dom";
import History from "./components/controls/History";
import { loadUser } from "./data/services/actionlist/authAction";

configureStore.dispatch(loadUser())

const app = (
  <Provider store={configureStore}>
    <BrowserRouter basename={ROUTE_SITE_ROOT}>
      <div>
        <Router history={History}>
          <App />
        </Router>
      </div>
    </BrowserRouter>
  </Provider>
);

document.addEventListener("DOMContentLoaded", () => {
  ReactDOM.render(
    app,
    document.body.appendChild(document.createElement("div"))
  );
});
