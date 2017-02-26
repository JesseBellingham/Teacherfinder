var app = angular.module("app", ['ui.bootstrap', 'ui.router', 'gm'])
                .config(function($stateProvider) {
                        $stateProvider
                            .state('/', {
                                //templateUrl: 'views/main.html',
                                controller: 'DashboardCtrl',
                                //controllerAs: 'main'
                        });
                            // .when('/pokemon', {
                            //     templateUrl: 'views/pokemon.html',
                            //     controller: 'PokemonCtrl',
                            //     controllerAs: 'controller'

                            // })
                            // .otherwise({
                            //     redirectTo: '/main'
                            // });
                    });