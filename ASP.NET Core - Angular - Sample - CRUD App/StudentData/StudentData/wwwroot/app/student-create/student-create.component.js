'use strict';

// Register `studentCreate` component, along with its associated controller and template
angular.
    module('studentCreate').
    component('studentCreate', {
        templateUrl: 'app/templates/student-create.html',
        controller: ['$scope', '$http', '$location',
            function StudentCreateController($scope, $http, $location) {                
                $scope.Create = function () {                     
                    $http({                        
                        method: 'POST',
                        url: '/Student/Create/',
                        data: $.param($scope.student),
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                        })
                        .then(function (response) {
                            alert("New student " + response.data.student.name + " created successfully!");
                            $location.path('/students/' + response.data.student.id);
                        }, function (error) { alert(error.data);});
                };
            }
        ]
    });