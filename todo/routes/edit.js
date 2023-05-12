const router = require('express').Router()
const Todo = require('../models/todo')

router.get('/edit', (req, res) => {
    res.render('edit')
})

module.exports = router