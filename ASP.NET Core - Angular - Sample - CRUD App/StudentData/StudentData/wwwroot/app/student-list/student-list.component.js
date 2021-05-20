/* Register the `studentList` component on the `studentList` module, */
angular.
    module('studentList').
    component('studentList', {
    templateUrl: 'app/templates/student-list.html',
        controller: ['$http', '$location', function StudentListController($http, $location) {
            var self = this;
            self.orderProp = 'age';

            //$scope.ConfirmDelete = function (student) {
            //    var delConfirm = confirm("Are you sure to delete "
            //        + student + "?");
            //    if (delConfirm)
            //        return true;
            //    else
            //        return false;                
            //};
            self.Delete = function (id, name) {
                var confirmDelete = confirm("Are you sure to delete the student, " + name + "?");
                if (confirmDelete)
                    $location.path('/students/delete/' + id);
            };

            $http.get('/Student/Index').then(function (response) {
                self.students = response.data;                
            });
        }]
  });
