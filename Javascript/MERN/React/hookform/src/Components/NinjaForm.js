import React, { useState } from 'react';

const NinjaForm = props => {
    const [state, setState] = useState({
        name: "",
        rank: "",
        village: "",
        age: "",
        ninjas: []

    });
    const createNinja = e => {
    e.preventDefault();
    console.log(state);
        const ninjaToAdd = {
            name: state.name,
            rank: state.rank,
            village: state.village,
            age: state.age
        };
        const arrayToUpdate = [...state.ninjas];
        arrayToUpdate.push(ninjaToAdd);
        setState({...state, ninjas: arrayToUpdate});
        console.log(state);

    }
    const changeName = e =>{
        console.log(e.target.value);
        setState({...state, name: e.target.value});
    }
    const changeRank= e =>{
        console.log(e.target.value);
        setState({...state, rank: e.target.value});
    }
    const changeVillage = e =>{
        console.log(e.target.value);
        setState({...state, village: e.target.value});
    }
    const changeAge = e =>{
        console.log(e.target.value);
        setState({...state, age: e.target.value});
    }
    return (
        <>
            <form onSubmit={createNinja}>
                <div className="form-group">
                    <label>Name:</label>
                    <input
                        type="text"
                        className="form-control"
                        onChange={changeName}

                    />
                </div>
                <div className="form-group">
                    <label>Rank:</label>
                    <input
                        type="text"
                        className="form-control"
                        onChange={changeRank}

                    />
                </div>
                <div className="form-group">
                    <label>Village:</label>
                    <input
                        type="text"
                        className="form-control"
                        onChange={changeVillage}

                    />
                </div>
                <div className="form-group">
                    <label>Age:</label>
                    <input
                        type="text"
                        className="form-control"
                        onChange={changeAge}

                    />
                </div>
                <input type = "submit" />
            </form>
        </>
    );
}  
export default NinjaForm; 