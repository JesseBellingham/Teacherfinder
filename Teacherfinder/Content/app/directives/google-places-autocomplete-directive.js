angular.module('app').directive('googleplacesautocomplete', function() {
    return {
        require: 'ngModel',
        replace: true,
        scope: {
            ngModel: '=',
            address1: "=",
            suburb: "=",
            city: "=",
            state: "=",
            country: "=",
            postcode: '=',
            latitude: '=',
            longitude: '='
        },
        template: '<input class="form-control" type="text">',
        link: function(scope, element, attrs, model) {
            var options = {
                types: [],
                componentRestrictions: {}
            };    

            var autocomplete = new google.maps.places.Autocomplete(element[0], options);

            google.maps.event.addListener(autocomplete, 'place_changed', function() {
                scope.$apply(function() {
                    var place = autocomplete.getPlace();
                    var components = place.address_components;  // from Google API place object   

                    scope.address1 = components[0].short_name + " " + components[1].short_name;
                    scope.suburb = components[2].short_name;
                    scope.city = components[3].short_name;
                    scope.state = components[4].short_name;
                    scope.country = components[5].long_name;
                    scope.postcode = components[6].short_name;
                    scope.latitude = place.geometry.location.lat().toFixed(6);
                    scope.longitude = place.geometry.location.lng().toFixed(6);

                    model.$setViewValue(element.val());
                    //$state.go('home');
                    //scope.Fn_setCookieData(latitude, longitude, countrycode);
                    // debugger;
                });
            });
        }
    }
});