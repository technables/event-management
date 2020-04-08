import cogoToast from "cogo-toast";
import { SUCCESS, WARNING, ERROR } from "../constants/messagetype";

export function ShowMessage(type, msg) {
  var option = {
    position: "top-right",
    heading: type,
    onClick: (hide) => {
      hide(true);
    },
  };

  switch (type) {
    case SUCCESS:
      cogoToast.success(msg, option);
      break;
    case ERROR:
      cogoToast.error(msg, option);
      break;
    case WARNING:
      cogoToast.info(msg, option);
      break;
    default:
      break;
  }
}
