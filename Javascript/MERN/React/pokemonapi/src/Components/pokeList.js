import React, { useState } from 'react';

const PokeList = props => {

    const [ pokemon, setPokemon ] = useState ([]);

    const getPokemons = e => {
        fetch("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=807")
                .then(response => {
                return response.json();
                 })
                .then(response => {
                    setPokemon(response.results);
                    console.log(response);
                })
                .catch(err => {
                    console.log(err);
                });

    }

    return (
        <>
            <p>hi</p>
            <button onClick={getPokemons}>Fetch all da Pokemanz!</button>

            <h3>List of Pokemon names</h3>
            <ul>

                    {
                        pokemon.map( (poke, index) => 
                            <li key={index}>
                                {poke.name}
                            </li>)
                    }
                </ul>
        </>
    );
}

export default PokeList;




    

