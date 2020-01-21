const mongoose = require('mongoose');

const ProductSchema = new mongoose.Schema({
    name: {type: String},
    desc: {type: String},
    price: {type: Number}
}, {timestamps: true});

module.exports.Product = mongoose.model("Product", ProductSchema);