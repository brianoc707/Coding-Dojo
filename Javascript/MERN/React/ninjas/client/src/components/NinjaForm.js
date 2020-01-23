import React, { useState } from "react";
import axios from 'axios';




export default props => {
    const [name, setName] = useState("");
    const [desc, setDesc] = useState("");



    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/api/ninjas', {
            name,
            desc
        })
            .then(res => {
                console.log(res);
              
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
        </div>
    )
}