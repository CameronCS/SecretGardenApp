//#region Consts and configs

const express = require("express")
const cors = require("cors")

const app = express()
app.use(cors())
app.use(express.json())
app.use(express.urlencoded({extended: true}))
app.use((req, res, next) => {
    res.header('Access-Control-Allow-Origin', '*'); // Adjust in production
    res.header('Access-Control-Allow-Headers', 'Origin, X-Requested-With, Content-Type, Accept');
    res.header('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE, OPTIONS');
    next();
});
app.use('/uploads', express.static('uploads'));

//#endregion

//#region Mongo Connection

const mongoose = require("mongoose")
const constr = "mongodb+srv://camcstocks:hyVbk3rRSjfby1Lr@secretgarden.tpkjs.mongodb.net/sgdb?retryWrites=true&w=majority&appName=SecretGarden"
mongoose.connect(constr)
.then(() => {
    console.log("Connected");
})
.catch((err) => {
    console.log(`Error: ${err}`)
})

//#endregion

//#region Mongo Collections
const User = require("./DB/User")
const Child = require("./DB/Child")

//#region routers

app.get("/", (req, res) => {
    res.send("Hello World")
})

const addRouter = require("./routes/addRoute")
const userRouter = require("./routes/userRoute")
app.use("/add", addRouter)
app.use("/user", userRouter)
//#endregion

module.exports = app