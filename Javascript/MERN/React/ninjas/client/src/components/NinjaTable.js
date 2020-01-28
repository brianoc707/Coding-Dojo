import React, { useState, useEffect } from "react";
import axios from 'axios';
import { Link } from '@reach/router';






export default props => {
const [ninjas, setNinjas] = useState([]);
const [results, setResults] = useState([]);
const [order, setOrder] = useState("Ascending");

 
    useEffect(() => {
        axios.get('http://localhost:8000/api/ninjas')
            .then(res => {
                setNinjas(res.data);
                setResults(res.data);
            })
            .catch(err=>console.log(err));
    }, []);

    const filterResults = e => {
        let searchTerm = e.target.value.toLowerCase();
        setResults(ninjas.filter(r => r.name.toLowerCase().includes(searchTerm)))
    };


    const removeFromDom = _id => {
        setNinjas(ninjas.filter(ninja => ninja._id !== _id))
    }
    const deleteNinja = _id => {
        axios.delete('http://localhost:8000/api/ninjas/' + _id)
            .then(res => {
                removeFromDom(_id)
            }).catch(err => console.log(err));
    }
    const reverseOrder = e => {
        let temp = [...results];
        temp.reverse();
        setResults(temp);
        if(order === "Descending"){
            setOrder("Ascending");
        }
        else{
            setOrder("Descending");
        }
    }



return (
     
        <div className="container">
            <h1>Ninjas</h1>
            <p>
                <input type="search" onChange={filterResults}/>
            </p>
            <p>
                <button onClick={reverseOrder}>{order}</button>
            </p>
            <table border="1px solid black" className="table table-dark">
            <tbody>
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Ninjutsus</th>
                    <th>Action</th>
                </tr>
                {
                    results.map ((ninja, i) =>
                        <tr key={i}>
                            <td>
                                <Link to={"/info/" + ninja._id}>{ninja.name}</Link>
                            </td>
                            <td>{ninja.desc}</td>
                            <td>Ninjutsus :  {ninja.ninjutsu.length}</td>
                            <td>
                            <button onClick={e => {deleteNinja(ninja._id)}}>Delete</button>
                            </td>
                        </tr>
                    )
                }
            </tbody>
            </table>
        </div>
    )
}
