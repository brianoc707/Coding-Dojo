const PetController = require('../controllers/pet.controller');

module.exports = (app) =>{
    app.get('/api', PetController.index);
    app.post('/api/pets', PetController.createPet);
    app.get('/api/pets', PetController.getAll);
    app.get('/api/pets/:_id', PetController.getOne);
    app.put('/api/pets/:_id', PetController.editPet);
    app.put('/api/like/:_id', PetController.likePet);
    app.delete('/api/pets/:_id', PetController.deletePet);


}