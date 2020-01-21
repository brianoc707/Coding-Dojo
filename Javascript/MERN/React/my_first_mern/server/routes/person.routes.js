const PersonController = require('../controllers/person.controller');

module.exports = (app) =>{
    app.get('/', PersonController.index);
}