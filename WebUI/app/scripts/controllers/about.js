'use strict';

/**
 * @ngdoc function
 * @name webUiApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the webUiApp
 */
angular.module('webUiApp')
  .controller('AboutCtrl', function ($scope) {
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
