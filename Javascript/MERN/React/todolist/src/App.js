import React, { useState } from 'react';

import Task from './Components/Task';
import Todolist from './Components/Todolist';

function App() {
  const [ state, setState ] = useState({
    tasks: []
  });

  const taskAdded = task => 
  {
    console.log("task was created in the form", task);
    setState({tasks : [...state.tasks, task]})
  }
  return (
    <>
    <h1>To Do List</h1>
      <Todolist tasks ={state.tasks} />
      <Task addTask={taskAdded}  />
      


    </>
  );
}
export default App;
