import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from "@mui/material";

import getUOM from "../../Utils/GetUOM";

import classes from "./IngredientsTable.module.css";

const IngredientsTable = (props) => {
  return (
    <Table aria-label="simple table">
      <TableHead>
        <TableRow>
          <TableCell className={classes.tableHeader}>Ingredient</TableCell>
          <TableCell className={classes.tableHeader}>Quantity</TableCell>
          <TableCell className={classes.tableHeader}>Price</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {props.ingredients.map((item) => {
          return (
            <TableRow key={item.ingredientName}>
              <TableCell>{item.ingredientName}</TableCell>
              <TableCell>
                {item.quantity} {getUOM(item.measureUnit)}
              </TableCell>
              <TableCell>{item.price * item.quantity}</TableCell>
            </TableRow>
          );
        })}
      </TableBody>
    </Table>
  );
};

export default IngredientsTable;
