
import React, { useState, useEffect } from "react";
import axios from 'axios';
import { Link } from '@reach/router';








export default props => {
const [pets, setPets] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:8000/api/pets')
            .then(res => {
                setPets(res.data);
               
            })
            .catch(err=>console.log(err));
    }, []);


return (
     
        <div className="container">
            <Link to="/new">Create a Pet</Link>
            <h1>Pet Shelter</h1>
            <h3>These pets are looking for a home!</h3>
            <table border="1px solid black" className="table table-dark">
            <tbody>
                <tr>
                    <th>Name</th>
                    <th>Type</th>
                    <th>Description</th>
                    <th>Skills</th>
                    <th>Action</th>
                </tr>
                {
                    pets.map ((pet, i) =>
                        <tr key={i}>
                            <td>
                            <Link to={"/info/" + pet._id}>{pet.name}</Link>
                            </td>
                            <td>{pet.type}</td>
                            <td>{pet.desc}</td>
                            <td>{pet.skillone}<br />{pet.skilltwo}<br />{pet.skillthree}</td>
                            <td>
                            <Link to={"/edit/" + pet._id}>Edit</Link>
                            </td>
                            
                        </tr>
                    )
                }
            </tbody>
            </table>
            
        </div>
    )
}
