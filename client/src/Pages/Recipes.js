import React, { useEffect } from "react";
import { useParams } from "react-router-dom";

const Recipes = () => {
   const params = useParams();
   const categoryId = params.id;

   useEffect(() => {
    console.log("CATEGORY ID:::: ", categoryId);
   }, []);

       return (
        <div>LIST OF RECIPES</div>
    )
}

export default Recipes;