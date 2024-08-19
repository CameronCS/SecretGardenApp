const mongoose = require("mongoose");

const messageSchema = mongoose.Schema({
    senderid    : { type: String, required: true },
    title       : { type: String, required: true },
    message     : { type: String, required: true },
    recipientid : { type: String, required: true }
}, { timestamps: true });

module.exports = mongoose.model("Message", messageSchema);
