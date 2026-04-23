require('dotenv').config()
const express = require('express')
const router = express.Router()
const {Users, Airplanes} = require('../dbHandler')
const jwt = require('jsonwebtoken')
const checkAuth = require('../auth')


router.get('/', async (req,res)=>{
    //const planes = await Airplanes.findAll()
    return res.status(200).json(await Airplanes.findAll())
})

 
router.get('/my', checkAuth,  async(req, res) => {
    const user_id = req.uid;
    //const myPlanes = await Airplanes.findAll({ where: { owner_id: user_id } });
    return res.status(200).json(await Airplanes.findAll({ where: { owner_id: user_id } }));
});

router.post('/', checkAuth, async (req,res)=>{
    const {name, type, capacity, range} = req.body;
    if(!name || !type || !capacity || !range) return res.status(400).json({message: 'Hiányzó adatok'})
    try{
        if(capacity < 0 || range < 0){
            return res.status(400).json({message: 'Hibás adatok'})
        }
        const owner_id = req.uid
        const [planes, created] = await Airplanes.findOrCreate({
            where: { name },
            defaults: {
              name, type, capacity, range, owner_id
            },
          });
        if(!created){
            return res.status(409).json({message: 'Már regisztrált repülő'})
        }
        return res.status(201).json({message: 'Repülő regisztrálva', planes})
    }catch(err){
        console.error(err.message)
        return res.status(500).json({message: 'Szerverhiba történt'})
    }
})

router.delete('/:id', checkAuth,  async(req,res)=>{
    const { id } = req.params; 
    const owner_id = req.uid

    try{
        const deleted = await Airplanes.destroy({
            where: {
              id,
              owner_id
            },
          });
        if(!deleted) return res.status(404).json({message: 'Nem létezik ilyen gép'})
        return res.status(200).json({message: 'Sikeres törlés'})
    }catch(err){
        console.error(err.message)
        return res.status(500).json({message: 'Szerverhiba történt'})
    }
    
})


module.exports = router
