import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, navigate } from '@reach/router';




export default props => {
    const [pet, setPet] = useState("");
    const { removeFromDom } = props;
    const [likes, setLikes] = useState(0)
 

    const showPet = () => {
        axios.get("http://localhost:8000/api/pets/" + props._id)
        .then(response => {
            setPet(response.data)
            console.log(response)
        })
        .catch(err => console.log("Error:", err))
    }


    useEffect( () => {
        showPet();

    }, [props._id])

    const deletePet = _id => {
        axios.delete('http://localhost:8000/api/pets/' + _id)
            .then(res => {
                removeFromDom(_id)
                navigate('/');
            })
            .catch(err => console.log(err));
        
    }
    const like = _id => {

        axios.put("http://localhost:8000/api/like/" + _id, {
            likes
        })
            .then(res => {
                console.log(res)
                showPet();
            })
            .catch(err => console.log(err))
            document.getElementById('button').setAttribute("disabled", "disabled");
    }

  

    
    return (
        <>
            <div className="container">
            <Link to="/">Home</Link>
            <h1>Details about {pet.name}</h1>
            <h2>Type:{pet.type}</h2>
            <h3>Description: {pet.desc}</h3>
            <h4>Skills:</h4>
                <p>{pet.skillone}</p>
                <p>{pet.skilltwo}</p>
                <p>{pet.skillthree}</p>
                <button className ="btn btn-outline-success" onClick={e => {deletePet(pet._id)}}>Adopt</button>
                <p>
                <button
                 className ="btn btn-outline-primary"
                 id="button"
                
                 onClick={e => {like(pet._id)}}
                 
                 >Like this pet</button>
                 <span>Likes: {pet.likes}</span>
                </p>
            </div>  
            
        </>
    );

}
