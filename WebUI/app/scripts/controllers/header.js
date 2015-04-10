'use strict';

/**
 * @ngdoc function
 * @name webUiApp.controller:HeaderCtrl
 * @description
 * # HeaderCtrl
 * Controller of the webUiApp
 */
angular.module('webUiApp')
  .controller('HeaderCtrl', function ($scope, user) {
      $scope.user = user.getUserData();
    $scope.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
