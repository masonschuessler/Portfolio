const express = require('express')
const mongoose = require('mongoose')
const app = express()
const port = process.env.port || 9988

// Connect to mongodb
mongoose.connect('mongodb://localhost:27017/todo_list')

// Add middleware
app.use(express.urlencoded({ extended: true}))
app.use(express.static('public'))
app.set('view engine', 'ejs')

// Create routes
app.use(require('./routes/index'))
app.use(require('./routes/todos'))
app.use(require('./routes/showtodos'))

app.listen(port, () => {
    console.log(`App running on port ${port}`)
})