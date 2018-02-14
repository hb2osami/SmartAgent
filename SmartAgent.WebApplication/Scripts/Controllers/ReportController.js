app.controller('ReportController', function ($scope, services, $filter, $cookieStore, $timeout) {
    
    $scope.showNewCompany = false;
    $scope.success = false;
    $scope.failure = false;
    $scope.task = {};
    
    services.getAgents().then(function (data) {
        $scope.agents = data.data;
    });

    $scope.submitTask = function () {
        $scope.task['task'] = $scope.name;
        $scope.task['location'] = $scope.location;
        $scope.task['priority'] = $scope.priority;
        $scope.task['idA'] = $scope.agent;
        var json_str = JSON.stringify($scope.task);
        services.addTask(json_str).then(
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
        return typeof val === "undefined" || val === null || val === 0
    };
    
});