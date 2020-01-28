import React, { useState, useEffect } from 'react';
import axios from 'axios';




export default props => {
    const [ninja, setNinja] = useState({ninjutsu: []});
    const [ninjutsu, setNinjutsu] = useState("");

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
        axios.put('http://localhost:8000/api/ninjas/' + props._id, {ninjutsu})
            .then(res => {
                setNinjutsu("");
                console.log(res);
                axios.get('http://localhost:8000/api/ninjas/' + props._id)
                    .then(res => {
                        console.log(res);
                        setNinja(res.data)})
                    .catch(err => console.log("Error: ", err));
                })
            .catch(err => console.log(err));
        }

    const onClickHandler = i => {
        console.log(ninja.ninjutsu[i]);
        axios.put('http://localhost:8000/api/ninjutsu/' + props._id, {ninjutsu: ninja.ninjutsu[i]})
            .then(res => {})
            .catch(err => console.log(err))
                axios.get('http://localhost:8000/api/ninjas/' + props._id)
                .then(res => {
                    console.log(res);
                    setNinja(res.data)})
                .catch(err => console.log("Error: ", err));
    }
    return (
        <>
            <div className="container">
            <h1>Name:{ninja.name}</h1>
            <h3>Description: {ninja.desc}</h3>
            <div className="form-group">
                    <form onSubmit={onSubmitHandler}>
                        <label>Add a Ninjutsu:</label>
                        <input type="text"
                        value ={ninjutsu}
                        className = "form-control"
                        onChange={e => setNinjutsu(e.target.value)}
                        />
                     <input className="btn btn-outline-success" type="submit"/> 
                     </form>
            </div>
                <fieldset>
                    <legend>{ninja.name}'s Ninjutsus</legend>
                    <ul>
                        {
                            ninja.ninjutsu.map((ninjutsu, i) => 
                                <li key ={i}>{ninjutsu}<button onClick={e => onClickHandler(i)}>remove</button></li>
                            )
                        }
                    </ul>
                </fieldset>
            </div>  
        </>
    );
}