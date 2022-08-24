
import { generatePath } from "react-router";

const routes = {
  LOGIN: {
    id: "LOGIN",
    path: "/",
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
    path: "/recipe/:id",
  },
  RECIPE_CREATE: {
    id: "RECIPE_CREATE",
    path: "/add-new",
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
  return generatePath(toPath.path, params);
}

export { routes, pathGenWithParams };