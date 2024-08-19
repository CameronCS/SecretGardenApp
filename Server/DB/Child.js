const mongoose = require("mongoose");

const childSchema = mongoose.Schema({
    imagepath : { type: String, required: true },
    firstname : { type: String, required: true },
    lastname  : { type: String, required: true },
    classname : { type: String, required: true },
    classId   : { type: String, required: true },
    parentID1 : { type: String, required: true },
    parentID2 : { type: String, required: false },
});

module.exports = mongoose.model("Child", childSchema);
