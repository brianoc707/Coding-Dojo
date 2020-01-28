import React, { useState, useEffect } from 'react';


export default props => {
    return (
        <>
        <h1>Traktrain V2</h1>
        <table border="1px solid black" className="table table-dark">
            <tbody>
                <tr>
                    <th>Name</th>
                    <th>BPM</th>
                    <th>Price</th>
                    <th>Action</th>
                </tr>
                {/* {
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
                } */}
            </tbody>
            </table>

            
        </>
    )
}