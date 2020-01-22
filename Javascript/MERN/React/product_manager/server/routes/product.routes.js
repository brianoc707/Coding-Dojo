const ProductController = require('../controllers/product.controller');

module.exports = (app) =>{
    app.get('/', ProductController.index);
    app.post('/products', ProductController.createProduct);
    app.get('/products', ProductController.getAll);
    app.get('/api/info/:id', ProductController.getOne);

}