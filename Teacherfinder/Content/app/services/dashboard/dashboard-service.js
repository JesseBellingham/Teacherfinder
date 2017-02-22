var app = angular.module("app");

app.service("DashboardService", ["$rootScope", "$http", function($rootScope, $http) {
    
    var dashboardService = {},
        query = {
            getLessonData: "/api/lesson/get",
            createNewLesson: "/api/lesson/create",
            getStudentsForEnrolment: "api/studentenrolment/get/",
            enrolStudent: "api/enrolment/create",
            createNewStudent: "api/student/create",
            updateLessonDetails: "api/lesson/update",
            getCurrentLoggedInUser: "api/person/get/"
        };

    dashboardService.getLessonData = function() {
        return $http({
            method: "GET",
            url: query.getLessonData
        }).success(function(data) {
            return data;
        }).error(function() {
            console.log("error in " + query.getLessonData);
        });
    };

    dashboardService.createNewLesson = function(newLesson) {
        return $http({
            method: "POST",
            url: query.createNewLesson,
            data: {
                lessonName: newLesson.lessonName,
                location: newLesson.location,
                teacherName: newLesson.teacherName
            }
        }).success(function(data) {
            return data;
        }).error(function() {
            console.log("error in " + query.createNewLesson);
            $rootScope.$broadcast("SERVER_ERROR", {
                // some server logging here if I had time
            });
        })
    };

    dashboardService.updateLessonDetails = function(lessonDetails) {
        return $http({
            method: "POST",
            url: query.updateLessonDetails,
            data: {
                lessonId: lessonDetails.lessonId,
                lessonName: lessonDetails.lessonName,
                location: lessonDetails.location,
                teacherName: lessonDetails.teacherName
            }
        }).success(function(data) {
            return data;
        }).error(function() {
            console.log("error in " + query.updateLessonDetails);
            $rootScope.$broadcast("SERVER_ERROR", {
                // some server logging here if I had time
            });
        })
    };

    dashboardService.createNewStudent = function(newStudent) {
        return $http({
            method: "POST",
            url: query.createNewStudent,
            data: {
                studentFirstName: newStudent.studentFirstName,
                studentLastName: newStudent.studentLastName,
                studentAge: newStudent.studentAge,
            }
        }).success(function(data) {
            return data;
        }).error(function() {
            console.log("error in " + query.createNewStudent);
            $rootScope.$broadcast("SERVER_ERROR", {
                // some server logging here if I had time
            });
        })
    };

    dashboardService.getStudentsForEnrolment = function(lessonId) {
        return $http({
            method: "GET",
            url: query.getStudentsForEnrolment + lessonId
        }).success(function(data) {
            return data;
        }).error(function() {
            console.log("error in " + query.getStudentsForEnrolment);
        })
    };

    dashboardService.enrolStudent = function(studentId, lessonId) {
        return $http({
            method: "POST",
            url: query.enrolStudent,
            data: {
                studentId: studentId,
                lessonId: lessonId
            }
        }).success(function(data) {
            return data;
        }).error(function() {
            console.log("error in " + query.enrolStudent);
        })
    };

    dashboardService.getCurrentUser = function() {
        return $http({
            method: "GET",
            url: query.getCurrentLoggedInUser// + 0
        }).then(function(data) {
            return data;
        }, function(error) {
            console.log("error in " + query.getCurrentLoggedInUser);
        });
    };

    return dashboardService;
}]);