//#region Requires
const http  = require("http")
const app   =  require("./app")
//#endregion

const server = http.createServer(app);

const PORT = 3050
const URL = "192.168.0.187"

server.listen(PORT, URL, () => {
    console.log(`Server running on ${URL}:${PORT}`)
})