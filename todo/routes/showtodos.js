const router = require('express').Router()
const Todo = require('../models/todo')

router.get('/showtodos', async (req, res) => {
    const allTodos = await Todo.find()
    res.render('showtodos', {todo: allTodos})
})

module.exports = router