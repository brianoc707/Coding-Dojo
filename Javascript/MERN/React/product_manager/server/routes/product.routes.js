const ProductController = require('../controllers/product.controller');

module.exports = (app) =>{
    app.get('/', ProductController.index);
    app.post('/api/products', ProductController.createProduct);
    app.get('/api/products', ProductController.getAll);
    app.get('/api/products/:id', ProductController.getOne);
    app.delete('/api/products/:id', ProductController.deleteProduct);
    app.put("/api/products/:id", ProductController.updateProduct)
   
    

}