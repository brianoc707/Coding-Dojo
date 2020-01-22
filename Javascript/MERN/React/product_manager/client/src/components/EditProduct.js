import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { navigate } from '@reach/router';

export default props => {
    const [name, setName] = useState("");
    const [desc, setDesc] = useState("");
    const [price, setPrice] = useState("");
    const [errors, setErrors] = useState({});

    useEffect(() => {
        axios.get(`http://localhost:8000/api/products/${props._id}`)
            .then(res => {
                setName(res.data.name);
                setDesc(res.data.desc);
                setPrice(res.data.price);
                console.log(res.data)})
            .catch(err => console.log(err));
        console.log("when does this run?", props._id);
    }, [props._id])

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.put(`http://localhost:8000/api/products/${props._id}`, {
            name,
            price,
            desc
        })
            .then(res => {
                if(res.data.errors) {
                    setErrors(res.data.errors);
                }
                else{
                    navigate("/")
                }
                console.log(res)
            })
            .catch(err => console.log(err));
    }



return (
     
        <div className="container">
            <h1>Edit Product</h1>
                <form onSubmit={onSubmitHandler}>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text"
                        className ="form-control"
                        onChange={e => setName(e.target.value)}
                        value = {name}
                        />
                    <span className="text-danger">{errors.name ? errors.name.message: "" }</span>
                    </div>
                    <div className="form-group">
                        <label>Price</label>
                        <input type="number"
                        className ="form-control"
                        onChange={e => setPrice(e.target.value)}
                        value = {price}
                        />
                    <span className="text-danger">{errors.price ? errors.price.message: "" }</span>
                    </div>
                    <div className="form-group">
                        <label>Description</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setDesc(e.target.value)}
                        value = {desc}
                        />
                    <span className="text-danger">{errors.desc ? errors.desc.message: "" }</span>
                    </div>
                <input className="btn btn-outline-success" type="submit"/> 
            </form>
        </div>
    )
}