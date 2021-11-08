/// <reference path="../../lib/angularjs/angular.min.js" />



var app = angular.module('indexModule', []);

app.controller('indexController', ['$scope','$http', function ($scope,$http)
{
    
    $scope.role = '';
    $scope.class = '';
    $scope.config = {
        headers: {
            "Content-Type": "application/json; charset = utf-8;",
            "X-Requested-With": "XMLHttpRequest"
        }
    };
    $scope.addNewRole = function ()
    {
        
        if ($scope.role != '') {
            $http.post('/api/4039b714-caeb-4c65-9eb9-621ac530813e/PostRole', JSON.stringify({ 'Description': $scope.role }), $scope.config).then(
                function (response) {
                    let data = response.data;
                    window.location.href = window.location.origin + '/478d5d45-d8d5-4433-bb8e-451bf62b6d61/' + data.id;
                },
                function (error) {
                    console.log(error);
                }
            );
        } else {
            $scope.class = 'is-invalid';
            swal.fire("Ooooops","El campo no puede estar vacio.","error");
        }
    }
    $scope.editRole = function (_id,_old, _new) {
        
        if (_new != '' && _new != _old) {
            $http.post('/api/4039b714-caeb-4c65-9eb9-621ac530813e/EditRole', JSON.stringify({ 'Id': _id, 'Description': _new }), $scope.config).then(
                function (response) {
                    let data = response.data;
                    window.location.reload();
                },
                function (error) {
                    console.log(error);
                }
            );
        } else {
            swal.fire("Oooops","La descripción no puede ser nula y debe ser diferente a la descripción actual.","info");
        }
    }
}]);