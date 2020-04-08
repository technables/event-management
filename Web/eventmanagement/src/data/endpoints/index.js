import {
  ROUTE_API_URL,
  ROUTE_API_LOGIN,
  ROUTE_API_REGISTER,
} from "../constants/apiroutes";

export default {
  GeneralAPI: {
    USER_LOGIN: GenerateGeneralAPI(ROUTE_API_LOGIN),
    USER_REGISTER: GenerateGeneralAPI(ROUTE_API_REGISTER),
  },
};

function GenerateGeneralAPI(uri) {
  return ROUTE_API_URL + "api/v1/general/" + uri;
}
