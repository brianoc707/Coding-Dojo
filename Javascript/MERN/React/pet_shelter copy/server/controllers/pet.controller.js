const Pet = require("../models/pet.model");

module.exports.index  = (request, response) => {
    response.json({
       message: "Hello World"
    })
}

module.exports.createPet = (request, response) => {
    const { name, type, desc, skillone, skilltwo, skillthree } = request.body;
    console.log(request.body);
    Pet.create({
            name,
            type,
            desc,
            skillone, 
            skilltwo,
            skillthree
            
        })
        .then(pet => response.json(pet))
        .catch(err => response.json(err));
}

module.exports.getAll = (request, response) => {
    Pet.find({}).sort("type").exec()
        .then(pets => response.json(pets))
        .catch(err=> response.json(err))
}

module.exports.getOne = (request, response) => {

    Pet.findOne({_id: request.params._id})
        .then(pets => {
            console.log(pets);
            response.json(pets);
        })
        .catch(err => response.json(err));
}

module.exports.editPet = (request, response) => {
    Pet.findOneAndUpdate({_id: request.params._id}, request.body, {runValidators: true}) 
        .then(updatedProduct => response.json(updatedProduct))
        .catch(err => response.json(err));
}

module.exports.likePet = (request, response) => {
    Pet.findOneAndUpdate(
        {_id: request.params._id},
        {$inc: {likes: 1}}
        
    )
        .then(() => response.json({msg: "massive win"}))
        .catch(err => response.json(err));
    }

module.exports.deletePet = (request, response) => {
    Pet.deleteOne({_id: request.params._id})
        .then(deleteConfirmation => response.json(deleteConfirmation))
        .catch(err => response.json(err));
}
