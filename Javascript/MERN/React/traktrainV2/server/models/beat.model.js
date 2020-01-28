const mongoose = require('mongoose');


const BeatSchema = new mongoose.Schema({
    name: {
        type: String, unique: true,
        required: [true, "Name is required"],
        minlength: [3, "Name must be a minimum of three letters"]
    },

    BPM: {
        type: Number,
        required: [true, "BPM is required"],
        

    },
    Price: {
        type: Number,
        required: [true, "Price is required"],
        

    },
    location: {
        type: String
    }
    
}, {timestamps: true});



module.exports = mongoose.model("Beat", BeatSchema);