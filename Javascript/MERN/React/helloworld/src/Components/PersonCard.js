import React, { Component } from 'react';


class PersonCard extends Component {
    
    constructor(props){
        super(props);
        this.state = {
            age: this.props.age
        }
    }

    getold = e => {
       this.setState({age: this.state.age+1});
    }
    
    render() {
   
        return (
                <div>
                    <fieldset>
                    <legend>{this.props.name}</legend>
                    <p>Age: {this.state.age}</p>
                    <p>Hair Color: {this.props.hair}</p>
                    <button onClick={this.getold}>Birthday Button for {this.props.name}</button>
                    </fieldset>
                </div>
        );
    }


}
export default PersonCard;