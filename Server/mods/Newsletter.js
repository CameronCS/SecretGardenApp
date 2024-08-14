const mongoose = require("mongoose");

const newsletterSchema = mongoose.Schema({
    title       : { type: String, required: true },
    description : { type: String, required: true },
    date        : { type: Date,   required: true },
    classid     : { type: String, required: true },
    image       : { type: Buffer, required: true },
}, { timestamps: true });

module.exports = mongoose.model("Newsletter", newsletterSchema);