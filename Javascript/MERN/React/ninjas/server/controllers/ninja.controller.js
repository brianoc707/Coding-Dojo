const Ninja = require("../models/ninja.model");

module.exports.index  = (request, response) => {
    response.json({
       message: "Hello World"
    })
}

module.exports.createNinja = (request, response) => {
    const { name, desc, ninjutsu } = request.body;
    console.log(request.body);
    Ninja.create({
            name,
            desc,
            ninjutsu
        })
        .then(ninja => response.json(ninja))
        .catch(err => response.json(err));
}

module.exports.getAll = (request, response) => {
    Ninja.find({}).sort("name").exec()
        .then(ninjas => response.json(ninjas))
        .catch(err=> response.json(err))
}
module.exports.getOne = (request, response) => {

    Ninja.findOne({_id: request.params._id})
        .then(ninjas => {
            console.log(ninjas);
            response.json(ninjas);
        })
        .catch(err => response.json(err));
}

module.exports.addNinjutsu = (request, response) => {
    Ninja.findOneAndUpdate(
        {_id: request.params._id},
        {$push: {ninjutsu: request.body.ninjutsu}}
        
    )
        .then(() => response.json({msg: "massive win"}))
        .catch(err => response.json(err));
    }
module.exports.deleteNinjutsu = (request, response) => {
    Ninja.findOneAndUpdate(
        {_id: request.params._id},
        {$pull: {ninjutsu: request.body.ninjutsu}}
        
    )
        .then(() => response.json({msg: "massive win"}))
        .catch(err => response.json(err));
    }



module.exports.deleteNinja = (request, response) => {
    Ninja.deleteOne({_id: request.params._id})
        .then(deleteConfirmation => response.json(deleteConfirmation))
        .catch(err => response.json(err));
}
