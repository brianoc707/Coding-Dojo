const mongoose = require('mongoose');

const ProductSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, "Name is required"],
        minlength: [2, "Name must be a minimum of two letters"]
    },
    desc: {
        type: String,
        required: [true, "Description is required"],
        minlength: [2,  "Description must be a minimum of two letters"]
    },
    price: {
        type: Number,
        required: [true, "Price is required"],
        min: [0, "Price can not be a negative"]
    }
}, {timestamps: true});

module.exports.Product = mongoose.model("Product", ProductSchema);