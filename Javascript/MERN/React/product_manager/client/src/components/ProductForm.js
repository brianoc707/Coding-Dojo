import React, { useState, useEffect } from "react";
import axios from 'axios';
import { Link, navigate } from '@reach/router';



export default props => {
    const [name, setName] = useState("");
    const [desc, setDesc] = useState("");
    const [price, setPrice] = useState("");
    const [errors, setErrors] = useState({});
    const [updatedList, setUpdatedList] = useState(false);
    const [products, setProducts] = useState([]);

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/api/products', {
            name,
            price,
            desc
        })
            .then(res => {
                if(res.data.errors) {
                    setErrors(res.data.errors);
                }
                else{
                    navigate("/")
                }
                console.log(res)
            })
            .catch(err => console.log(err));
    }

    const { removeFromDom } = props;

    const deleteProduct = _id => {
        axios.delete('http://localhost:8000/api/products/' + _id)
            .then(res => {
                removeFromDom(_id)
            }).catch(err => console.log(err));
    }

 
    useEffect(() => {
        axios.get('http://localhost:8000/api/products')
            .then(res => {
                setProducts(res.data);
                setUpdatedList(!updatedList);
              
            })
            .catch(err=>console.log(err));
    }, [updatedList]);

return (
     
        <div className="container">
            <h1>Product Manager</h1>
                <form onSubmit={onSubmitHandler}>
                    <div className="form-group">
                        <label>Name</label>
                        <input type="text"
                        className ="form-control"
                        onChange={e => setName(e.target.value)}
                        />
                    <span className="text-danger">{errors.name ? errors.name.message: "" }</span>
                    </div>
                    <div className="form-group">
                        <label>Price</label>
                        <input type="number"
                        className ="form-control"
                        onChange={e => setPrice(e.target.value)}
                        />
                    <span className="text-danger">{errors.price ? errors.price.message: "" }</span>
                    </div>
                    <div className="form-group">
                        <label>Description</label>
                        <input type="text"
                        className = "form-control"
                        onChange={e => setDesc(e.target.value)}
                        />
                    <span className="text-danger">{errors.desc ? errors.desc.message: "" }</span>
                    </div>
                <input className="btn btn-outline-success" type="submit"/> 
            </form>
            <table border="1px solid black" className="table table-dark">
            <tbody>
                <tr>
                    <th>Product</th>
                    <th>Price</th>
                    <th>Description</th>
                    <th>Action</th>
                </tr>
                {
                    products.map ((product, i) =>
                        <tr key={i}>
                            <td><Link to={"/info/" + product._id}>{product.name}</Link></td>
                            <td>${product.price}</td>
                            <td>{product.desc}</td>
                            <td>
                                <button onClick={e => {deleteProduct(product._id)}}>Delete</button>
                                <Link to={"/edit/" + product._id}>Edit</Link> 
                            </td>
                        </tr>
                    )
                }
            </tbody>
            </table>
        </div>
    )
}