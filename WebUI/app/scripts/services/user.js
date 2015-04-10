'use strict';

/**
 * @ngdoc service
 * @name webUiApp.user
 * @description
 * # user
 * Service in the webUiApp.
 */
angular.module('webUiApp')
  .service('user', function () {
      var userData = {
        isAuthenticated: false,
        username: '',
        bearerToken: '',
        expirationDate: null
      };

      this.getUserData = function() {
        return userData;
      };
  });
