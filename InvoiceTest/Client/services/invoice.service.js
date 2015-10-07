(function (angular) {
	'use strict';

	angular.module('app').factory('InvoiceServices', InvoiceServices);
	function InvoiceServices($http) {

	    console.log($http);
		var service = {
			createInvoice: createInvoice
		};
		return service;

		function createInvoice(invoice) {
		   return $http({
		        method: 'POST',
		        url: '/api/invoices/invoiceItems',
		        data: invoice
		    });
		}
	}
})(angular);
