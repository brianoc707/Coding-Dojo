const mongoose = require('mongoose');

const NinjaSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, "Name is required"],
        minlength: [2, "Name must be a minimum of two letters"]
    },
    desc: {
        type: String,
        required: [true, "Description is required"],
        minlength: [2,  "Description must be a minimum of two letters"]
    },
    ninjutsu: []
}, {timestamps: true});

module.exports = mongoose.model("Ninja", NinjaSchema);