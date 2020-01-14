import React, { useEffect, useState } from 'react';
import axios from 'axios';

const AxiosList = e =>
{
    const [pokemon, setPokemon] = useState([]);

    const GetPokemon = e =>{
    
        axios.get("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=807")
        .then(response=>{
            setPokemon(response.data.results);
        
        })
        .catch(err => console.log(err));

     
    }
    

    return(
        <div>
            <h1>LIST OF POK3M0n</h1>
            <button onClick={GetPokemon}>display POKIMEN</button>
            <ul>
                {
                    pokemon.map( (poke, i) => 
                    <li key= {i}>{poke.name}</li>)
                }
            </ul>
        </div>
    )


}
export default AxiosList;