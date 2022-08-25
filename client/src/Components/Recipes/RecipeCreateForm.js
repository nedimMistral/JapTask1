import { useState } from "react";
import { useHistory } from "react-router-dom";

import {
  Button,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";

import IngredientsModal from "../Ingredients/IngredientsModal";
import IngredientsTable from "../Ingredients/IngredientsTable";
import { pathGenWithParams, routes } from "../../Router/routes";
import { create } from "../../Service/Recipes";
import getUserId from "../../Utils/getUserId";


const RecipeCreateForm = (props) => {
  const [values, setValues] = useState({
    title: "",
    description: "",
    userId: getUserId(),
    categoryId: 0,
    prepTimeMinutes: 0,
    recipeIngredients: [],
  });
  const [ingredients, setIngredients] = useState([]);
  const [modalOpen, setModalOpen] = useState(false);

  const history = useHistory();

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
  };

  const handleCloseModal = () => {
    setModalOpen(false);
  };

  const handleAddIngredient = (value) => {
    setIngredients((prevState) => {
      return [...prevState, value];
    });
  };

  const handleSetValues = (event) => {
    setValues((prevState) => {
      return {
        ...prevState,
        [event.target.name]: event.target.value,
      };
    });
  };

  const sendCreateReq = () => {
    create({
        title: values.title,
        description: values.description,
        userId: values.userId,
        categoryId: values.categoryId,
        prepTimeMinutes: values.prepTimeMinutes,
        recipeIngredients: ingredients,
    }, (res) => {
        console.log(res.data);
    });
    history.push(pathGenWithParams(routes.RECIPES, { id: values.categoryId }))
  }

  return (
    <div>
      {" "}
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
                onChange={handleSetValues}
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
                id="title"
                name="title"
                defaultValue={values.description}
                onChange={handleSetValues}
              />
            </Grid>
          </Grid>
        </Grid>
        <Button onClick={handleOpenModal}>Add an ingredient</Button>
        <IngredientsModal
          open={modalOpen}
          onClose={handleCloseModal}
          onSubmit={handleAddIngredient}
        />
      </FormControl>
      {ingredients && ingredients.length > 0 && (
        <div>
          <IngredientsTable ingredients={ingredients} />
          <Button onClick={sendCreateReq}>Create recipe</Button>
        </div>
      )}
    </div>
  );
};

export default RecipeCreateForm;
