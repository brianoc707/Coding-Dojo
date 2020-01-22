import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ProductForm from '../components/ProductForm';
import EditProduct from '../components/EditProduct';
import ProductInfo from '../components/ProductInfo';
import { Router } from '@reach/router';



export default () => {
    const [products, setProducts] = useState([]);
    
    const removeFromDom = _id => {
        setProducts(products.filter(product => product._id !== _id))
    }


    return(
        <>
            <Router>
                <ProductInfo path ="/info/:id"/>
                <ProductForm path = "/" removeFromDom = {removeFromDom}/>
                <EditProduct path = "/edit/:_id" />
            </Router>
        </>
    );
}