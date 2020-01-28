import React, { useState, useEffect } from 'react';
import axios from 'axios';
import NinjaForm from '../components/NinjaForm';
import NinjaTable from '../components/NinjaTable'
import NinjaInfo from '../components/NinjaInfo'
import {  Router, Link } from '@reach/router';


export default () => {
    const [ message, setMessage ] = useState("...Loading");
   ;

    useEffect(() => {
        axios.get('http://localhost:8000/api')
        .then(response => {
            setMessage(response.data.message)
        })
    }, [])

    return (
        <>
        <div className="container">
            <Link to="/new">Create a Ninja</Link>
            &nbsp;
            <Link to="/">Home</Link>
        </div>
        <Router>
            <NinjaForm path="/new" />
            <NinjaTable path="/" />
            <NinjaInfo path ="/info/:_id"/>
        </Router>
        
        </>
    )
}