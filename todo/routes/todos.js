const router = require('express').Router()
const Todo = require('../models/todo')

router
    // Hit <submit> button
    // Attempt to add new todo
    .post('/add/todo', (req, res) => {
    const { todo } = req.body
    const newTodo = new Todo({ todo })

    // Save the todo
    newTodo
        .save()
        .then(() => {
            console.log('Successfully added new task')
            res.redirect('/showtodos')
        })
        .catch((err) => {
            console.log(err)})
    })

    // Hit the delete button for
    // the todo item
    .get('/delete/todo/:_id', (req, res) => {
        const { _id } = req.params
        Todo.deleteOne({ _id })
        .then(() => {
            console.log("Successfully deleted existing task")
            res.redirect('/showtodos')
        })
    .catch((err) => {
        console.log(err)})
    })

    // Hit edit button

module.exports = router