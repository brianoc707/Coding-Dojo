import React from 'react';

import './App.css';
import HelloWorld from './Components/hello';
import PersonCard from './Components/PersonCard';
import MyNewComponent from './Components/MyNewComponent';
import NewComponent from './Components/NewComponent';
const Button = (props) => {
  return(
    <button onClick={props.click}>{props.text}</button>
  );
}
const App = () => {
  const clickHandler = () =>  console.log("clicked");
  const buttonOneText = "I am the first button being clicked";
  const buttonTwoText = "And I am the second button being clicked";
  return (
    <div className="App">
     <PersonCard name = "Brian O'Connor" age = {27} hair = "brown"/>
     <PersonCard name = "Your Mom" age = {60} hair = "white"/>
     <PersonCard name ="ahaha" age = {100} hair = "bald"/>
     <MyNewComponent header = {"YO"}>
        <h2>This is a child</h2>
        <input type = "text"></input>
      </MyNewComponent>
      <Button text={buttonOneText} click={clickHandler} />
      <Button text={buttonTwoText} click={clickHandler} />

      <NewComponent/>
    
   
    </div>
  );
}


export default App;
