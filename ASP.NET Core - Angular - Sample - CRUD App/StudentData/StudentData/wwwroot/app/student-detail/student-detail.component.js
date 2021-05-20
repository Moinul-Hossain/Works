'use strict';

// Register `studentDetail` component, along with its associated controller and template
angular.
    module('studentDetail').
    component('studentDetail', {
        templateUrl: 'app/templates/student-detail.html',
        controller: ['$http', '$location', '$routeParams',
            function StudentDetailController($http, $location, $routeParams) {
                var self = this;

                self.Delete = function (id, name) {
                    var confirmDelete = confirm("Are you sure to delete the student, " + name + "?");
                    if (confirmDelete)
                        $location.path('/students/delete/' + id);
                };

                $http.get('Student/Details/' + $routeParams.studentId).then(function (response) {
                    self.student = response.data;
                });
            }
        ]
    });