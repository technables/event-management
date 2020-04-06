import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";

import "bootstrap/dist/css/bootstrap.min.css";
import { Provider } from "react-redux";
import { BrowserRouter } from "react-router-dom";
import configureStore from "./data/configureStore";
import { ROUTE_SITE_ROOT } from "./data/constants/routenames";

const app = (
  <Provider store={configureStore}>
    <BrowserRouter basename={ROUTE_SITE_ROOT}>
      <div>
        <App />
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
