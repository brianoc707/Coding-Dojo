import React, { useState, useEffect } from 'react';
import axios from 'axios';




export default props => {
    const [ninja, setNinja] = useState({});
    const [ninjutsu, setNinjutsu] = useState([]);

    useEffect( () => {
        console.log("we got props._id", props._id);
        axios.get('http://localhost:8000/api/ninjas/' + props._id)
            .then(res => {
                console.log(res);
                setNinja(res.data)})
            .catch(err => console.log("Error: ", err));
    }, [props._id]);

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.put('http://localhost:8000/api/ninjas' + props._id, {
            name,
            desc
        })
            .then(res => {
                console.log(res);
              
            })
            .catch(err => console.log(err));
    }

    

    return (
        <>
            <div className="container">
            <h1>Name:{ninja.name}</h1>
            <h3>Description: {ninja.desc}</h3>
            <h6>Add a Ninjustu</h6>
            <div className="form-group">
                    <form onSubmit={onSubmitHandler}>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setNinjutsu(e.target.value)}
                        />
                     <input className="btn btn-outline-success" type="submit"/> 
                     </form>
            
            </div>       
            </div>
        </>
    );
}