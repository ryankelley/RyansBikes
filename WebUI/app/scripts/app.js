'use strict';

/**
 * @ngdoc overview
 * @name webUiApp
 * @description
 * # webUiApp
 *
 * Main module of the application.
 */
angular
  .module('webUiApp', [
    'ngCookies',
    'ngResource',
    'ngRoute',
        'ui.router',
    'ngSanitize',
    'ngTouch'
  ])
  .config(function ($stateProvider, $locationProvider) {
    $locationProvider.html5Mode({
      enabled: true,
      requireBase: false
    });

      $stateProvider
          .state('main', {
            url: '/',
            templateUrl:'views/main.html',
            controller: 'MainCtrl'
          });
  });
