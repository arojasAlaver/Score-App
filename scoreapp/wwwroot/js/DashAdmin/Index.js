/// <reference path="../../lib/angularjs/angular.min.js" />



var app = angular.module('indexModule', []);

app.controller('indexController', ['$scope', '$http', function ($scope, $http) {
    $scope.CourierList = [];
    $scope.ConnectionState = "Disconnected";
    $scope.results = {
        aproved: 0,
        pre_aproved: 0,
        denied: 0,
        percentAproved: 0,
        percentPre_Aproved: 0,
        percentDenied: 0,
        total: 0,
        totalAproved: 0,
        percentTotal: 0,
        percentTotalAproved:0
    }


    
    $scope.config = {
        headers: {
            "Content-Type": "application/json; charset = utf-8;",
            "X-Requested-With": "XMLHttpRequest"
        }
    };

    angular.element(document).ready(function () {
        
        init($scope, $http);
        
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("/ApplicationNotificationHub",
                {
                    skipNegotiation: true,
                    transport: signalR.HttpTransportType.WebSockets,

                })
            .withAutomaticReconnect()
            .build();


        connection.on("ApplicationNotify", (app) => {

            init($scope, $http);
            Advice();
        });


        $scope.ConnectionState = connection.state;
        start(connection);


        connection.onreconnecting(error => {
            $scope.ConnectionState = "Connecting";
            $scope.$apply();
        });

        connection.onreconnected(connectionId => {
            $scope.ConnectionState = "Connected";
            $scope.$apply();
        });

        connection.onclose(error => {
            $scope.ConnectionState = "Disconnected";
            $scope.$apply();

        });
    });
    async function start(connection) {
        await connection.start();
        $scope.ConnectionState = connection.state;
        $scope.$apply();
    };
}]);

function Advice() {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 10000,
        timerProgressBar: true,
        didOpen: (toast) => {

            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })

    Toast.fire({
        icon: 'success',
        title: `New changes are detected`
    })

    $('.audio-player')[0].play();
}


function init($scope, $http) {
    $scope.results = {
        aproved: 0,
        pre_aproved: 0,
        denied: 0,
        percentAproved: 0,
        percentPre_Aproved: 0,
        percentDenied: 0
    };
    $http.get('/api/4039b714-caeb-4c65-9eb9-621ac530813f/Applications', $scope.config).then(
        function (response) {
            $scope.applications = response.data[0];
            
            graph(response.data);
            if ($scope.applications != null) {

                angular.forEach($scope.applications, function (value, key) {

                    switch (value.status) {
                        case 0:
                            $scope.results.pre_aproved += 1;
                            break;
                        case 1:
                            $scope.results.aproved += 1;
                            break;
                        case 2:
                            $scope.results.denied += 1;
                            break;
                    }
                });

                $scope.results.percentPre_Aproved = (100 / parseInt($scope.applications.length)) * parseInt($scope.results.pre_aproved);
                $scope.results.percentAproved = (100 / parseInt($scope.applications.length)) * parseInt($scope.results.aproved);
                $scope.results.percentDenied = (100 / parseInt($scope.applications.length)) * parseInt($scope.results.denied);
                $scope.results.total = 0;
                $scope.results.totalAproved = 0;
                $scope.results.percentTotal = 0;
                $scope.results.percentTotalAproved = 0;
                angular.forEach(response.data[2], function (value, index)
                {
                    $scope.results.total += value.total;
                    $scope.results.totalAproved += value.totalAproved;
                    $scope.results.percentTotal = (100 / parseFloat($scope.results.total)) * parseFloat($scope.results.total);
                    $scope.results.percentTotalAproved = (100 / parseFloat($scope.results.total)) * parseFloat($scope.results.totalAproved);

                });
            }


        }
        , function (error) {
            console.log(error);
        });
}

function graph(datas) {

    let data = []
    angular.forEach(datas[1], function (value, row) {
        data.push(value.total);
    });
    var ctxB = document.getElementById("casesCount").getContext('2d');
    var myBarChart = new Chart(ctxB, {
        type: 'bar',
        data: {
            labels: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
            datasets: [{
                label: 'Cantidad de Casos por Meses',
                data: data,
                backgroundColor: [
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)'
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            tooltips: {
                callbacks: {
                    label: function (item, all) {

                        return parseFloat(item.yLabel).toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                    }
                }
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true,

                    }
                }]
            }
        }
    });

    let data1 = [];
    let data2 = [];
    angular.forEach(datas[2], function (value, row) {
        data1.push(value.total);
        data2.push(value.totalAproved);
    });

    ctxB = document.getElementById("casesMoney").getContext('2d');
    var myBarChart = new Chart(ctxB, {
        type: 'bar',
        data: {
            labels: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"],
            datasets: [{
                label: 'Monto de Solicitudes',
                data: data1,
                backgroundColor: [

                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(54, 162, 235, 0.2)'

                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(54, 162, 235, 1)'
                ],
                borderWidth: 1
            },
            {
                label: 'Monto de Aprobación',
                data: data2,
                backgroundColor: [

                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)',
                    'rgba(255, 217, 225, 0.2)'

                ],
                borderColor: [
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)',
                    'rgba(255, 217, 225, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            tooltips: {
                callbacks: {
                    label: function (item,all) {
                        
                        return parseFloat(item.yLabel).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                    }
                }
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true,
                        callback: function (value, index, values) {

                            if (parseInt(value) >= 1000) {
                                return '$' + parseFloat(value).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                            } else {
                                return '$' + value;
                            }
                        }

                    }
                }]
            }

        }
    });

}