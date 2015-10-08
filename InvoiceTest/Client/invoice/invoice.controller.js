'use strict';

angular.module('app').controller('InvoiceCtrl', InvoiceCtrl);

function InvoiceCtrl(toaster, InvoiceServices, products) {
    var vm = this;
    vm.products = products;

    vm.invoice = {
        InvoiceItems: [],
        VAT: 10,
        Shipping: 50,
        SubTotal: 0,
        Total: 0
    };

    vm.decorateProducts = function () {
        var temp = [];
        if (vm.products && vm.products.length > 0) {
            vm.products.forEach(function (product) {
                temp.push({
                    ProductId: product.Id,
                    Quantity: 1,
                    Description: product.Description,
                    Price: product.Price,
                    Name: product.Name
                });
            });
            vm.products = temp;
        }
    };

    vm.getSubPrice = function (product) {
        var subPrice = 0;
        if (product) {
            subPrice = product.Quantity * product.Price;
        }
        return subPrice;
    };

    vm.getSubtotal = function () {
        var subTotal = 0;
        if (vm.invoice && vm.invoice.InvoiceItems.length) {
            vm.invoice.InvoiceItems.forEach(function (item) {
                subTotal += item.Quantity * item.Price;
            });
        }
        vm.invoice.SubTotal = subTotal;
        return subTotal;
    };

    vm.getVAT = function () {
        var vat = 0;
        vat = vm.getSubtotal() * (vm.invoice.VAT / 100);

        return vat;
    };

    vm.getShipping = function () {
        if (vm.invoice.InvoiceItems.length > 0 && vm.getSubtotal() > 0) {
            return vm.invoice.Shipping;
        }
        return 0;
    };

    vm.getTotalPrice = function () {
        var total;
        total = vm.getSubtotal() + vm.getVAT() + vm.getShipping();
        vm.invoice.Total = total;
        return total;
    };

    vm.removeProduct = function (index) {
        vm.invoice.InvoiceItems.splice(index, 1);
    };

    vm.addNewProduct = function () {
        vm.invoice.InvoiceItems.unshift({
            Quantity: 1,
            Description: "",
            Price: 0,
            Name: "",
            ProductId: 0
        });
    };

    vm.saveInvoice = function () {
        InvoiceServices.createInvoice(vm.invoice).then(
            function (data) {
                toaster.pop({
                    type: 'success',
                    title: 'Add Invoice',
                    body: 'New invoice has been created successfully',
                    showCloseButton: true,
                    timeout: 3000
                });
                console.log(data);
                vm.invoice.InvoiceItems = [];
            }, function (error) {
                toaster.pop({
                    type: 'error',
                    title: 'Add Invoice',
                    body: 'New invoice create error',
                    showCloseButton: true,
                    timeout: 3000
                });
            });
    };
    vm.decorateProducts();
}