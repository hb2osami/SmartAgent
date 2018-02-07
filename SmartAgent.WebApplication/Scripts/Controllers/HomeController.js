app.controller('HomeController', function ($scope, services, $filter, $cookieStore, $timeout) {

    $scope.alertOK = false;
    $scope.success = false;
    $scope.failure = false;
    $scope.currentPage = 1;
    $scope.numPerPage = 25;
    $scope.maxSize = 5;
    $scope.totalItems = 0;
    $scope.sort = 'name';
    $scope.dir = 1;
    $scope.showCheckboxes = false;
    $scope.showSearch = false;

    var json_str = $cookieStore.get('stored_columns');
    if (!json_str) {
        $scope.showIssue = true;
        $scope.showLocation = true;
        $scope.showPriority = true;
        $scope.showEmployee = true;
        $scope.showCompany = true;
        $scope.showJob = true;
        $scope.showLocationEmployee = true;
    } else {
        var storedCol = JSON.parse(json_str);
        if (storedCol.includes('showIssue')) $scope.showIssue = true;
        if (storedCol.includes('showLocation')) $scope.showLocation = true;
        if (storedCol.includes('showPriority')) $scope.showPriority = true;
        if (storedCol.includes('showEmployee')) $scope.showEmployee = true;
        if (storedCol.includes('showCompany')) $scope.showCompany = true;
        if (storedCol.includes('showJob')) $scope.showJob = true;
        if (storedCol.includes('showLocationEmployee')) $scope.showLocationEmployee = true;
    }
    /*
    services.getIssueCount().then(function (data) {
        $scope.totalItems = data.data.count;
    });
    */
    services.getIssues(0, 10, 'name', 1).then(function (data) {
        $scope.issues = data.data;
    });
    services.getFilters().then(function (data) {
        $scope.filters = data.data;
    });
    /*
    $scope.$watch("currentPage + numPerPage", function () {
        var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = $scope.numPerPage;

        services.getIssues(begin, end, $scope.sort, $scope.dir).then(function (data) {
            $scope.issues = data.data;
        });
    });*/

    var orderBy = $filter('orderBy');
    $scope.order = function (predicate, reverse) {
        var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = $scope.numPerPage;
        var dir = 1;
        if (reverse === true) dir = 0;

        services.getIssues(begin, end, predicate, dir).then(function (data) {
            $scope.issues = data.data;
        });
        $scope.sort = predicate;
        $scope.dir = dir;
    };

    $scope.callAtTimeout = function () {
        $scope.alertOK = false;
        $scope.success = false;
        $scope.failure = false;
    }

    $scope.saveCookie = function () {
        var storeCol = new Array();
        if ($scope.showIssue) storeCol.push('showIssue');
        if ($scope.showLocation) storeCol.push('showLocation');
        if ($scope.showPriority) storeCol.push('showPriority');
        if ($scope.showEmployee) storeCol.push('showEmployee');
        if ($scope.showCompany) storeCol.push('showCompany');
        if ($scope.showJob) storeCol.push('showJob');
        if ($scope.showLocationEmployee) storeCol.push('showLocationEmployee');
        var json_str = JSON.stringify(storeCol);
        $cookieStore.put('stored_columns', json_str);
        $scope.alertOK = true;
        $timeout(function () { $scope.callAtTimeout(); }, 5000);
    };

    $scope.isUndefinedOrNull = function (val) {
        return typeof val === "undefined" || val === null || val === 0
    };

    $scope.searchIssues = function () {
        var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = $scope.numPerPage;
        var searchStr = '';
        if (!$scope.isUndefinedOrNull($scope.searchName)) searchStr += ('&name=' + $scope.searchName);
        if (!$scope.isUndefinedOrNull($scope.searchLocation)) searchStr += ('&location=' + $scope.searchLocation);
        if (!$scope.isUndefinedOrNull($scope.searchPriority)) searchStr += ('&priority=' + $scope.searchPriority);

        services.searchIssues(begin, end, $scope.sort, $scope.dir, searchStr).then(function (data) {
            $scope.issues = data.data;
        });
    };

    $scope.emptySearch = function () {
        var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = $scope.numPerPage;

        $scope.searchName = "";
        $scope.searchLocation = "";
        $scope.searchPriority = "";

        services.getIssues(begin, end, $scope.sort, $scope.dir).then(function (data) {
            $scope.issues = data.data;
        });
    };

    $scope.globalSearch = function () {
        var begin = (($scope.currentPage - 1) * $scope.numPerPage)
            , end = $scope.numPerPage;

        services.globalSearchIssues(begin, end, $scope.sort, $scope.dir, $scope.search).then(function (data) {
            $scope.issues = data.data;
        });
    };

    $scope.openEdit = function (id) {
        services.getSpecificIssue(id).then(function (data) {
            data.data.priority = parseInt(data.data.priority);
            $scope.issue = data.data;
        });
    };

    $scope.submitUpdate = function () {
        services.updateIssue($scope.issue).then(function (data) {
            data.data;
            if (data.data.issueupdated === 1) {
                $scope.success = true;
                $scope.failure = false;
            }
            else {
                $scope.success = false;
                $scope.failure = true;
            }
            $scope.emptySearch();
            $timeout(function () { $scope.callAtTimeout(); }, 5000);
        });
    }
});