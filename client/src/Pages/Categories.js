import React, { useEffect, useState } from "react";

import { Box, Button, Typography } from "@mui/material";

import { list } from "../Service/Categories";
import classes from "./Categories.module.css";
import CategoriesList from "../Components/Categories/CategoriesList";

const Categories = () => {
  const [categories, setCategories] = useState([]);
  const [shown, setShown] = useState(10);

  useEffect(() => {
    list(shown, (res) => {
      setCategories(res.data);
    });
  }, [shown]);

  const showMoreHandler = () => {
    setShown((prevShown) => prevShown + 10);
  };

  return (
    <Box className={classes.box}>
      <Typography className={classes.title} variant="h4">Categories</Typography>
      <CategoriesList categories={categories} />
      {categories.length >= shown ? (
         <Button onClick={showMoreHandler} className={classes.button}>Show more</Button>
      ) : (
        ""
      )}
    </Box>
  );
};

export default Categories;
