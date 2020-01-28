const mongoose = require('mongoose');


const PetSchema = new mongoose.Schema({
    name: {
        type: String, unique: true,
        required: [true, "Name is required"],
        minlength: [3, "Name must be a minimum of three letters"]
    },

    type: {
        type: String,
        required: [true, "Type is required"],
        minlength: [3, "Type must be a minimum of three letters"]

    },
    desc: {
        type: String,
        required: [true, "Description is required"],
        minlength: [3,  "Description must be a minimum of 3 letters"]
    },

    skillone: {
        type: String,
    },
    skilltwo: {
        type: String,
    },
    skillthree: {
        type: String,
    },
    likes: {
        type: Number
    }
    
}, {timestamps: true});



module.exports = mongoose.model("Pet", PetSchema);