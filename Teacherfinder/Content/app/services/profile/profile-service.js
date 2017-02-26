var app = angular.module("app");

app.service("ProfileService", ["$rootScope", "$http", function($rootScope, $http) {
    
    var profileService = {},
        query = {
            // getLessonData: "/api/lesson/get",
            // createNewLesson: "/api/lesson/create",
            // getStudentsForEnrolment: "api/studentenrolment/get/",
            // enrolStudent: "api/enrolment/create",
            // createNewStudent: "api/student/create",
            updatePersonLocation: "/api/person/updatelocation",
            // getCurrentLoggedInUser: "api/person/get/"
        };

    // profileService.getLessonData = function() {
    //     return $http({
    //         method: "GET",
    //         url: query.getLessonData
    //     }).success(function(data) {
    //         return data;
    //     }).error(function() {
    //         console.log("error in " + query.getLessonData);
    //     });
    // };

    // profileService.createNewLesson = function(newLesson) {
    //     return $http({
    //         method: "POST",
    //         url: query.createNewLesson,
    //         data: {
    //             lessonName: newLesson.lessonName,
    //             location: newLesson.location,
    //             teacherName: newLesson.teacherName
    //         }
    //     }).success(function(data) {
    //         return data;
    //     }).error(function() {
    //         console.log("error in " + query.createNewLesson);
    //         $rootScope.$broadcast("SERVER_ERROR", {
    //             // some server logging here if I had time
    //         });
    //     })
    // };

    profileService.updatePersonLocation = function(location) {
        return $http({
            method: "POST",
            url: query.updatePersonLocation,
            data: {
                addressLine1: location.address_1,
                suburb: location.suburb,
                city: location.city,
                state: location.state,
                country: location.country,
                postCode: location.postCode,
                latitude: location.latitude,
                longitude: location.longitude
            }
        }).then(function(data) {
            return data;
        }, function(error) {
            console.log("error in " + query.updatePersonLocation);
            $rootScope.$broadcast("SERVER_ERROR", {
                // some server logging here if I had time
            });
        })
    };

    // profileService.createNewStudent = function(newStudent) {
    //     return $http({
    //         method: "POST",
    //         url: query.createNewStudent,
    //         data: {
    //             studentFirstName: newStudent.studentFirstName,
    //             studentLastName: newStudent.studentLastName,
    //             studentAge: newStudent.studentAge,
    //         }
    //     }).success(function(data) {
    //         return data;
    //     }).error(function() {
    //         console.log("error in " + query.createNewStudent);
    //         $rootScope.$broadcast("SERVER_ERROR", {
    //             // some server logging here if I had time
    //         });
    //     })
    // };

    // profileService.getStudentsForEnrolment = function(lessonId) {
    //     return $http({
    //         method: "GET",
    //         url: query.getStudentsForEnrolment + lessonId
    //     }).success(function(data) {
    //         return data;
    //     }).error(function() {
    //         console.log("error in " + query.getStudentsForEnrolment);
    //     })
    // };

    // profileService.enrolStudent = function(studentId, lessonId) {
    //     return $http({
    //         method: "POST",
    //         url: query.enrolStudent,
    //         data: {
    //             studentId: studentId,
    //             lessonId: lessonId
    //         }
    //     }).success(function(data) {
    //         return data;
    //     }).error(function() {
    //         console.log("error in " + query.enrolStudent);
    //     })
    // };

    // profileService.getCurrentUser = function() {
    //     return $http({
    //         method: "GET",
    //         url: query.getCurrentLoggedInUser// + 0
    //     }).then(function(data) {
    //         return data;
    //     }, function(error) {
    //         console.log("error in " + query.getCurrentLoggedInUser);
    //     });
    // };

    return profileService;
}]);