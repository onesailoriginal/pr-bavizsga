require('dotenv').config()
const express = require('express')
const router = express.Router()
const {Users} = require('../dbHandler')
const jwt = require('jsonwebtoken')

router.post('/register', async (req,res)=>{
    const {username, password} = req.body;
    if(!username || !password) return res.status(400).json({message: 'Hiányzó adatok'})
    try{
        const [user, created] = await Users.findOrCreate({
            where: { username },
            defaults: {
              username, password
            },
          });
        if(!created){
            return res.status(409).json({message: 'Már regisztrált felhasználó'})
        }
        return res.status(201).json({message: 'Felhasználó regisztrálva'})
    }catch(err){
        console.log(err)
        return res.status(500).json({message: 'Szerverhiba történt'})
    }
})

router.post('/login', async (req,res)=>{
    console.log("BODY:", req.body)
    const {username, password} = req.body;
    if(!username || !password) return res.status(400).json({message: 'Hiányzó adatok'})
    try{
        const oneUser = await Users.findOne({
            where: {username, password}
        })
        if(!oneUser) return res.status(401).json({message: 'Hibás adatok'})

        const token = jwt.sign({user: oneUser}, process.env.JWT_SECRET, { expiresIn: process.env.JWT_EXPIRES_IN });

        return res.status(200).json({message: 'Sikeres bejelentkezés', token})
    }catch(err){
        console.log(err.message)
        return res.status(500).json({message: 'Szerverhiba történt'})
    }
})

module.exports = router