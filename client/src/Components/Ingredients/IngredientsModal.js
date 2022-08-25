import { useEffect, useState } from "react";

import {
  Autocomplete,
  Button,
  Dialog,
  DialogContent,
  Grid,
  Input,
  Modal,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import { Box } from "@mui/system";

import { list } from "../../Service/Ingredients";
import classes from "./IngredientsModal.module.css";
import getUOM from "../../Utils/getUOM";


const IngredientsModal = (props) => {
  const [ingredients, setIngredients] = useState([]);
  const [values, setValues] = useState({});
  const [selected, setSelected] = useState(false);

  useEffect(() => {
    list((res) => {
      setIngredients(res.data);
    });
  }, []);

  useEffect(() => {
    if(!props.open) {
        setValues({});
    }
  }, [props.open]);

  const handleSelectIngredient = (e, value) => {
    setValues((prevState) => {
        return {
            ...prevState,
            ingredientName: value.label,
            ingredientId: value.id,
            price: value.unitPrice,
            measureUnit: value.unitOfMeasure,
        }
    });
    setSelected(true);
  };

  const handleDeselectIngredient = () => {
    setValues({});
    setSelected(false);
  };

  const handleAddQuantity = (event) => {
    setValues((prevState) => {
        return {
            ...prevState,
            quantity: event.target.value
        }
    })
  }

  const handleSubmit = () => {
    props.onSubmit(values);
    props.onClose();
  };

  return (
    <Dialog
      open={props.open}
      onClose={props.onClose}
      fullWidth={true}
      maxWidth="md"
      keepMounted={false}
    >
      <DialogContent>
        <Typography className={classes["header-text"]} variant="h5" >Add ingredient</Typography>
        {ingredients.length > 0 && (
          <Autocomplete
            className={classes.autocomplete}
            onChange={handleSelectIngredient}
            onAbort={handleDeselectIngredient}
            renderInput={(params) => (
              <TextField {...params} label="Ingredients" sx={{ width: 300 }} />
            )}
            options={ingredients.map((item) => {
              return {
                label: item.name,
                id: item.id,
                unitPrice: item.unitPrice,
                unitQuantity: item.unitQuantity,
                unitOfMeasure: item.unitOfMeasure,
              };
            })}
          />
        )}
        {selected && values && (
          <Box >
            <Grid container spacing={2} className={classes.grid}>
              <Grid item xs={6}>
                <Typography >
                  Ingredient name
                </Typography>
              </Grid>
              <Grid item xs={2}>
                <Typography >
                  Price
                </Typography>
              </Grid>
              <Grid item xs={2}>
                <Typography>
                  Unit of measure
                </Typography>
              </Grid>
              <Grid item xs={2}>
                <Typography>
                  Quantity
                </Typography>
              </Grid>
            </Grid>
            <Grid container spacing={2}>
              <Grid item xs={6}>
                <Typography>{values.ingredientName}</Typography>
              </Grid>
              <Grid item xs={2}>
                <Typography>{values.price}</Typography>
              </Grid>
              <Grid item xs={2}>
              <Typography>{getUOM(values.measureUnit)}</Typography>
              </Grid>
              <Grid item xs={2}>
              <Input onChange={handleAddQuantity}/>
              </Grid>
            </Grid>
          </Box>
        )}
        <Typography align="center">{selected ? <Button className={classes['add-btn']} disabled={!selected} onClick={handleSubmit}>Add</Button> : ""}</Typography>
      </DialogContent>
    </Dialog>
  );
};

export default IngredientsModal;
