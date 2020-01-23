import React, { useState, useEffect } from "react";
import axios from 'axios';
import { Link } from '@reach/router';





export default props => {
const [ninjas, setNinjas] = useState([]);
 
    useEffect(() => {
        axios.get('http://localhost:8000/api/ninjas')
            .then(res => {
                setNinjas(res.data);
            })
            .catch(err=>console.log(err));
    }, []);

return (
     
        <div className="container">
            <h1>Ninjas</h1>
            <table border="1px solid black" className="table table-dark">
            <tbody>
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Action</th>
                </tr>
                {
                    ninjas.map ((ninja, i) =>
                        <tr key={i}>
                            <td>
                                <Link to={"/info/" + ninja._id}>{ninja.name}</Link>
                            </td>
                            <td>{ninja.price}</td>
                            <td>{ninja.desc}</td>
                            <td>
                                Delete
                            </td>
                        </tr>
                    )
                }
            </tbody>
            </table>
        </div>
    )
}
