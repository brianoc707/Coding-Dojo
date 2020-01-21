const { Product } = require('../models/product.model');
module.exports.index = (request, response) => {
    response.json({
        message: "Hello World"
    });
}

module.exports.createProduct = (request, response) => {
    const { name, price, desc } = request.body;
    Product.create({
        name,
        price,
        desc
    })
        .then(product => response.json(product))
        .catch(err => response.json(err))
}