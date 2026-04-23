require('dotenv').config()
const express = require('express')
const cors = require('cors')
const app = express()
const {sequelize} = require('./dbHandler')
const PORT = process.env.PORT

app.use(express.json())
app.use(cors())

//ROUTES
const userRoutes = require('./routes/userRoutes')
const planeRoutes = require('./routes/planeRoutes')
app.use('/user/', userRoutes)
app.use('/planes/', planeRoutes)

function startServer(){
    // sequelize.sync({alter: true})
    app.listen(PORT, () => { console.log(`The server is run on http://localhost:${PORT}`)})
}

startServer()