'use strict';

// Register `studentEdit` component, along with its associated controller and template
angular.
    module('studentEdit').
    component('studentEdit', {
        templateUrl: 'app/templates/student-edit.html',
        controller: ['$scope', '$http', '$location', '$routeParams',
            function StudentEditController($scope, $http, $location, $routeParams) {
                var self = this;
                $http.get('Student/Details/' + $routeParams.studentId).then(function (response) {
                    self.student = response.data.student;
                    //alert(JSON.stringify(self.student));
                });
               // $scope.Edit = function () {
                    self.Edit = function () {
                    //alert($.param(angular.copy(self.student)));
                    $http({
                        method: 'POST',
                        url: '/Student/Edit/',
                        data: $.param(angular.copy(self.student)),
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                    })
                        .then(function (response) {
                            //alert(JSON.stringify(response.data) + "\n");
                            alert("Student, " + response.data.student.name + " updated successfully!");
                            $location.path('/students/' + response.data.student.id);
                        }, function (error) { alert(error.data);});
                };
            }
        ]
    });