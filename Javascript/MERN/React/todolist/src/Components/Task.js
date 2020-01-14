import React, { useState } from 'react';

const Task = props => {
    
    const [state, setState] = useState({
        name: "",
        completed: false
    });


          
   
    const changeName = e =>{
            e.preventDefault();
            console.log(e.target.value);
            setState({...state, name: e.target.value});
        }

    const addTask = e => {
         e.preventDefault();
            
                props.addTask(state);
                setState({
                    name: "",
                    completed: false
                    
                  
        
                });
                
            }
   

        return (
            <>
            <div className="container">
                <form onSubmit={addTask}>
                    <div className="form-group">
                        <label>Name:</label>
                        <input
                            type="text"
                            className="form-control"
                            onChange={changeName}
                            value = {props.name}
                            
    
                        />
                        <input type = "submit" />
                    
                    </div>
                    
                </form>
                </div>
           
            </>
        );
}

export default Task;