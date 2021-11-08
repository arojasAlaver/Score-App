/// <reference path="../../lib/angularjs/angular.min.js" />



var app = angular.module('indexModule', []);

app.controller('indexController', ['$scope', '$http', function ($scope, $http)
{
    $scope.appId = 1;
    $scope.applications = [];
    $scope.Notify = false;
    $scope.businnessOficials = [{ id: null, label: "Seleccione un Oficial de Negocios", disabled: true }];

    
    
    
    

    $scope.config = {
        headers: {
            "Content-Type": "application/json; charset = utf-8;",
            "X-Requested-With": "XMLHttpRequest"
        }
    };

    angular.element(document).ready(function () {
        $http.get('/api/4039b714-caeb-4c65-9eb9-621ac530813f/Get', $scope.config).then(
            function (response) {
                $scope.applications = response.data[0];
                console.log(response);
                if (response.data[1]!=null) {
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
    });

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
}]);