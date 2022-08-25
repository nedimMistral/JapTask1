import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import Recipe from "../Components/Recipes/Recipe";
import { detailed } from "../Service/Recipes";
import classes from "./RecipeDetails.module.css";

const RecipeDetails = (props) => {
  const [recipeDetails, setRecipeDetails] = useState(null);
  const params = useParams();
  const id = params.id;

  useEffect(() => {
    detailed(id, (res) => {
      setRecipeDetails(res.data);
    });
  }, []);

  return <div className={classes.card}>
    {(recipeDetails !== null) && <Recipe recipe={recipeDetails}/>}
  </div>;
};

export default RecipeDetails;
