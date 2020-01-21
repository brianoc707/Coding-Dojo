import React, { useState } from "react";
import axios from 'axios';
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
    <>  
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
                <input type="submit"/> 
            </form>
        </div>
    </>
)


}