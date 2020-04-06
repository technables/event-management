const initialState = {
  token: localStorage.getItem("token"),
  isAuthenticated: true,
  isLoading: false,
  user: null,
  userRole: "merchant",
};

export default function (state = initialState, action) {
  switch (action.type) {
    default: {
      return state;
    }
  }
}
