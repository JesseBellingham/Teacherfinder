var app = angular.module("app");

app.controller('ProfileCtrl', ["$scope", "$uibModal", "ProfileService", function($scope, $uibModal, profileService) {
    var vm = this;

    this.personDetails = {
        personName: null,
        location: {
            fullAddress: null,
            address1: null,
            suburb: null,
            city: null,
            state: null,
            country: null,
            postCode: null,
            latitude: null,
            longitude: null
        }
    };

    // this.getPersonData = function() {
    //     dashboardService.getCurrentUser().then(function(data) {
    //         vm.person = data.data;
    //     });
    // };

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

    // $scope.$watch('vm.personDetails.location', function(newValue, oldValue) {
    //     debugger;
    // });

    this.updatePersonLocation = function() {
        //var val = this.personDetails;
        var location = this.model;
        debugger;
        profileService.updatePersonLocation(location);
    }
    //this.getPersonData();
}]);