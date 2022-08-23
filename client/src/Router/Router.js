import React from "react";
import { Switch } from "react-router-dom";

import { routes } from "./routes";

import Categories from "../Pages/Categories";
import Recipes from "../Pages/Recipes";
import Protected from "./Protected";
import RecipeDetails from "../Pages/RecipeDetails";
import RecipeCreate from "../Pages/RecipeCreate";

const Router = () => {
  return (
    <Switch>
      <Protected path={routes.CATEGORIES.path} component={Categories} />
      <Protected path={routes.RECIPES.path} component={Recipes} />
      <Protected path={routes.RECIPE_DETAILS.path} component={RecipeDetails} />
      <Protected path={routes.RECIPE_CREATE.path} component={RecipeCreate} />
    </Switch>
  );
};

export default Router;
