import React, { useEffect, useState } from 'react';
import ProductForm from '../components/ProductForm';
import EditProduct from '../components/EditProduct';
import ProductInfo from '../components/ProductInfo';
import ProductList from '../components/ProductList';
import { Router, Link } from '@reach/router';



export default () => {
    const [products, setProducts] = useState([]);
    
    const removeFromDom = _id => {
        setProducts(products.filter(product => product._id !== _id))
    }


    return(
        <>
            <div className="container">
            <Link to="/">Home</Link>
            <Link to="/create">Add a new Product</Link>
            </div>
            <Router>
                <ProductInfo path ="/info/:id"/>
                <ProductForm path = "/create" />
                <ProductList path = "/" removeFromDom = {removeFromDom}/>
                <EditProduct path = "/edit/:_id" />
            </Router>
            
        </>
    );
}