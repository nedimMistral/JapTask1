import {
    Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";
import { SelectChangeEvent } from "@mui/material";
import { useState } from "react";
import IngredientsModal from "../Ingredients/IngredientsModal";

import classes from "./RecipeCreateForm.module.css";

const RecipeCreateForm = (props) => {
  const [values, setValues] = useState({
    title: "",
    description: "",
    userId: 0,
    categoryId: 0,
    prepTimeMinutes: 0,
    recipeIngredients: [],
  });

  const [modalOpen, setModalOpen] = useState(false);

  const selectCategoryHandler = (event) => {
    setValues((prevState) => {
      return {
        ...prevState,
        categoryId: event.target.value,
      };
    });
  };

  const handleOpenModal = () => {
    setModalOpen(true);
  }

  const handleCloseModal = () => {
    setModalOpen(false);
  };

  return (
    <FormControl>
      <Grid
        container
        direction="row"
        justify="flex-start"
        alignItems="flex-start"
        spacing={1}
      >
        <Grid container>
          <Grid item xs={6} sm={6}>
            <TextField
              id="title"
              name="title"
              defaultValue={values.title}
              type="text"
              label="Title"
            />
          </Grid>
          <Grid item xs={6} sm={6}>
            <TextField
              select
              id="category"
              label="Category"
              onChange={selectCategoryHandler}
              sx={{ width: 200 }}
            >
              {props.categories.map((item) => {
                return (
                  <MenuItem key={item.id} value={item.id}>
                    {item.name}
                  </MenuItem>
                );
              })}
            </TextField>
          </Grid>
        </Grid>
        <Grid container>
          <Grid item xs={12} sm={12}>
            <TextField
              fullWidth
              multiline
              label="Description"
              rows="6"
              defaultValue={values.description}
            />
          </Grid>
        </Grid>
      </Grid>
      <Button onClick={handleOpenModal}>Add an ingredient</Button>
      <IngredientsModal open={modalOpen} onClose={handleCloseModal}/>
    </FormControl>
  );
};

export default RecipeCreateForm;
