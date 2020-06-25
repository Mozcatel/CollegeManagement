var app = angular.module("CMApp", ['ngRoute', 'ngResource']);

app
    .config(['$locationProvider', function ($locationProvider) {
        $locationProvider.html5Mode(true);
    }])
    .config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider
                .when('/home', { templateUrl: './Home/Index.html', controller: 'HomeController' })
                .when('/courses', { templateUrl: './Courses/Index.html', controller: 'CoursesController' })
                .when('/courses/create', { templateUrl: './Courses/Create.html', controller: 'CoursesController' })
                .when('/courses/:id', { templateUrl: './Courses/Details.html', controller: 'CoursesController' })
                .when('/courses/:id/delete', { templateUrl: './Courses/Delete.html', controller: 'CoursesController' })
                .when('/courses/:id/edit', { templateUrl: './Courses/Edit.html', controller: 'CoursesController' })
                .when('/grades', { templateUrl: './Grades/Index.html', controller: 'GradesController' })
                .when('/grades/create', { templateUrl: './Grades/Create.html', controller: 'GradesController' })
                .when('/grades/:id', { templateUrl: './Grades/Details.html', controller: 'GradesController' })
                .when('/grades/:id/delete', { templateUrl: './Grades/Delete.html', controller: 'GradesController' })
                .when('/grades/:id/edit', { templateUrl: './Grades/Edit.html', controller: 'GradesController' })
                .when('/students', { templateUrl: './Students/Index.html', controller: 'StudentsController' })
                .when('/students/create', { templateUrl: './Students/Create.html', controller: 'StudentsController' })
                .when('/students/:id', { templateUrl: './Students/Details.html', controller: 'StudentsController' })
                .when('/students/:id/delete', { templateUrl: './Students/Delete.html', controller: 'StudentsController' })
                .when('/students/:id/edit', { templateUrl: './Students/Edit.html', controller: 'StudentsController' })
                .when('/subjects', { templateUrl: './Subjects/Index.html', controller: 'SubjectsController' })
                .when('/subjects/create', { templateUrl: './Subjects/Create.html', controller: 'SubjectsController' })
                .when('/subjects/:id', { templateUrl: './Subjects/Details.html', controller: 'SubjectsController' })
                .when('/subjects/:id/delete', { templateUrl: './Subjects/Delete.html', controller: 'SubjectsController' })
                .when('/subjects/:id/edit', { templateUrl: './Subjects/Edit.html', controller: 'SubjectsController' })
                .when('/teachers', { templateUrl: './Teachers/Index.html', controller: 'TeachersController' })
                .when('/teachers/create', { templateUrl: './Teachers/Create.html', controller: 'TeachersController' })
                .when('/teachers/:id', { templateUrl: './Teachers/Details.html', controller: 'TeachersController' })
                .when('/teachers/:id/delete', { templateUrl: './Teachers/Delete.html', controller: 'TeachersController' })
                .when('/teachers/:id/edit', { templateUrl: './Teachers/Edit.html', controller: 'TeachersController' })
                .otherwise({ redirectTo: '/' })
        }
    ])
    .controller('RootController', ['$scope', '$route', '$routeParams', '$location',
        function ($scope, $route, $routeParams, $location) {
        }])