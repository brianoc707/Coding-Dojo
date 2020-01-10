import React, { useState } from 'react';
import NinjaForm from './Components/NinjaForm';
import NinjaList from './Components/NinjaList';
import Form from './Components/Form';

function App() {
  const [ state, setState ] = useState({
    ninjas: []
  });

  const ninjaAdded = ninja => {
    console.log("ninja was creted in the form", ninja);
    setState({ninjas : [...state.ninjas, ninja]})
  }
  const userAdded = user => {
    console.log("user was creted in the form", user);
    setState({users : [...state.users, user]})
  }
  return (
   <>
      
      <NinjaForm addNinja={ninjaAdded} msg = "this is a prop"  />
      <hr/>
      <NinjaList ninjas = {state.ninjas} />
      <hr/>
      <Form />   
    </>
  );
}

export default App;

