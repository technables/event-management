import React, { Component, useState } from "react";
import "./index.css";

const LoginControl = (props) => {
  const { handleClick } = props;

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  return (
    
    <div className="row login-container">
      <div className="col-sm-9 col-md-7 col-lg-5 mx-auto">
        <div className="card card-signin my-5">
          <div className="card-body align-items-start">
            <h5 className="card-title text-center font-weight-bold mb-lg-5">Login</h5>
            <form className="form-signin">
              <div className="form-label-group">
                <input
                  type="text"
                  id="username"
                  className="form-control"
                  placeholder="Username"
                  required
                  autoFocus
                  onChange={(e) => setUsername(e.target.value)}
                />
                <label htmlFor="username">Username</label>
              </div>

              <div className="form-label-group">
                <input
                  type="password"
                  id="inputPassword"
                  className="form-control"
                  placeholder="Password"
                  required
                  onChange={(e) => setPassword(e.target.value)}
                />
                <label htmlFor="inputPassword">Password</label>
              </div>

              <input
                type="button"
                className="btn btn-lg btn-primary btn-block text-uppercase"
                value="Sign In"
                onClick={handleClick.bind(this, username, password)}
              />
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default LoginControl;
