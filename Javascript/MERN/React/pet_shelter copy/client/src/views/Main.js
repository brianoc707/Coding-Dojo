import React, { useState, useEffect } from 'react';
import axios from 'axios';
import PetForm from '../components/PetForm'
import {  Router, Link } from '@reach/router';
import PetTable from '../components/PetTable';
import PetInfo from '../components/PetInfo';
import EditPet from '../components/EditPet';



export default () => {
    const [ message, setMessage ] = useState("...Loading");
    const [pets, setPets] = useState([]);
    
    const removeFromDom = _id => {
        setPets(pets.filter(pet => pet._id !== _id))
    }
   

    useEffect(() => {
        axios.get('http://localhost:8000/api')
        .then(response => {
            setMessage(response.data.message)
        })
    }, [])

    return (
        <>
        <div className="container">
        
        </div>
        <Router>
            
            <PetForm path="/new" />
            <PetTable path="/" />
            <PetInfo path="/info/:_id" removeFromDom={removeFromDom} />
            <EditPet path="/edit/:_id" />
            
        </Router>
        </>
    )
}