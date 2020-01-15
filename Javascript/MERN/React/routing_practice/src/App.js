import React from 'react';
import { Router, Link } from '@reach/router';
import GetData from './Components/Luke';
import LukeApi from './Components/Luke';
import RequestFormAPI from "./Components/RequestFormAPI"


const Home = e =>{
  return(
    <>
    <h1>Home</h1>
    <p>ths is home</p>
    </>
  );
}

const Next = e =>{
  return(
    <>
    <h1>Next</h1>
    <p>ths is next page</p>
    </>
  );
}

function App() {
  return (
    <div className="App">
      {/* <Link to="/home">Home</Link>
      <Link to="/next">Next</Link>

      <Router>
      <Home path ="/home" />
      <Next path ="/next" />
      </Router> */}
      <LukeApi />
      {/* <RequestFormAPI /> */}

      
    </div>
  );
}

export default App;
