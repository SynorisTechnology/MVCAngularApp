var myApp = angular.module('OrderApp', []);
//Defining a Controller 
myApp.controller('HomeController', function ($scope, $http, $filter) {
    // Get all Property list for dropdownlist
    var orderBy = $filter('orderBy');
    $("#loading").show();

    $scope.SearchOrders = SearchOrders;
    $scope.EditClick = EditClick;
    $scope.EditOrderItemClick = EditOrderItemClick;

    function SearchOrders() {
        // fullText Search

        $('#loading').show();
        $http({
            method: 'Get',
            url: '/Home/SearchOrders',
            params: { name: $scope.CustomerName, address: $scope.CustomerAddress }
        }).success(function (data) {
            $scope.OrderList = data;
            $('#loading').hide();
        });
    }
    function EditClick(order) {
        // alert(order.FullName);
        $scope.OrderInfo = order;
        $('#loading').show();
        $http({
            method: 'Get',
            url: '/Home/GetOrderItems',
            params: { orderid: $scope.OrderInfo.OrderID}
        }).success(function (data) {
            $scope.OrderItemList = data;
            $('#loading').hide();
        });
    }
    function EditOrderItemClick(item) {
        $scope.OrderItem = item;
    }

    $('#loading').hide();
});