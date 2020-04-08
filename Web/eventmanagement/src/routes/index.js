import Home from "../components/views/Home";
import Login from "../components/views/Login";

import {
  ROUTE_SITE_ROOT,
  ROUTE_SITE_EVENTS,
  ROUTE_ADMIN_DASHBOARD,
  ROUTE_ADMIN_SETTINGS,
  ROUTE_MERCHANT_DASHBOARD,
  ROUTE_MERCHANT_PROFILE,
  ROUTE_USER_DASHBOARD,
  ROUTE_USER_PROFILE,
  ROUTE_SITE_LOGIN,
} from "../data/constants/routenames";

export const DefaultRoutes = [
  {
    path: ROUTE_SITE_ROOT,
    exact: true,
    name: "home",
    component: Home,
  },
  {
    path: ROUTE_SITE_EVENTS,
    exact: true,
    name: "events",
    component: Home,
  },
  {
    path: ROUTE_SITE_LOGIN,
    exact: true,
    name: "login",
    component: Login,
  },
];


export const AdminRoutes = [
  {
    path: ROUTE_ADMIN_DASHBOARD,
    exact: true,
    name: "admin-dashboard",
    component: Home,
  },
  {
    path: ROUTE_ADMIN_SETTINGS,
    exact: true,
    name: "admin-settings",
    component: Home,
  },
];

export const MerchantRoutes = [
  {
    path: ROUTE_MERCHANT_DASHBOARD,
    exact: true,
    name: "merchant-dashboard",
    component: Home,
  },
  {
    path: ROUTE_MERCHANT_PROFILE,
    exact: true,
    name: "merchant-profile",
    component: Home,
  },
];

export const UserRoutes = [
  {
    path: ROUTE_USER_DASHBOARD,
    exact: true,
    name: "user-dashboard",
    component: Home,
  },
  {
    path: ROUTE_USER_PROFILE,
    exact: true,
    name: "user-profile",
    component: Home,
  },
];
