import React, { useState } from 'react';


const NinjaList = props =>
{
    return (
        <>
        <div className="container">
        <table>
            <tbody>
                <tr>
                    <th>Name</th>
                    <th>Village</th>
                    <th>Rank</th>
                    <th>Age</th>
                </tr>
                {
                    props.ninjas.map ((ninja, i) =>
                        <tr key={i}>
                            <td>{ninja.name}</td>
                            <td>{ninja.village}</td>
                            <td>{ninja.rank}</td>
                            <td>{ninja.age}</td>
                        </tr>
                    )
                }
            </tbody>
        </table>
        </div>
        </>

    );
}
export default NinjaList;