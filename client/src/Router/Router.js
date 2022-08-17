import React from "react";
import { Route, Routes } from "react-router-dom";

import { routes } from "./routes";

import Categories from "../Pages/Categories";
import Recipes from "../Pages/Recipes";
import ProtectedRoute from "./Protected";
import RecipeDetails from "../Pages/RecipeDetails";
import RecipeCreate from "../Pages/RecipeCreate";

const Router = () => {
  return (
    <Routes>
      <Route
        path={routes.CATEGORIES.path}
        element={
          <ProtectedRoute>
            <Categories />
          </ProtectedRoute>
        }
      />
      <Route
        path={routes.RECIPES.path}
        element={
          <ProtectedRoute>
            <Recipes />
          </ProtectedRoute>
        }
      />
      <Route
        path={routes.RECIPE_DETAILS.path}
        element={
          <ProtectedRoute>
            <RecipeDetails />
          </ProtectedRoute>
        }
      />
      <Route
        path={routes.RECIPE_CREATE.path}
        element={
          <ProtectedRoute>
            <RecipeCreate />
          </ProtectedRoute>
        }
      />
    </Routes>
  );
};

export default Router;