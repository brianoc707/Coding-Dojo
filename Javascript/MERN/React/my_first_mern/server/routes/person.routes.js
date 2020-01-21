const PersonController = require('../controllers/person.controller');

module.exports = (app) =>{
    app.get('/', PersonController.index);
    app.post('/people', PersonController.createPerson);
}