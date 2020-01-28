import React, { useState, useEffect } from 'react';
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

    useEffect(() => {
        axios.get(`http://localhost:8000/api/pets/${props._id}`)
            .then(res => {
                setName(res.data.name);
                setType(res.data.type);
                setDesc(res.data.desc);
                setSkillone(res.data.skillone);
                setSkilltwo(res.data.skilltwo);
                setSkillthree(res.data.skillthree);
                
                console.log(res.data)})
            .catch(err => console.log(err));
        console.log("when does this run?", props._id);
    }, [props._id])

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.put(`http://localhost:8000/api/pets/${props._id}`, {
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
                    navigate("/info/" + props._id)
                }
              
            })
            .catch(err => console.log(err));
    }
    const onClickHandler = e => {
        e.preventDefault();
        navigate('/info/' + props._id)
    }

return (
     
        <div className="container">
            <h1>Edit</h1>
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
                        <label>Type</label>
                        <input type="text"
                        className ="form-control"
                        onChange={e => setType(e.target.value)}
                        value = {type}
                        />
                        <span className="text-danger">{errors.type ? errors.type.message: "" }</span>
                    
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
                    <div className="form-group">
                        <label>Skill one</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setSkillone(e.target.value)}
                        value = {skillone}
                        />
                        
                    
                    </div>
                    <div className="form-group">
                        <label>Skill two</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setSkilltwo(e.target.value)}
                        value = {skilltwo}
                        />
                       
                    
                    </div>
                    <div className="form-group">
                        <label>Skill three</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setSkillthree(e.target.value)}
                        value = {skillthree}
                        />
                       
                    
                    </div>
                <input className="btn btn-outline-success" type="submit" value="Edit Pet"/>
            </form>
            <button onClick={onClickHandler} className="btn btn-outline-danger">Cancel</button>
        </div>
    )
}