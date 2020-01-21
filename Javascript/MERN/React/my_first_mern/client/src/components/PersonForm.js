import React, { useState } from "react";
import axios from 'axios';
import { set } from "mongoose";

export default props => {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/people', {
            firstName,
            lastName
        })
            .then(res => console.log("Response: ", res))
            .catch(err => console.log("Error: ", err))
    }

return (
    <>  
        <div className="container">
            <h1>Create a Person</h1>
                <form onSubmit={onSubmitHandler}>
                    <div className="form-group">
                        <label>First Name</label>
                        <input type="text"
                        className ="form-control"
                        onChange={e => setFirstName(e.target.value)}
                        />
                    </div>
                    <div className="form-group">
                        <label>Last Name</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setLastName(e.target.value)}
                        />
                    </div>
                <input type="submit"/> 
            </form>
        </div>
    </>
)


}
