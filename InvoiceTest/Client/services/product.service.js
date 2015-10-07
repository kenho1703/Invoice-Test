(function (angular) {
	'use strict';

	angular.module('app').factory('ProductServices', ProductServices);
	function ProductServices($http) {

		var service = {
			getAllProduct: getAllProduct
		};
		return service;

		function getAllProduct() {
		    return $http({
		        method: 'GET',
		        url: '/api/products'
		    });
		}

		
	}
})(angular);
