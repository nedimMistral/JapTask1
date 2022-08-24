import React, { useEffect, useState } from "react";
import { list } from "../Service/Categories";

const RecipeCreate = () => {
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        list(null, (res) => {
            setCategories(res.data);
        })
    }, []);

    return (
        <div>newww</div>
    );
}

export default RecipeCreate;