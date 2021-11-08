/// <reference path="../../lib/angularjs/angular.min.js" />



var app = angular.module('indexModule', []);

app.controller('indexController', ['$scope', '$http', '$message', function ($scope, $http, $message)
{
    if ($message != null) {
        swal.fire($message[0], $message[1], $message[2]);
    }
    $scope.users = [];
    $scope.isFinished = false;
    $scope.finished = function () {
        
        $scope.isFinished = true;

        $(function () {
            $('[data-toggle="popover"]').popover()
        })
    }
    $scope.config = {
        headers: {
            "Content-Type": "application/json; charset = utf-8;",
            "X-Requested-With":"XMLHttpRequest"
        }
    };
    angular.element(document).ready(function ()
    {
        $http.get('/api/4039b714-caeb-4c65-9eb9-621ac530813e/Get', $scope.config).then(
            function (response) {
                $scope.users = response.data;
            }
            , function (error) {
                console.log(error);
            });
    });

    $scope.userManagment = function (user)
    {
        
        $http.post('/api/4039b714-caeb-4c65-9eb9-621ac530813e/Post', JSON.stringify(user), $scope.config).then(
            function (response)
            {
                let data = response.data;

                $scope.users.filter(function (item)
                {
                    if (data.employerCode == item.employerCode) {
                        item.exists = data.exists;
                        item.id = data.id;
                        return;
                    }
                        

                });

            },
            function (error)
            {
                console.log(error);
            }
        );
    }
    
}]);