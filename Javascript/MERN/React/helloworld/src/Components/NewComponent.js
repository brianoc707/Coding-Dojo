import React from 'react';
const Button = (props) => {
    return (
        <button onClick={props.handleClick}>Clicked {props.count} times</button>
    );
}
class NewComponent extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            clickCount: 0
        }
    }
    handleClick = () => {
        this.setState({
            clickCount: this.state.clickCount + 1
        })
    }
    render() {
        return (
            <div>
                <Button handleClick={this.handleClick} count={this.state.clickCount}/>
            </div>
        )
    }
}
export default NewComponent;