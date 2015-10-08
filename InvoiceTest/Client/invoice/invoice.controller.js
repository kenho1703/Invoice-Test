'use strict';

angular.module('app').controller('InvoiceCtrl', InvoiceCtrl);

function InvoiceCtrl(InvoiceServices, products) {
    var vm = this;
    console.log("invoice controller", products);
    vm.products = products;



    vm.invoice = {
        InvoiceItems: [],
        vat: 10,
        shipping: 50,
        SubTotal: 0,
        Total: 0
    };

    vm.decorateProducts = function () {
        var temp = [];
        if (vm.products && vm.products.length > 0) {
            vm.products.forEach(function(product) {
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
        return subTotal;
    };

    vm.getVAT = function () {
        var vat = 0;
        vat = vm.getSubtotal() * (vm.invoice.vat / 100);
        return vat;
    };

    vm.getShipping = function () {
        if (vm.invoice.InvoiceItems.length > 0) {
            return vm.invoice.shipping;
        }
        return 0;
    };

    vm.getTotalPrice = function () {
        var total;
        total = vm.getSubtotal() + vm.getVAT() + vm.getShipping();
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
            Name: ""
        });
    };

    vm.saveInvoice = function () {
        console.info("Save invoice: ", vm.invoice);
        InvoiceServices.createInvoice(vm.invoice).then(
            function (data) {
                console.log(data);
            }, function (error) {
            console.log(error);
        });
    };

    vm.decorateProducts();
}