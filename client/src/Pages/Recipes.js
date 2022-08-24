import React, { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router-dom";
import { listByCategory, search } from "../Service/Recipes";

import { Button, Typography } from "@mui/material";
import { Box } from "@mui/system";
import SearchBar from "material-ui-search-bar"

import RecipesList from "../Components/Recipes/RecipesList";
import classes from "./Recipes.module.css";
import { pathGenWithParams, routes } from "../Router/routes";


const Recipes = () => {
  const params = useParams();
  const categoryId = params.id;
  const history = useHistory();

  const [recipes, setRecipes] = useState([]);
  const [initRecipes, setInitRecipes] = useState([]);
  const [shown, setShown] = useState(10);
  const [searched, setSearched] = useState("");

  useEffect(() => {
    if (searched === "") {
      listByCategory(categoryId, shown, (res) => {
        setRecipes(res.data);
        setInitRecipes(res.data);
      });
    } else {
      searchRequest(searched);
    }
  }, [shown]);

  const showMoreHandler = () => {
    setShown((prevShown) => prevShown + 10);
  };

  const searchRequest = (searchTerm) => {
    search({term: searchTerm, index: 10, id: categoryId}, (res) => {
      setShown(10);
      setRecipes(res.data);
      setSearched(searchTerm);
    });
  }

  const handleRequestSearch = (searchedVal) => {
     searchRequest(searchedVal);
  };

  const handleCancelSearch = () => {
      const values = initRecipes;
      setSearched("");
      setRecipes(values);
  };

  const handleAddNewRecipe = () => {
    history.push(pathGenWithParams(routes.RECIPE_CREATE))
  }

  return (
    <Box className={classes.box}>
      <Typography className={classes.title} variant="h4">Recipes</Typography><Button onClick={handleAddNewRecipe}>Add new recipe</Button>
      <SearchBar value={searched} onRequestSearch={(val) => handleRequestSearch(val)} onCancelSearch={handleCancelSearch}/>
      <RecipesList recipes={recipes}/>
      {recipes.length >= shown ? (
        <Button onClick={showMoreHandler} className={classes.button}>Show more</Button>
      ) : (
        ""
      )}
    </Box>
  );
};

export default Recipes;
