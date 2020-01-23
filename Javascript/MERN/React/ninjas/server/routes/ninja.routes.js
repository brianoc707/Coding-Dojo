const NinjaController = require('../controllers/ninja.controller');

module.exports = (app) =>{
    app.get('/api', NinjaController.index);
    app.post('/api/ninjas', NinjaController.createNinja);
    app.get('/api/ninjas', NinjaController.getAll);
    app.get('/api/ninjas/:_id', NinjaController.getOne);
    app.put('/api/ninjas/:_id', NinjaController.addNinjutsu);


}