import React, { useEffect, useState } from "react";
import { Typography } from "@mui/material";

import RecipeCreateForm from "../Components/Recipes/RecipeCreateForm";
import { list } from "../Service/Categories";

const RecipeCreate = () => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    list(null, (res) => {
      setCategories(res.data);
    });
  }, []);

  return (
    <div>
      <Typography variant="h5">Add new recipe</Typography>
      <RecipeCreateForm categories={categories}/>
    </div>
  );
};

export default RecipeCreate;
