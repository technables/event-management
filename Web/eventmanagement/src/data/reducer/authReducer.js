import {
  GetDataFromStore,
  SaveDataToStore,
  RemoveDataFromStore,
} from "../datastore/index";
import {
  LOGIN_SUCCESS,
  LOGIN_FAILURE,
  AUTH_ERROR,
  LOGOUT_SUCCESS,
  USER_LOADED,
  USER_LOADING,
} from "../constants/messagetype";

const initialState = {
  token: GetDataFromStore("token"),
  isAuthenticated: false,
  isLoading: false,
  user: null,
  userRole: "",
};

export default function (state = initialState, action) {
  switch (action.type) {
    case USER_LOADING: {
      return {
        ...state,
        isLoading: true,
      };
    }

    case USER_LOADED: {
      return {
        ...state,
        isAuthenticated: true,
        isLoading: false,
        userRole: action.payload.role,
        user: action.payload,
      };
    }

    case LOGIN_SUCCESS: {
      SaveDataToStore("token", action.payload.token);
      return {
        ...state,
        user: action.payload,
        token: action.payload.token,
        isAuthenticated: true,
        userRole: action.payload.role,
        isLoading: false,
      };
    }

    case AUTH_ERROR:
    case LOGIN_FAILURE:
    case LOGOUT_SUCCESS: {
      RemoveDataFromStore("token");
      return {
        ...state,
        token: null,
        user: null,
        isAuthenticated: false,
        isLoading: false,
      };
    }

    default: {
      return state;
    }
  }
}
