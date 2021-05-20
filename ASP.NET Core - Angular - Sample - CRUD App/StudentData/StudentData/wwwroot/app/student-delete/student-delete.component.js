'use strict';
// Register `studentDelete` component, along with its associated controller and template
angular.
    module('studentDelete').
    component('studentDelete', {
       
        controller: ['$scope', '$http', '$routeParams', '$location',
            function StudentDeleteController($scope, $http, $routeParams, $location) {                
                $scope.Delete = function () {
                    alert('');
                };
                //$http.get('Student/Delete/' + $routeParams.studentId).then
                //    (function (response) {                                            
                //    $location.path('/');
                //});
            }
        ]
    });