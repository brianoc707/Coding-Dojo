import React, { useState, useEffect } from "react";
import axios from 'axios';
import { Link, navigate } from '@reach/router';



export default props => {
    const [updatedList, setUpdatedList] = useState(false);
    const [products, setProducts] = useState([]);

   

    const { removeFromDom } = props;

    const deleteProduct = _id => {
        axios.delete('http://localhost:8000/api/products/' + _id)
            .then(res => {
                removeFromDom(_id)
            }).catch(err => console.log(err));
    }

 
    useEffect(() => {
        axios.get('http://localhost:8000/api/products')
            .then(res => {
                setProducts(res.data);
                setUpdatedList(!updatedList);
              
            })
            .catch(err=>console.log(err));
    }, [updatedList]);

return (
     
        <div className="container">
            <h1>Products</h1>
            <table border="1px solid black" className="table table-dark">
            <tbody>
                <tr>
                    <th>Product</th>
                    <th>Price</th>
                    <th>Description</th>
                    <th>Action</th>
                </tr>
                {
                    products.map ((product, i) =>
                        <tr key={i}>
                            <td><Link to={"/info/" + product._id}>{product.name}</Link></td>
                            <td>${product.price}</td>
                            <td>{product.desc}</td>
                            <td>
                                <button onClick={e => {deleteProduct(product._id)}}>Delete</button>
                                <Link to={"/edit/" + product._id}>Edit</Link> 
                            </td>
                        </tr>
                    )
                }
            </tbody>
            </table>
        </div>
    )
}