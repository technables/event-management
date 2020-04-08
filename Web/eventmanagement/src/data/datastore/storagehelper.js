

export function SaveDataToStore(key, value) {
  
    if (value) {
      value =  JSON.stringify(value);
      localStorage.setItem(key, value);
    }
  }
  
  export function GetDataFromStore(key) {
    var data = localStorage.getItem(key);
    try {
      data = data ? JSON.parse(data) : null;
    } catch (error) {
      data = null;
    }
  
    return data;
  }
  
  export function RemoveDataFromStore(key) {
    if (localStorage.getItem(key) !== null) localStorage.removeItem(key);
  }
  
  