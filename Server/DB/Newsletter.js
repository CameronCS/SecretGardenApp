const mongoose = require("mongoose");

const newsletterSchema = mongoose.Schema({
    title       : { type: String, required: true },
    description : { type: String, required: true },
    date        : { type: Date,   required: true },
    classId     : { type: String, required: true },
    imageurl    : { type: String, required: true },
}, { timestamps: true });

module.exports = mongoose.model("Newsletter", newsletterSchema);