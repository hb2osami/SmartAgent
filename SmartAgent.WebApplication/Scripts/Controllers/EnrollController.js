app.controller('EnrollController', function ($scope, services, $filter, $cookieStore, $timeout) {

    $scope.showNewCompany = false;
    $scope.success = false;
    $scope.failure = false;
    $scope.agent = {};

    services.getFiltersAgent().then(function (data) {
        $scope.filters = data.data;
    });

    $scope.submitAgent = function () {
        for (i = 0; i < $scope.filters.length; i++) {
            if ($scope.filters[i]['name'] != "id")
                $scope.agent[$scope.filters[i]['name']] = $scope.filters[i]['value'];
        }
        var json_str = JSON.stringify($scope.agent);
        services.addAgent(json_str).then(
            function (response) {
                // success callback
                $scope.success = true;
                $timeout(function () { $scope.callAtTimeout(); }, 5000);
            },
            function (response) {
                // failure callback
                $scope.failure = true;
                $timeout(function () { $scope.callAtTimeout(); }, 5000);
            }
        );
    };



    $scope.isUndefinedOrNull = function (val) {
        return typeof val === "undefined" || val === null || val === 0 || val === ""
    };

});