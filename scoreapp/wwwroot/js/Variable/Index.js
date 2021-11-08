/// <reference path="../../lib/angularjs/angular.min.js" />



var app = angular.module('indexModule', []);

app.controller('indexController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {
    
    $scope.groups = [];
    $scope.config = {
        headers: {
            "Content-Type": "application/json; charset = utf-8;",
            "X-Requested-With": "XMLHttpRequest"
        }
    };
    //$scope.init = function (id)
    //{
    //    $("#"+id).mdbEditor(
    //        {
    //            modalEditor: true,
    //            headerLength: 4,
    //        });
    //    $('.dataTables_length').addClass('bs-select');
    //}
    $scope.finished = function () {
        
        $timeout(function () {
            refreshTable();
            
        }, 0, false);
        
        
    }
    angular.element(document).ready(function () {
        $http.get('/api/c89e734b-4f1d-41d9-b071-5ef07773cd0b/Get', $scope.config).then(
            function (response) {
                $scope.groups = response.data[0];
                
            }
            , function (error) {
                console.log(error);
            });
    });

    $scope.update = function (table) {
        let variableName = $('#formNameEdit1-' + table).val();
        let score = parseInt($('#formOfficeEdit1-' + table).val());
        if (parseInt($('#formOfficeEdit1-' + table).val()) > 0 && $scope.groups[0].variables.filter(x => x.id == variableName)[0] != score) {
            $http.post('/api/c89e734b-4f1d-41d9-b071-5ef07773cd0b/Post',
                JSON.stringify({ 'VariableId': variableName, 'Score': score }),
                $scope.config).then(
                    function (response) {
                        let data = response.data;

                        if (data != null) {
                            $scope.groups = data[0];

                            if ($scope.groups.filter(x => x.description.toLowerCase() == table.toLowerCase())[0].variables.filter(x => x.id == variableName)[0].score != score) {
                                swal.fire("Oooops", "No se pudo actualizar el registro en la base de datos. Intentelo de nuevo", "error");
                            }

                        } else {
                            swal.fire("Oooops", "Hubo un error al tratar de actualizar el registro", "error");
                        }
                    },
                    function (error) {
                        console.log('aqui' + error);
                    }
                );
        } else {
            swal.fire("Oooops", "Hubo un error al tratar de editar el registro", "error");
        }
        
        
    }


    $scope.add = function (table) {

        
        if ($('#inputPosition1-' + table).val() != '' && $scope.groups[0].variables.filter(x => x.id == $('#inputPosition1-' + table).val()).length == 0) {
            
            $http.post('/api/c89e734b-4f1d-41d9-b071-5ef07773cd0b/PostAdd',
                JSON.stringify({
                    'Id': $scope.groups.filter(x => x.description.toLowerCase() == table.toLowerCase())[0].id,
                    'Variable': $('#inputPosition1-' + table).val(), 'Score': parseInt($('#inputOfficeInput1-' + table).val())
                }),
                $scope.config).then(
                    function (response) {
                        let data = response.data;
                        
                        if (data != null) {
                            $scope.groups = data[0];
                            

                        } else {
                            swal.fire("Oooops", "Hubo un error al tratar de agregar el registro", "error");
                        }
                    },
                    function (error) {
                        console.log(error);
                    }
                );
        } else {
            swal.fire("Oooops", "Hubo un error al tratar de agregar el registro", "error");
        }

    }


    $scope.delete = function (table) {

        
        
        $http.post('/api/c89e734b-4f1d-41d9-b071-5ef07773cd0b/PostDelete',
            JSON.stringify({ 'VariableId': $('#toErase-' + table).val(), 'Score': 0 }),
            $scope.config).then(
                function (response) {
                    let data = response.data;

                    if (data != null) {
                        $scope.groups = data[0];


                    } else {
                        swal.fire("Oooops", "Hubo un error al tratar de borrar el registro", "error");
                    }
                },
                function (error) {
                    console.log(error);
                }
            );
        
    }
    $scope.selectedRow = function (table) {
        $('#toErase-' + table).val($('.tr-color-selected')[0].cells[0].innerText);
    }


    $scope.functionFilter = function (group) {
        
        if ($scope.filter == null || $scope.filter == '') {
            
            
            return true;
        }
            

        return group.description.toString().toLowerCase().indexOf($scope.filter) != -1;
    }

    $scope.addGroup = async function () {
        const { value: formValues } = await Swal.fire({
            title: 'Nuevo Grupo',
            html:`<div class="md-form mb-5">
                    <input type="text" id="swal-input1" class="form-control validate">
                    <label data-error="wrong" data-success="right" for="swal-input1">Nombre del Grupo</label>
                </div>` ,
            confirmButtonText: '<i class="fa fa-thumbs-up mr-1"></i>Agregar',
            cancelButtonText: '<i class="fa fa-ban mr-1"></i>Cancelar',
            showCancelButton: true,
            confirmButtonColor: '#28a745',
            cancelButtonColor: '#dc3545',
            preConfirm: () => {
                return [
                    document.getElementById('swal-input1').value
                ]
            }
        });
       
        if (formValues != undefined) {
            let result = $scope.groups.filter(x => x.description.toLowerCase() == formValues[0].toLowerCase()).length == 0;
            if (formValues[0] != "" && result) {
                $http.post('/api/c89e734b-4f1d-41d9-b071-5ef07773cd0b/PostGroup',
                    JSON.stringify(formValues[0]),
                    $scope.config).then(
                        function (response) {
                            let data = response.data;
                            
                            if (data != null) {
                                $scope.groups = data[0];


                            } else {
                                swal.fire("Oooops", "Hubo un error al tratar de agregar el registro", "error");
                            }
                        },
                        function (error) {
                            console.log(error);
                        }
                    );
            } else {
                if (result) {
                    swal.fire("Oooops", "El grupo que esta intentando agregar ya se encuentra registrado.", "error");
                } else {
                    swal.fire("Oooops", "No se puede agregar un valor vacío.", "error");
                }
                

            }
        }
        
    }

    
}]);

function refreshTable() {
    
    $('table').each(function () {
        //if (!$.fn.DataTable.isDataTable($(this).id)) {
            
        //}
        
        $(this).DataTable({
            "aLengthMenu": [5],
            //"columnDefs": [
            //{
            //    "targets": [0],
            //    "visible": false
            //    }],
            "language": {
                "emptyTable": "No hay data disponible en la tabla"
            },
            destroy: true,
            stateSave: true
        });
        $(this).mdbEditor(
            {
                modalEditor: true,
                headerLength: 3,
            });
        $('.dataTables_length').addClass('bs-select');

        $('input:not([type="email"]):not([type="date"]):not([type="checkbox"]):not([type="number"]):not([type="hidden"])').attr('type', 'text');

        $('input:not([type="date"]):not([type="hidden"])').each(function () {

            $(this).parent().find('label').addClass("activeCustom");

        })
        
    });
}