const ProductController = require('../controllers/product.controller');

module.exports = (app) =>{
    app.get('/', ProductController.index);
    app.post('/products', ProductController.createProduct);
}