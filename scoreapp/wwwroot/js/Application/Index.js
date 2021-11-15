/// <reference path="../../lib/angularjs/angular.min.js" />



var app = angular.module('indexModule', ['ui.mask', 'cur.$mask']);

app.controller('indexController', ['$scope', '$http', function ($scope, $http)
{
    $scope.appId = 0;
    $scope.amount = 0;
    $scope.applications = [];
    $scope.Notify = false;
    $scope.businnessOficials = [{ id: null, label: "Seleccione un Oficial de Negocios", disabled: true }];
    $scope.description = '';
    
    
    
    

    $scope.config = {
        headers: {
            "Content-Type": "application/json; charset = utf-8;",
            "X-Requested-With": "XMLHttpRequest"
        }
    };

    angular.element(document).ready(function () {
        init($scope, $http);
    });

    $scope.ifNull = function (value) {
        
        if (value == undefined || value == '' || value == null)
            return 0;
        return value;
    }

    $scope.assign = function ()
    {
        
        if ($scope.selectedOficial.id != null) {
            $http.post('/api/4039b714-caeb-4c65-9eb9-621ac530813f/Post',
                JSON.stringify({ 'ApplicationId': $scope.appId, 'OficialId': $scope.selectedOficial.id, 'Notify': $scope.Notify }),
                $scope.config).then(
                function (response) {
                        let data = response.data;

                        $scope.applications.splice(
                            $scope.applications.map(x => {
                                return x.Id;
                            }).indexOf(data.id),1);
                        
                        $('#modalLoginForm').modal("hide");
                        $('.modal-backdrop').hide();

                        const Toast = Swal.mixin({
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })

                        Toast.fire({
                            icon: 'success',
                            title: `La solicitud del Sr(a) ${data.person.lastNames}, ${data.person.names} ha sido asignada al oficial ${data.officialAssignTo.displayName}`
                        });
                },
                function (error) {
                    console.log(error);
                }
            );
        } else {
            swal.fire("Ooooops","Debe seleccionar un oficial de negocios "+$scope.appId,"error");
        }
    };

    $scope.appIdAssign = function (id) {
        
        $scope.appId = id;
    }

    $scope.result = function (result) {
        $http.post('/api/4039b714-caeb-4c65-9eb9-621ac530813f/Status',
            JSON.stringify({ 'ApplicationId': $scope.appId, 'Status': result, 'Description': $scope.description, 'Amount': $scope.amount == '' ? 0 : $scope.amount }),
            $scope.config).then(
                function (response) {
                    let data = response.data;

                    $scope.applications.splice(
                        $scope.applications.map(x => {
                            return x.Id;
                        }).indexOf(data.id), 1);

                    $('#modalStatus').modal("hide");
                    $('.modal-backdrop').hide();
                    init($scope, $http);
                    const Toast = Swal.mixin({
                        toast: true,
                        position: 'top-end',
                        showConfirmButton: false,
                        timer: 3000,
                        timerProgressBar: true,
                        didOpen: (toast) => {
                            toast.addEventListener('mouseenter', Swal.stopTimer)
                            toast.addEventListener('mouseleave', Swal.resumeTimer)
                        }
                    })

                    Toast.fire({
                        icon: 'success',
                        title: `La solicitud del Sr(a) ${data.person.lastNames}, ${data.person.names} ha sido trabajada.`
                    });
                },
                function (error) {
                    console.log(error);
                }
        );
    }
}]);

function init($scope,$http) {
    $http.get('/api/4039b714-caeb-4c65-9eb9-621ac530813f/Get', $scope.config).then(
        function (response) {
            $scope.applications = response.data[0];
            
            if (response.data[1] != null) {
                $scope.businnessOficials = [];
                angular.forEach(response.data[1], function (value, key) {

                    $scope.businnessOficials.push(
                        {
                            id: value.id,
                            label: value.oficial
                        });
                });
            }

            $scope.selectedOficial = $scope.businnessOficials[0];
            $(function () {
                $('[data-toggle="popover"]').popover()
            });
            $('#modalLoginForm').appendTo('body');
            $('#modalContact').appendTo('body');
        }
        , function (error) {
            console.log(error);
        });
}

app.filter('customNumber', function () {
    return function (value) {

        value = value == undefined || value == null ? 0 : value;

        return parseFloat(value.toString().replace(/,/g, '')) //convert to int
    }
})

app.filter('customFromString', function () {
    return function (value) {

        value = value == undefined || value == null ? 0 : value;

        return parseInt(value.toString().replace(/,/g, '')) //convert to int
    }
})