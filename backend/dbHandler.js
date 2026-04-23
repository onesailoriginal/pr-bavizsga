const { Sequelize, DataTypes } = require('sequelize');
const sequelize = new Sequelize('probavizsga', 'root', '', {
    host: 'localhost',
    dialect: 'mysql'
});


const Airplanes = sequelize.define(
    'Airplanes',
    {
        
        id: {
            type: DataTypes.INTEGER,
            allowNull: false,
            autoIncrement: true,
            primaryKey: true
        },
        name: {
            type: DataTypes.STRING,
            allowNull: false
        },
        type: {
            type: DataTypes.STRING,
            allowNull: false
        },
        capacity: {
            type: DataTypes.INTEGER,
            allowNull: false
        },
        range: {
            type: DataTypes.INTEGER,
            allowNull: false
        },
        owner_id:{
            type: DataTypes.INTEGER,
            allowNull: false
        }
    },
    {
    },
);


const Users = sequelize.define(
    'Users',
    {
        id: {
            type: DataTypes.INTEGER,
            allowNull: false,
            autoIncrement: true,
            primaryKey: true
        },
        username: {
            type: DataTypes.STRING,
            allowNull: false
        },
        password: {
            type: DataTypes.STRING,
            allowNull: false
        }
    },
    {
    },
);

Users.hasMany(Airplanes)
Airplanes.belongsTo(Users)

module.exports = {sequelize, Airplanes, Users}