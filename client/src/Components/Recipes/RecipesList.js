import React from "react";
import { useHistory } from "react-router-dom";

import { List, ListItem, ListItemText } from "@mui/material";

import { pathGenWithParams, routes } from "../../Router/routes";
import classes from "./RecipesList.module.css";


const RecipesList = (props) => {
    const history = useHistory();

    const handleShowDetailed = (id) => {
        history.push(pathGenWithParams(routes.RECIPE_DETAILS, {id: id}))
    };

    return (
        <List className={classes.list}>
            {props.recipes.map((item) => {
                return (
                    <ListItem key={item.id} button={true} className={classes.item} onClick={() => {handleShowDetailed(item.id)}}>
                        <ListItemText primary={item.title} secondary={`Price: ${item.price}`}/>
                    </ListItem>
                )
            })}
        </List>
    );
};

export default RecipesList;