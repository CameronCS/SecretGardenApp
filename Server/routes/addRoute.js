//#region imports
const express = require("express");
const bcrypt = require("bcrypt");
const multer = require("multer");
const path = require("path");
const fs = require("fs");
//#endregion

//#region Upload Config
// Create the base uploads directory if it doesn't exist
const baseUploadDir = path.resolve(__dirname, '../uploads');
if (!fs.existsSync(baseUploadDir)) {
    fs.mkdirSync(baseUploadDir, { recursive: true });
}

// Function to determine the upload directory based on context
function getUploadDirectory(ctx) {
    switch (ctx) {
        case 'user':
            return path.join(baseUploadDir, 'users');
        case 'child':
            return path.join(baseUploadDir, 'children');
        default:
            return baseUploadDir;
    }
}

// Multer storage configuration
const storage = multer.diskStorage({
    destination: (req, file, cb) => {
        // Determine the upload directory based on context
        const ctx = req.body.ctx; // or adjust based on how you pass context
        console.log(req.body);
        
        const uploadDir = getUploadDirectory(ctx);

        // Debug logging
        console.log(`Context: ${ctx}`);
        console.log(`Upload Directory: ${uploadDir}`);

        // Create the directory if it doesn't exist
        if (!fs.existsSync(uploadDir)) {
            fs.mkdirSync(uploadDir, { recursive: true });
            console.log(`Created Directory: ${uploadDir}`);
        }

        cb(null, uploadDir);
    },
    filename: (req, file, cb) => {
        const ext = path.extname(file.originalname);
        cb(null, `${Date.now()}${ext}`);
    }
});
const upload = multer({ storage });

// This is temp code dependent on the dev machine
const baseURL = (ctx) => {
    switch (ctx) {
        case "c":
            return 'http://192.168.0.187:3050';
        case "m":
            return "http://192.168.0.164:3050";
        case "a":
            return "http://192.168.133.122:3050";
        case "mm":
            return "http://172.20.10.2:3050";
        default:
            return ''; // Fallback if ctx doesn't match any case
    }
};
//#endregion

//#region router config
const router = express.Router();
//#endregion

//#region Mongo Schemas
const User = require("../mods/User");
const Child = require("../mods/Child");

router.get("/", (req, res) => {
    res.send("Hello World Add Router");
});

router.post("/user", upload.single("image"), (req, res) => {
    const { username,
            firstname, 
            lastname, 
            password, 
            isAdmin,
            contactno
        } = req.body;

    const baseURLValue = baseURL("a"); // Adjust context as needed

    // Format the image path to ensure it is a valid URL
    // const imagepath = req.file ? baseURLValue + "/uploads/users/" + path.basename(req.file.path) : '';
    const imagepath = "/uploads/users/" + path.basename(req.file.path);

    bcrypt.hash(password, 10)
    .then(hash => {
        const user = new User({
            username: username,
            imageurl: imagepath,
            firstname: firstname,
            lastname: lastname,
            password: hash,
            contactno: contactno,
            isAdmin: isAdmin
        });
        user.save()
        .then(() => {
            res.status(200).json({
                code: 200,
                message: `User: ${username} added Successfully`,
                user: user
            });
        })
        .catch(err => {
            res.status(500).json({
                code: 500,
                message: "Error Adding new User",
                User: {}
            });
        });
    })
    .catch(err => {
        res.status(500).json({
            code: 500,
            message: "Error Hashing Password",
            User: {}
        });
    });
});

router.post("/child", upload.single("image"), (req, res) => {
    const {
        firstname,
        lastname,
        classname,
        parentID1,
        parentID2,
    } = req.body;

    // Get base URL based on context
    const baseURLValue = baseURL("c"); // Adjust context as needed

    // Format the image path to ensure it is a valid URL
    const imagepath = req.file ? baseURLValue + "/uploads/children/" + path.basename(req.file.path) : '';

    const child = new Child({
        imagepath: imagepath,
        firstname: firstname,
        lastname: lastname,
        classname: classname,
        parentID1: parentID1,
        parentID2: parentID2
    });

    child.save()
    .then(() => {
        res.status(200).json({
            code: 200,
            message: `Child ${firstname} ${lastname} added!`,
            child: child
        });
    })
    .catch(err => {
        console.log(err);
        res.status(500).json({
            code: 500,
            message: "Internal server error",
            child: {}
        });
    });
});

module.exports = router;
