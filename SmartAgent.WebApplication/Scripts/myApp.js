var app = angular.module('myApp', ['ui.bootstrap','ngCookies']);

app.factory("services", ['$http', function ($http) {
    var serviceBase = 'http://localhost:49197/Service1.svc/JSON/'
    var obj = {};
    var config = {
        headers: {
            'Content-Type': 'application/json'
        }
    }

    obj.getIssues = function (offset, limit, sort, dir, search) {
        return $http.get(serviceBase + 'Tasks/?offset=' + offset + '&limit=' + limit
            + '&sort=' + sort + '&dir=' + dir + search);
    }
    obj.getAgents = function () {
        return $http.get(serviceBase + 'Agents');
    }
    obj.getFilters = function () {
        return $http.get(serviceBase + '/Tasks/Filters');
    }
    obj.getSpecificIssue = function (id) {
        return $http.get(serviceBase + 'Tasks/' + id);
    }
    obj.addTask = function (data) {
        return $http.post(serviceBase + 'Tasks', data, config);
    }

    return obj;
}]);