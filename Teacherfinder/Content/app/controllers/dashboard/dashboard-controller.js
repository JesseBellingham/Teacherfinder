// the services and controllers should be in their own files, but I didn't want to spend to much time on this
// and I thought you'd be more interested in what I can do with the code, rather than where I put it

var app = angular.module("app");

// app.service("DashboardService", ["$rootScope", "$http", function($rootScope, $http) {
    
//     var dashboardService = {},
//         query = {
//             getLessonData: "/api/lesson/get",
//             createNewLesson: "/api/lesson/create",
//             getStudentsForEnrolment: "api/studentenrolment/get/",
//             enrolStudent: "api/enrolment/create",
//             createNewStudent: "api/student/create",
//             updateLessonDetails: "api/lesson/update"
//         };

//     dashboardService.getLessonData = function() {
//         return $http({
//             method: "GET",
//             url: query.getLessonData
//         }).success(function(data) {
//             return data;
//         }).error(function() {
//             console.log("error in " + query.getLessonData);
//         });
//     };

//     dashboardService.createNewLesson = function(newLesson) {
//         return $http({
//             method: "POST",
//             url: query.createNewLesson,
//             data: {
//                 lessonName: newLesson.lessonName,
//                 location: newLesson.location,
//                 teacherName: newLesson.teacherName
//             }
//         }).success(function(data) {
//             return data;
//         }).error(function() {
//             console.log("error in " + query.createNewLesson);
//             $rootScope.$broadcast("SERVER_ERROR", {
//                 // some server logging here if I had time
//             });
//         })
//     };

//     dashboardService.updateLessonDetails = function(lessonDetails) {
//         return $http({
//             method: "POST",
//             url: query.updateLessonDetails,
//             data: {
//                 lessonId: lessonDetails.lessonId,
//                 lessonName: lessonDetails.lessonName,
//                 location: lessonDetails.location,
//                 teacherName: lessonDetails.teacherName
//             }
//         }).success(function(data) {
//             return data;
//         }).error(function() {
//             console.log("error in " + query.updateLessonDetails);
//             $rootScope.$broadcast("SERVER_ERROR", {
//                 // some server logging here if I had time
//             });
//         })
//     };

//     dashboardService.createNewStudent = function(newStudent) {
//         return $http({
//             method: "POST",
//             url: query.createNewStudent,
//             data: {
//                 studentFirstName: newStudent.studentFirstName,
//                 studentLastName: newStudent.studentLastName,
//                 studentAge: newStudent.studentAge,
//             }
//         }).success(function(data) {
//             return data;
//         }).error(function() {
//             console.log("error in " + query.createNewStudent);
//             $rootScope.$broadcast("SERVER_ERROR", {
//                 // some server logging here if I had time
//             });
//         })
//     };

//     dashboardService.getStudentsForEnrolment = function(lessonId) {
//         return $http({
//             method: "GET",
//             url: query.getStudentsForEnrolment + lessonId
//         }).success(function(data) {
//             return data;
//         }).error(function() {
//             console.log("error in " + query.getStudentsForEnrolment);
//         })
//     };

//     dashboardService.enrolStudent = function(studentId, lessonId) {
//         return $http({
//             method: "POST",
//             url: query.enrolStudent,
//             data: {
//                 studentId: studentId,
//                 lessonId: lessonId
//             }
//         }).success(function(data) {
//             return data;
//         }).error(function() {
//             console.log("error in " + query.enrolStudent);
//         })
//     };

//     return dashboardService;
// }])
app.controller('DashboardCtrl', ["$scope", "$uibModal", "DashboardService", function($scope, $uibModal, dashboardService) {
    var vm = this;
    this.getPersonData = function() {
        dashboardService.getCurrentUser().then(function(data) {
            vm.person = data.data;
        });
    };

    this.createNewLesson = function() {
        var modalInstance = $uibModal.open({
            templateUrl: '/Content/template/create-lesson.html',
            controller: 'CreateLessonCtrl as vm',
            resolve: {
                creatingLesson: true,
                creatingStudent: false
            }
        });

        modalInstance.result.then(function(result) {
            if (result) {
                this.lessons.push(result);
            }
        });
    };

    this.createNewStudent = function() {
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

    this.addEnrolments = function(lessonId) {
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
            this.getLessonData();
        });
    };

    this.editLessonDetails = function(lessonDetails) {
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
            this.getLessonData();
        });
    }

    this.getPersonData();
}])
// .controller('CreateEntityCtrl', ["$rootScope", "$scope", "$timeout", "$uibModalInstance", "DashboardService", function($rootScope, $scope, $timeout, $uibModalInstance, dashboardService) {
//     this.lessonDetails = {
//         lessonName: null,
//         location: null,
//     };

//     this.newStudent = {
//         studentFirstName: null,
//         studentLastName: null,
//         studentAge: null,
//     };

//     $rootScope.$on("SERVER_ERROR", function() {
//         this.serverError = true;

//         $timeout(function() {
//             this.serverError = false;
//         }, 5000)
//     })

//     this.close = function() {
//         $uibModalInstance.close();
//     };

//     this.createNewLesson = function() {
//         // quick and dirty client-side validation
//         this.lessonNameMissing = false;
//         if (this.lessonDetails.lessonName === null) {
//             this.lessonNameMissing = true
//         }
//         else {
//             dashboardService.createNewLesson(this.lessonDetails).then(function(data) {
//                 if (data.data) {
//                     this.lessonDetails.lessonId = data.data;
//                     $uibModalInstance.close(this.lessonDetails);
//                 }
//             });
//         }
//     };

//     this.createNewStudent = function() {
//         // quick and even dirtier client-side validation
//         this.firstNameMissing = false;
//         this.lastNameMissing = false;
//         if (!this.newStudent.studentFirstName) {
//             this.firstNameMissing = true;
//         }
//         if (!this.newStudent.studentLastName) {
//             this.lastNameMissing = true;
//         }
//         if (!this.firstNameMissing && !this.lastNameMissing) {
//             dashboardService.createNewStudent(this.newStudent).then(function(data) {
//                 if (data.data) {
//                     this.newStudent.studentFirstName = null;
//                     this.newStudent.studentLastName = null;
//                     this.newStudent.studentAge = null;
//                     this.success = true;
//                 }
//             });
//         }
//     };
// }])
.controller('AddEnrolmentsCtrl', ["$scope", "$uibModalInstance", "DashboardService", "lessonId", function($scope, $uibModalInstance, dashboardService, lessonId) {
    
    this.students = [];

    this.close = function() {
        $uibModalInstance.close();
    };

    this.enrolStudent = function(studentId) {
        dashboardService.enrolStudent(studentId, lessonId).then(function(data) {
            if (data.data) {
                var student = data.data,
                    found = false;
                angular.forEach(this.enrollableStudents, function(es, index) {
                    if (!found) {
                        if (student.studentId === es.studentId) {
                            this.enrollableStudents.splice(index, 1);
                            found = true;
                        }
                    }
                });
                this.existingStudents.push(student);
                this.getEnrolmentData(lessonId);
            }
        });
    };

    this.getEnrolmentData = function(lessonId) {
        dashboardService.getStudentsForEnrolment(lessonId).then(function(data) {
            if (data.data) {
                this.enrollableStudents = data.data.enrollableStudents;
                this.existingStudents = data.data.existingStudents;
            }
        });
    };

    this.getEnrolmentData(lessonId);
}])
.controller('EditLessonCtrl', ["$scope", "$uibModalInstance", "DashboardService", "lessonDetails", function($scope, $uibModalInstance, dashboardService, lessonDetails) {
    
    this.lessonDetails = {
        lessonId: lessonDetails.lessonId,
        lessonName: lessonDetails.lessonName,
        location: lessonDetails.location,
        teacherName: lessonDetails.teacherName
    };

    this.close = function() {
        $uibModalInstance.close();
    };

    this.updateLessonDetails = function(lessonDetails) {
        dashboardService.updateLessonDetails(lessonDetails).then(function(data) {
            if (data.data) {
                this.success = true;
            }
        });
    };
}]);