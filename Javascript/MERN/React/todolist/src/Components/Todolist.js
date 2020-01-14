import React, { useState } from 'react';


const Todolist = props =>
{
const [ state, setState ] = useState({
    tasks: [],
    task: "", 
    completed: false
});
    


 
    return (
        <>
        <div className="container">
            <h2>Tasks</h2>
            <ul>
                {
                    
                    props.tasks.map ((task, i) =>
                        
                            <li key = {i}>{task.name}<input type="checkbox"></input><button className="btn btn-danger" >Remove</button></li>
                        
                    )
                }
            </ul>
          
        </div>
        </>

    );
}
export default Todolist;