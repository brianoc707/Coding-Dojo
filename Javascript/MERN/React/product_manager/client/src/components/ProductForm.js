import React, { useState } from "react";
import axios from 'axios';
import { Router, Link } from '@reach/router';
import { set } from "mongoose";

export default props => {
    const [name, setName] = useState("");
    const [desc, setDesc] = useState("");
    const [price, setPrice] = useState("");

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/products', {
            name,
            price,
            desc
        })
            .then(res => console.log("Response: ", res))
            .catch(err => console.log("Error: ", err))
    }

return (
     
        <div className="container">
            <h1>Product Manager</h1>
                <form onSubmit={onSubmitHandler}>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text"
                        className ="form-control"
                        onChange={e => setName(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                        <label>Price</label>
                        <input type="text"
                        className ="form-control"
                        onChange={e => setPrice(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                        <label>Description</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setDesc(e.target.value)}
                        />
                    </div>
                <input className="btn btn-outline-success" type="submit"/> 
            </form>
            <table border="1px solid black" className="table table-dark">
            <tbody>
                <tr>
                    <th>Product</th>
                    <th>Price</th>
                    <th>Description</th>
                </tr>
                {
                    props.products.map ((product, i) =>
                        <tr key={i}>
                            <td><Link to={"/info/" + product._id}>{product.name}</Link></td>
                            <td>{product.price}</td>
                            <td>{product.desc}</td>
                        </tr>
                    )
                }
            </tbody>
            </table>
        </div>
        
        
        

    )



}