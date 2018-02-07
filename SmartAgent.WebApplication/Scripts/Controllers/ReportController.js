app.controller('ReportController', function ($scope, services, $filter, $cookieStore, $timeout) {
    
    $scope.showNewCompany = false;
    
    services.getAgents().then(function (data) {
        $scope.agents = data.data;
    });

    $scope.isUndefinedOrNull = function (val) {
        return typeof val === "undefined" || val === null || val === 0
    };
    
});