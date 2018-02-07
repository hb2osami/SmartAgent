var app = angular.module('myApp', ['ngCookies']);

app.factory("services", ['$http', function ($http) {
    var serviceBase = 'http://localhost:49197/Service1.svc/JSON/'
    var obj = {};

    obj.getIssues = function (offset, limit, sort, dir) {
        return $http.get(serviceBase + 'Tasks');
    }
    obj.getAgents = function () {
        return $http.get(serviceBase + 'Agents');
    }
    obj.getFilters = function () {
        return $http.get(serviceBase + '/Tasks/Filters');
    }
    obj.searchIssues = function (offset, limit, sort, dir, search) {
        return $http.get(serviceBase + 'searchissues?offset=' + offset + '&limit=' + limit
            + '&sort=' + sort + '&dir=' + dir + search);
    }
    obj.globalSearchIssues = function (offset, limit, sort, dir, search) {
        return $http.get(serviceBase + 'globalsearchissues?offset=' + offset + '&limit=' + limit
            + '&sort=' + sort + '&dir=' + dir + '&searcharg=' + search);
    }
    obj.getSpecificIssue = function (id) {
        return $http.get(serviceBase + 'Tasks/' + id);
    }
    obj.getIssueCount = function () {
        return $http.get(serviceBase + 'issuescount');
    }

    return obj;
}]);