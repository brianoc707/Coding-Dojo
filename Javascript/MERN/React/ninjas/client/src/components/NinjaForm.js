import React, { useState } from "react";
import axios from 'axios';
import { navigate } from '@reach/router';




export default props => {
    const [name, setName] = useState("");
    const [desc, setDesc] = useState("");
    const [errors, setErrors] = useState({});



    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/api/ninjas', {
            name,
            desc
        })
            .then(res => {
                console.log(res);
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
            <h1>New Ninja</h1>
                <form onSubmit={onSubmitHandler}>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text"
                        className ="form-control"
                        onChange={e => setName(e.target.value)}
                        />
                        <span className="text-danger">{errors.name ? errors.name.message: "" }</span>
                    
                    </div>
                    <div className="form-group">
                        <label>Description</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setDesc(e.target.value)}
                        />
                        <span className="text-danger">{errors.desc ? errors.desc.message: "" }</span>
                    
                    </div>
                <input className="btn btn-outline-success" type="submit"/> 
            </form>
        </div>
    )
}