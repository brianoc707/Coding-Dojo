import React, { useState } from 'react';
const RegisterForm = props => {
    const [ formState, setFormState ] = useState({
        firstName: "",
        lastName: "",
        email:"",
        password:"",
        confirmPassword:"",
        submitted: false
    })
    
    const onChangeHandler = event => {
        event.preventDefault();
        setFormState({
            ...formState,
            [event.target.name]: event.target.value
        })
    }

    const onSubmitHandler = event => {
        event.preventDefault();
        console.log(formState);
        setFormState({
            ...formState,
            submitted: true
        })
    }
    return(
        <>
            <div className="container">

                <h1>Please fill out the form.</h1>
                <form onSubmit={onSubmitHandler} >
                    <div className="form-group">
                        <label>First Name</label>
                        <input type="text" className ="form-control"   name="firstName" onChange={onChangeHandler}/>
                        {formState.firstName.length < 2 && formState.firstName.length !==0 ? <p className="text-danger">First Name must be at least 2 characters.</p>:<p></p>}
                    </div>

                    <div className="form-group">
                        <label>Last Name</label>
                        <input type="text" className ="form-control" name="lastName" onChange={onChangeHandler}/>
                        {formState.firstName.length < 2 && formState.firstName.length !==0 ? <p className="text-danger">Last Name must be at least 2 characters.</p>:<p></p>}
                    </div>

                    <div className="form-group">
                        <label>Email</label>
                        <input type="email" className ="form-control" name="email" onChange={onChangeHandler}/>
                        {formState.firstName.length < 5 && formState.firstName.length !==0 ? <p className="text-danger">Email must be at least 5 characters.</p>:<p></p>}
                    </div>

                    <div className="form-group">
                        <label>Password</label>
                        <input type="password" className ="form-control" name="password" onChange={onChangeHandler}/>
                        {formState.firstName.length < 8 && formState.firstName.length !==0 ? <p className="text-danger">Password must be at least 8 characters.</p>:<p></p>}
                    </div>

                    <div className="form-group">
                        <label>Confirm Password</label>
                        <input type="password" className ="form-control" name="confirmPassword" onChange={onChangeHandler}/>
                        {formState.confirmPassword == formState.password ? <p></p>:<p className="text-danger">Passwords must match.</p>}
                    </div>

                    <input type="submit" className="btn btn-primary" />
                </form>
            </div>
        </>
    );
}

export default RegisterForm;