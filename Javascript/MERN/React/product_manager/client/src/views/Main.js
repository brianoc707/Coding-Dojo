import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ProductForm from '../components/ProductForm';

import ProductInfo from '../components/ProductInfo';
import { Router, Link } from '@reach/router';



export default () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:8000/products')
            .then(res=>setProducts(res.data))
            .catch(err=>console.log("Error: ", err))
    }, [])


    return(
        <>
        <Router>
        <ProductInfo path ="/info/:id"/>
        </Router>
        &nbsp;
        <Router>
        <ProductForm path = "/" products = {products}/>
        </Router>
       
        
        
        </>
    )
}