const TrakController = require('../controllers/trak.controller');

module.exports = function(app){
    app.get('/api', TrakController.index);
}