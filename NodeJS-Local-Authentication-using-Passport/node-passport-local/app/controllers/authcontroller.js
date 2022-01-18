var exports = module.exports = {}

exports.signup = function(req, res) {
    res.render('signup', {layout: false});
}

exports.signin = function(req, res) {
    res.render('signin', {layout: false});
}

exports.dashboard = function(req, res) {
    res.render('dashboard', {layout: false});
}

exports.logout = function(req, res) {
    req.session.destroy(function(err) {
        res.redirect('/');
    });
}