import React from "react";
import { useHistory } from "react-router-dom";

import { List, ListItem } from "@mui/material";

import { pathGenWithParams, routes } from "../../Router/routes";
import classes from "./CategoriesList.module.css";


const CategoriesList = (props) => {
    const history = useHistory();

    const handleItemClicked = (id) => {
        history.push(pathGenWithParams(routes.RECIPES, { id: id }))
    };

    return (
        <List className={classes.list}>
            {props.categories.map((item) => {
                    return (
                        <ListItem key={item.id} className={classes.item} onClick={() => {handleItemClicked(item.id)}} button={true}>
                            {item.name}
                        </ListItem>
                    )
                })}
        </List>
    )
}

export default CategoriesList;