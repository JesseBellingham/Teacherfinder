// the services and controllers should be in their own files, but I didn't want to spend to much time on this
// and I thought you'd be more interested in what I can do with the code, rather than where I put it

var app = angular.module("app", ['ui.bootstrap']);

app.service("HomeService", ["$rootScope", "$http", function($rootScope, $http) {
    
    var homeService = {},
        query = {
            getLessonData: "/api/lesson/get",
            createNewLesson: "/api/lesson/create",
            getStudentsForEnrolment: "api/studentenrolment/get/",
            enrolStudent: "api/enrolment/create",
            createNewStudent: "api/student/create",
            updateLessonDetails: "api/lesson/update"
        };

    homeService.getLessonData = function() {
        return $http({
            method: "GET",
            url: query.getLessonData
        }).success(function(data) {
            return data;
        }).error(function() {
            console.log("error in " + query.getLessonData);
        });
    };

    homeService.createNewLesson = function(newLesson) {
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

    homeService.updateLessonDetails = function(lessonDetails) {
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

    homeService.createNewStudent = function(newStudent) {
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

    homeService.getStudentsForEnrolment = function(lessonId) {
        return $http({
            method: "GET",
            url: query.getStudentsForEnrolment + lessonId
        }).success(function(data) {
            return data;
        }).error(function() {
            console.log("error in " + query.getStudentsForEnrolment);
        })
    };

    homeService.enrolStudent = function(studentId, lessonId) {
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

    return homeService;
}])
.controller('HomeCtrl', ["$scope", "$uibModal", "HomeService", function($scope, $uibModal, homeService) {
    $scope.getLessonData = function() {
        homeService.getLessonData().then(function(data) {
            $scope.lessones = data.data;
        });
    };

    $scope.createNewLesson = function() {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/template/create-lesson.html',
            controller: 'CreateEntityCtrl',
            resolve: {
                creatingLesson: true,
                creatingStudent: false
            }
        });

        modalInstance.result.then(function(result) {
            if (result) {
                $scope.lessones.push(result);
            }
        });
    };

    $scope.createNewStudent = function() {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/template/create-student.html',
            controller: 'CreateEntityCtrl',
            resolve: {
                creatingLesson: false,
                creatingStudent: true
            }
        });

        modalInstance.result.then(function(result) {
            // might have planned to do something here
        });
    };

    $scope.addEnrolments = function(lessonId) {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/template/add-enrolments.html',
            controller: 'AddEnrolmentsCtrl',
            resolve: {
                lessonId: function() {
                    return lessonId;
                }
            }
        });

        modalInstance.result.then(function(result) {
            $scope.getLessonData();
        });
    };

    $scope.editLessonDetails = function(lessonDetails) {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/template/create-lesson.html',
            controller: 'EditLessonCtrl',
            resolve: {
                lessonDetails: function() {
                    return lessonDetails;
                }
            }
        });

        modalInstance.result.then(function(result) {
            $scope.getLessonData();
        });
    }

    $scope.getLessonData();
}])
.controller('CreateEntityCtrl', ["$rootScope", "$scope", "$timeout", "$uibModalInstance", "HomeService", function($rootScope, $scope, $timeout, $uibModalInstance, homeService) {
    $scope.lessonDetails = {
        lessonName: null,
        location: null,
    };

    $scope.newStudent = {
        studentFirstName: null,
        studentLastName: null,
        studentAge: null,
    };

    $rootScope.$on("SERVER_ERROR", function() {
        $scope.serverError = true;

        $timeout(function() {
            $scope.serverError = false;
        }, 5000)
    })

    $scope.close = function() {
        $uibModalInstance.close();
    };

    $scope.createNewLesson = function() {
        // quick and dirty client-side validation
        $scope.lessonNameMissing = false;
        if ($scope.lessonDetails.lessonName === null) {
            $scope.lessonNameMissing = true
        }
        else {
            homeService.createNewLesson($scope.lessonDetails).then(function(data) {
                if (data.data) {
                    $scope.lessonDetails.lessonId = data.data;
                    $uibModalInstance.close($scope.lessonDetails);
                }
            });
        }
    };

    $scope.createNewStudent = function() {
        // quick and even dirtier client-side validation
        $scope.firstNameMissing = false;
        $scope.lastNameMissing = false;
        if (!$scope.newStudent.studentFirstName) {
            $scope.firstNameMissing = true;
        }
        if (!$scope.newStudent.studentLastName) {
            $scope.lastNameMissing = true;
        }
        if (!$scope.firstNameMissing && !$scope.lastNameMissing) {
            homeService.createNewStudent($scope.newStudent).then(function(data) {
                if (data.data) {
                    $scope.newStudent.studentFirstName = null;
                    $scope.newStudent.studentLastName = null;
                    $scope.newStudent.studentAge = null;
                    $scope.success = true;
                }
            });
        }
    };
}])
.controller('AddEnrolmentsCtrl', ["$scope", "$uibModalInstance", "HomeService", "lessonId", function($scope, $uibModalInstance, homeService, lessonId) {
    
    $scope.students = [];

    $scope.close = function() {
        $uibModalInstance.close();
    };

    $scope.enrolStudent = function(studentId) {
        homeService.enrolStudent(studentId, lessonId).then(function(data) {
            if (data.data) {
                var student = data.data,
                    found = false;
                angular.forEach($scope.enrollableStudents, function(es, index) {
                    if (!found) {
                        if (student.studentId === es.studentId) {
                            $scope.enrollableStudents.splice(index, 1);
                            found = true;
                        }
                    }
                });
                $scope.existingStudents.push(student);
                $scope.getEnrolmentData(lessonId);
            }
        });
    };

    $scope.getEnrolmentData = function(lessonId) {
        homeService.getStudentsForEnrolment(lessonId).then(function(data) {
            if (data.data) {
                $scope.enrollableStudents = data.data.enrollableStudents;
                $scope.existingStudents = data.data.existingStudents;
            }
        });
    };

    $scope.getEnrolmentData(lessonId);
}])
.controller('EditLessonCtrl', ["$scope", "$uibModalInstance", "HomeService", "lessonDetails", function($scope, $uibModalInstance, homeService, lessonDetails) {
    
    $scope.lessonDetails = {
        lessonId: lessonDetails.lessonId,
        lessonName: lessonDetails.lessonName,
        location: lessonDetails.location,
        teacherName: lessonDetails.teacherName
    };

    $scope.close = function() {
        $uibModalInstance.close();
    };

    $scope.updateLessonDetails = function(lessonDetails) {
        homeService.updateLessonDetails(lessonDetails).then(function(data) {
            if (data.data) {
                $scope.success = true;
            }
        });
    };
}]);