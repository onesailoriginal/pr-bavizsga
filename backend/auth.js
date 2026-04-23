require('dotenv').config();
const JWT = require('jsonwebtoken');
const jwt_secret = process.env.JWT_SECRET;

const checkAuth = () =>  (req, res, next) => {
    try {
        const authHeader = req.headers.authorization;
        
        if (!authHeader) {
            return res.status(401).json({ message: 'AUTH_ERROR: Hiányzó fejléc' });
        }
        const decodedToken = JWT.verify(authHeader, jwt_secret);
        req.uid = decodedToken.user.id;
        next();
    } catch (err) {
        res.status(401).json({ message: 'AUTH_ERROR: Érvénytelen vagy lejárt token' });
    }
}

module.exports = checkAuth();
