import React from "react";

import {
  Typography,
  Card,
  CardContent,
  CardHeader,
  CardMedia,
} from "@mui/material";

import IngredientsTable from "../Ingredients/IngredientsTable";

import classes from "./Recipe.module.css";
import img from "../../Images/ingredients.png";


const Recipe = (props) => {
  return (
    <Card sx={{ minWidth: 680 }}>
      <CardContent>
        <CardHeader
          title={props.recipe.title}
          subheader={`Price: ${props.recipe.price}`}
        />
        <CardMedia component="img" height="190" width="100" image={img} />
      </CardContent>
      <Typography>Ingredients</Typography>
      {props.recipe.ingredients.length > 0 && (
        <IngredientsTable ingredients={props.recipe.ingredients} />
      )}
    <Typography variant="subtitle1" className={classes['description-title']}>Instructions</Typography>
    <Typography variant="body1">{props.recipe.description}</Typography>
    </Card>
  );
};

export default Recipe;
