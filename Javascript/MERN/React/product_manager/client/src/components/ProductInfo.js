import React, { useState, useEffect } from 'react';
import axios from 'axios';



export default props => {
const [product, setProduct] = useState({});

useEffect( () => {
    console.log("we got props.id", props.id);
    axios.get('http://localhost:8000/api/info/' + props.id)
        .then(res => {
            console.log(res);
            setProduct(res.data)})
        .catch(err => console.log("Error: ", err))
}, [props.id])
    

    return (
        <div className="container">
         <h1>{product.name}</h1>
         <h3>Description: {product.desc}</h3>
         <p>This Product Costs: ${product.price}</p>
        </div> 
            
        
    )
}