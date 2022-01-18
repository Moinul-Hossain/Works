const express = require('express');

const session    = require('express-session');

const { engine } = require('express-handlebars');

const app = express();

const passport   = require('passport');

const env = require('dotenv').config();


// parse requests of content-type: application/json
app.use(express.json());


// parse requests of content-type: application/x-www-form-urlencoded
app.use(express.urlencoded({extended: true}));


// For Passport
app.use(session({ secret: 'keyboard cat',  resave: true, saveUninitialized:true})); // session secret

app.use(passport.initialize());

app.use(passport.session()); // persistent login sessions


//For Handlebars
app.set('views', './app/views');

app.engine('hbs', engine({
    extname: '.hbs'
}));

app.set('view engine', '.hbs');

app.get('/', function(req, res){
    res.send('<h1>Passport-Local Authentication example</h1><hr/>');
});

//Models
var models = require("./app/models");

//Routes
// var authRoute = require('./app/routes/auth.js')(app);
var authRoute = require('./app/routes/auth.js')(app, passport);

//load passport strategies
require('./app/config/passport/passport.js')(passport, models.user);


//Sync Database
models.sequelize.sync().then(function() {
    console.log('Database synced!');
}).catch(function(err) {
    console.log(err, "Something went wrong with the Database Update!");
});


app.listen(5000, function(err){
    
    if(!err)
        console.log('Listening from 5000 port...');
    else 
        console.log(err);

});