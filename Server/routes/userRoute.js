const express = require("express")
const bcrypt = require("bcrypt")
const User = require("../DB/User")
const Child = require("../DB/Child")

const router = express.Router()

router.get("/", (req, res) => {
    res.send("Hello User")
})

router.post("/login", (req, res) => {
    const { username, password } = req.body

    User.findOne({ username: username })
        .then((user) => {
            if (!user) {
                res.status(401).json({
                    code: 401,
                    message: "Username or password incorrect",
                    user: {}
                })
            } else {
                bcrypt.compare(password, user.password)
                    .then((match) => {
                        if (match) {
                            res.status(200).json({
                                code: 200,
                                message: `User: ${username} user and password match`,
                                user: user
                            })
                        } else {
                            res.status(401).json({
                                code: 401,
                                message: "Username or password incorrect",
                                user: {}
                            })
                        }

                    })
                    .catch((err) => {
                        console.log("here");
                        console.log(err);

                        res.status(401).json({
                            code: 401,
                            message: "Username or password incorrect",
                            user: {}
                        })
                    })
            }
        })
        .catch((err) => {
            console.log(err);

            res.status(401).json({
                code: 401,
                message: "Username or password incorrect",
                user: {}
            })
        })
})

router.get("/children/:pid", (req, res) => {
    const parentID = req.params.pid;
    
    Child.find({
        $or: [
            { parentID1: parentID },
            { parentID2: parentID }
        ]
    })
    .then(children => {
        if (children.length === 0) {
            res.status(404).json({
                code: 404,
                message: "No children found for the given parent ID",
                children: []
            });
        } else {
            res.status(200).json({
                code: 200,
                message: "Children found",
                children: children
            });
        }
    })
    .catch(err => res.status(500).json({
        code: 500,
        message: "Error fetching children",
        children: []
    }));
});


router.get("/newsletters/:clid", (req, res) => {
    const classId = req.params.clid

    Newsletter.find({
        classId
    })
    .then(newsletters => {
        if (newsletters.length === 0) {

            res.status(404).json({
                code: 404,
                message: "No Newsletters found for this class",
                newsletters: []
            })
        } else {
            res.status(200).json({
                code: 200,
                message: "Newsletters found",
                newsletters: newsletters
            })
        }
    })
    .catch(err => res.status(500).json({
        code: 500,
        message: "Internal Server Error",
        newsletters: []
    }))
});

module.exports = router;