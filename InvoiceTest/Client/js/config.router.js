'use strict';

/**
 * Config for the router
 */
angular.module('app')
  .run(
    [          '$rootScope', '$state', '$stateParams',
      function ($rootScope,   $state,   $stateParams) {
          $rootScope.$state = $state;
          $rootScope.$stateParams = $stateParams;        
      }
    ]
  )
  .config(
    [          '$stateProvider', '$urlRouterProvider',
      function ($stateProvider,   $urlRouterProvider) {
          
          $urlRouterProvider
              .otherwise('/invoice');
          $stateProvider
              .state('invoice', {
                  url: '/invoice',
                  templateUrl: 'Client/invoice/invoice.html',
                  controller: 'InvoiceCtrl',
                  controllerAs: 'vm',
                  resolve: {
                      products: getAllProduct
                  }
              });
      } ]);


function getAllProduct(ProductServices) {
    return ProductServices.getAllProduct().then(function (response) {
        return response.data;
    }, function(error) {
        console.log(error);
    });
}
