import React, { useState } from 'react';

const NinjaForm = props => {
    const [state, setState] = useState({
        name: "",
        rank: "",
        village: "",
        age: "",
   

    });
    const createNinja = e => {
    e.preventDefault();
    console.log(state);
        props.addNinja(state);
        setState({
            name: "",
            rank: "",
            village: "",
            age: "",
          

        });
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
        <div className="container">
        <h1>Ninjas</h1>
            <form onSubmit={createNinja}>
                <div className="form-group">
                    <label>Name:</label>
                    <input
                        type="text"
                        className="form-control"
                        onChange={changeName}
                        value = {state.name}

                    />
                </div>
                <div className="form-group">
                    <label>Rank:</label>
                    <input
                        type="text"
                        className="form-control"
                        onChange={changeRank}
                        value = {state.rank}

                    />
                </div>
                <div className="form-group">
                    <label>Village:</label>
                    <input
                        type="text"
                        className="form-control"
                        onChange={changeVillage}
                        value = {state.village}

                    />
                </div>
                <div className="form-group">
                    <label>Age:</label>
                    <input
                        type="text"
                        className="form-control"
                        onChange={changeAge}
                        value = {state.age}

                    />
                </div>
                <input type = "submit" />
            </form>
            </div>
       
        </>
    );
}  
export default NinjaForm; 