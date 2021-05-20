'use strict';

angular.
    module('studentApp').
    config(['$routeProvider',
        function config($routeProvider) {
            $routeProvider.
                when('/', {
                    template: '<student-list></student-list>'
                }).
                when('/students/create', {
                    template: '<student-create></student-create>'
                }).
                when('/students/:studentId', {
                    template: '<student-detail></student-detail>'
                }).
                when('/students/edit/:studentId', {
                    template: '<student-edit></student-edit>'
                }).
                when('/students/delete/:studentId', {
                    template: '<student-delete></student-delete>'
                }).
                otherwise('/');
        }
    ]);