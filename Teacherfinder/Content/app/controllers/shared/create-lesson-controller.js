var app = angular.module("app");
app.controller('CreateLessonCtrl', ["$rootScope", "$scope", "$timeout", "$uibModalInstance", "DashboardService", function($rootScope, $scope, $timeout, $uibModalInstance, dashboardService) {
    var vm = this;
    this.lessonDetails = {
        lessonName: null,
        location: null,
        lessonType: {
            skype: false,
            faceToFace: false,
            clinic: false
        }
    };

    // this.newStudent = {
    //     studentFirstName: null,
    //     studentLastName: null,
    //     studentAge: null,
    // };

    $rootScope.$on("SERVER_ERROR", function() {
        this.serverError = true;

        $timeout(function() {
            this.serverError = false;
        }, 5000)
    })

    this.close = function() {
        $uibModalInstance.close();
    };

    this.createNewLesson = function() {
        // quick and dirty client-side validation
        this.lessonNameMissing = false;
        if (this.lessonDetails.lessonName === null) {
            this.lessonNameMissing = true
        }
        else {
            dashboardService.createNewLesson(this.lessonDetails).then(function(data) {
                if (data.data) {
                    this.lessonDetails.lessonId = data.data;
                    $uibModalInstance.close(this.lessonDetails);
                }
            });
        }
    };

//     $scope.$on('gmPlacesAutocomplete::placeChanged', function(){
//       var location = this.lessonDetails.location.getPlace().geometry.location;
//       this.lessonDetails.location.latitude = location.lat();
//       this.lessonDetails.location.longitude = location.lng();
//       //$scope.$apply();
//   });

    // this.createNewStudent = function() {
    //     // quick and even dirtier client-side validation
    //     this.firstNameMissing = false;
    //     this.lastNameMissing = false;
    //     if (!this.newStudent.studentFirstName) {
    //         this.firstNameMissing = true;
    //     }
    //     if (!this.newStudent.studentLastName) {
    //         this.lastNameMissing = true;
    //     }
    //     if (!this.firstNameMissing && !this.lastNameMissing) {
    //         dashboardService.createNewStudent(this.newStudent).then(function(data) {
    //             if (data.data) {
    //                 this.newStudent.studentFirstName = null;
    //                 this.newStudent.studentLastName = null;
    //                 this.newStudent.studentAge = null;
    //                 this.success = true;
    //             }
    //         });
    //     }
    // };
}]);