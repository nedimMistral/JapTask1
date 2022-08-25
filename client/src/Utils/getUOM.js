const getUOM = (id) => {
  let uom = "";

  switch (id) {
    case 0:
      uom = "piece";
      break;
    case 1:
      uom = "kilogram";
      break;
    case 2:
      uom = "gram";
      break;
    case 3:
      uom = "liter";
      break;
    case 4:
      uom = "milliliter";
      break;
    case 5:
      uom = "teaspoon";
      break;
    case 6:
      uom = "tablespoon";
      break;
  }

  return uom;
};

export default getUOM;