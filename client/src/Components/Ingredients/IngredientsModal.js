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
import { styled } from "@mui/material/styles";

import { useEffect, useState } from "react";
import { list } from "../../Service/Ingredients";

import classes from "./IngredientsModal.module.css";
import getUOM from "../../Utils/GetUOM";

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary,
}));

const IngredientsModal = (props) => {
  const [ingredients, setIngredients] = useState([]);
  const [values, setValues] = useState({});
  const [selected, setSelected] = useState(false);

  useEffect(() => {
    list((res) => {
      setIngredients(res.data);
    });
  }, []);

  const handleSelectIngredient = (e, value) => {
    setValues(value);
    setSelected(true);
  };

  const handleDeselectIngredient = () => {
    setValues({});
    setSelected(false);
  };

  return (
    <Dialog
      open={props.open}
      onClose={props.onClose}
      fullWidth={true}
      maxWidth="md"
    >
      <DialogContent>
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
          <Box>
            <Grid container spacing={2} className={classes.grid}>
              <Grid item xs={6}>
                <Typography className={classes["header-text"]}>
                  Ingredient name
                </Typography>
              </Grid>
              <Grid item xs={2}>
                <Typography className={classes["header-text"]}>
                  Price
                </Typography>
              </Grid>
              <Grid item xs={2}>
                <Typography className={classes["header-text"]}>
                  Unit of measure
                </Typography>
              </Grid>
              <Grid item xs={2}>
                <Typography className={classes["header-text"]}>
                  Quantity
                </Typography>
              </Grid>
            </Grid>
            <Grid container spacing={2}>
              <Grid item xs={6}>
                <Typography>{values.label}</Typography>
              </Grid>
              <Grid item xs={2}>
                <Typography>{values.unitPrice}</Typography>
              </Grid>
              <Grid item xs={2}>
              <Typography>{getUOM(values.unitOfMeasure)}</Typography>
              </Grid>
              <Grid item xs={2}>
              <Input></Input>
              </Grid>
            </Grid>
          </Box>
        )}
        {selected && (<Button className={classes['add-btn']} disabled={!selected}>Add</Button>)}
      </DialogContent>
    </Dialog>
  );
};

export default IngredientsModal;
