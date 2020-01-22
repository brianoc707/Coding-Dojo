import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { navigate } from '@reach/router';



export default props => {
    const [product, setProduct] = useState({});

    useEffect( () => {
        console.log("we got props.id", props.id);
        axios.get('http://localhost:8000/api/products/' + props.id)
            .then(res => {
                console.log(res);
                setProduct(res.data)})
            .catch(err => console.log("Error: ", err));
    }, [props.id]);

    const { removeFromDom } = props;

    const deleteProduct = _id => {
        axios.delete('http://localhost:8000/api/products/' + _id)
            .then(res => {
                
                navigate("/");
            }).catch(err => console.log(err));
    }
    

    return (
        <div className="container">
         <h1>{product.name}</h1>
         <h3>Description: {product.desc}</h3>
         <p>This Product Costs: ${product.price}</p>
         <button onClick={e => {deleteProduct(product._id)}}>Delete</button>
        </div>  
    );
}