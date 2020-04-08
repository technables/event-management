import axios from "axios";
import { decodedToken } from "../../utility/tokenHelper";
import {
  SUCCESS,
  WARNING,
  ERROR,
  LOGIN_SUCCESS,
  USER_LOADING,
  USER_LOADED,
  LOGIN_FAILURE,
  LOGOUT_SUCCESS,
} from "../../constants/messagetype";
import { ShowMessage } from "../../messagehelper/showmessage";

import EndPoints from "../../endpoints";

export const login = (userInfo) => (dispatch) => {
  // headers
  const config = {
    headers: {
      "Content-Type": "application/json",
      ClientCode: "event-management",
    },
  };

  const body = JSON.stringify(userInfo);

  const GeneralAPI = EndPoints.GeneralAPI;

  axios
    .post(GeneralAPI.USER_LOGIN, body, config)
    .then((res) => {
      console.log(res.data);
      dispatch({ type: LOGIN_SUCCESS, payload: res.data });
      ShowMessage(SUCCESS, "User logged in successfully.");
    })
    .catch((err) => {
      console.log(err);
      //dispatch({ type: LOGIN_FAIL });
      ShowMessage(ERROR, "Cannot login current user. Please try again.");
    });
};

export const loadUser = () => (dispatch, getState) => {
  // user loading
  dispatch({ type: USER_LOADING });
  // get token from state
  const token = getState().authReducer.token;
  // if token, add header to config
  if (token) {
    let userInfo = decodedToken();
    dispatch({ type: USER_LOADED, payload: userInfo });
  } else {
    dispatch({ type: LOGIN_FAILURE });
  }
};

export const logout = () => (dispatch, getState) => {
  // headers
  const config = {
    headers: {
      "Content-Type": "application/json",
    },
  };

  // get token from state
  const token = getState().authReducer.token;

  dispatch({ type: LOGOUT_SUCCESS });

  // if token, add header to config
  // if (token) {
  //   config.headers["Authorization"] = `Bearer ${token}`;
  // }

  // axios
  //   .post("/api/user/logout", null, config)
  //   .then((res) => {
  //     dispatch({ type: LOGOUT_SUCCESS });
  //     notifySuccess("User logged out successfully.");
  //   })
  //   .catch((err) => {
  //     console.log(err);
  //     notifyError("Failed to logout user. Please try again.");
  //   });
};
