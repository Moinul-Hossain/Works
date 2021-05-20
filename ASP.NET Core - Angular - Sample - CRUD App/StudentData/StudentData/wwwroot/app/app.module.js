// Define the `studentApp` module
angular.module('studentApp', [
  // ...which depends on the `studentList` module
  'studentList', 'ngRoute', 'studentDetail', 'studentDelete', 'studentCreate', 'studentEdit'
]);
