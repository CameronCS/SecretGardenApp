const mongoose = require("mongoose")

const userSchema = mongoose.Schema({
    username  : { type: String,  required: true, unique: true },
    imageurl  : { type: String,  required: true },
    firstname : { type: String,  required: true },
    lastname  : { type: String,  required: true },
    password  : { type: String,  required: true },
    contactno : { type: String,  required: true},
    isAdmin   : { type: Boolean, required: true, default: false },
})

module.exports = mongoose.model("User", userSchema);