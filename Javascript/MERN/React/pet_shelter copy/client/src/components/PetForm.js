import React, { useState } from "react";
import axios from 'axios';
import { navigate } from '@reach/router';




export default props => {
    const [name, setName] = useState("");
    const [type, setType] = useState("");
    const [desc, setDesc] = useState("");
    const [skillone, setSkillone] = useState("");
    const [skilltwo, setSkilltwo] = useState("");
    const [skillthree, setSkillthree] = useState("");
    const [errors, setErrors] = useState({});



    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/api/pets', {
            name,
            type,
            desc,
            skillone,
            skilltwo,
            skillthree
            
        })
            .then(res => {
                console.log(res);
                if(res.data.errors) {
                    setErrors(res.data.errors);
                }
                else{
                    navigate("/")
                }
              
            })
            .catch(err => console.log(err));
    }

    const onClickHandler = e => {
        e.preventDefault();
        navigate('/')
    }

return (
     
        <div className="container">
            <h1>Pet Shelter</h1>
            <h3>Know of a pet needing a home?</h3>
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
                        <label>Type</label>
                        <input type="text"
                        className ="form-control"
                        onChange={e => setType(e.target.value)}
                        />
                        <span className="text-danger">{errors.type ? errors.type.message: "" }</span>
                    
                    </div>
                    
                    <div className="form-group">
                        <label>Description</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setDesc(e.target.value)}
                        />
                        <span className="text-danger">{errors.desc ? errors.desc.message: "" }</span>
                    
                    </div>
                    <div className="form-group">
                        <label>Skill one</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setSkillone(e.target.value)}
                        />
                        
                    
                    </div>
                    <div className="form-group">
                        <label>Skill two</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setSkilltwo(e.target.value)}
                        />
                       
                    </div>
                    <div className="form-group">
                        <label>Skill three</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setSkillthree(e.target.value)}
                        />
                       
                    
                    </div>
                <input className="btn btn-outline-success" type="submit"/> 
            </form>
            <br />
            <button onClick={onClickHandler} className="btn btn-outline-danger">Cancel</button>          
        </div>
    )
}