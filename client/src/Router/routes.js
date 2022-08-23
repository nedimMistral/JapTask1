
import { generatePath } from "react-router";

const routes = {
  LOGIN: {
    id: "LOGIN",
    path: "/login",
  },
  CATEGORIES: {
    id: "CATEGORIES",
    path: "/categories",
  },
  RECIPES: {
    id: "RECIPES",
    path: "/recipes/:id",
  },
  RECIPE_DETAILS: {
    id: "RECIPE_DETAILS",
    path: "/recipes/details/:id",
  },
  RECIPE_CREATE: {
    id: "RECIPE_CREATE",
    path: "/recipes/create",
  },
};

function pathGenWithParams(route, params) {
  let toPath;
  if (typeof route.id === "string") {
    toPath = routes[route.id];
  }
  if (!toPath) {
    console.error(
      `Unknown route ${route} !`
    );
    return "#";
  }
  console.log("PARAMS:::: ", params.id);
  return generatePath(toPath.path, params);
}

export { routes, pathGenWithParams };