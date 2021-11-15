/// <reference path="../../lib/angularjs/angular.min.js" />



var app = angular.module('indexModule', ['ui.mask', 'cur.$mask']);

app.controller('indexController', ['$scope', '$municipality', '$person', '$car', '$isMessageSet', function ($scope, $municipality, $person, $car, $isMessageSet) {

    
    /*VARIABLES DECLARATION*/
    $scope.mask = "";
    $scope.personProvinces = [{ id: null, label: "Seleccione una provincia", disabled: true }];
    $scope.personMunicipalities = [{ id: null, label: "Seleccione un municipio", disabled: true }];

    $scope.jobProvinces = [{ id: null, label: "Seleccione una provincia", disabled: true }];
    $scope.jobMunicipalities = [{ id: null, label: "Seleccione un municipio", disabled: true }];

    $scope.brandCars = [{ id: null, label: "Seleccione una marca", disabled: true }];
    $scope.modelCars = [{ id: null, label: "Seleccione un módelo", disabled: true }];


    $scope.typeDocuments = [{ id: null, label: "Tipo de Documento", disabled: true },
        { id: 0, label: "Cédula", subItem: "999-9999999-9" }, { id: 1, label: "Pasaporte", subItem: "AA9999999" }];
    $scope.phoneFormat = "(999)-999-9999";
    $scope.incomes = '0.00';
    $scope.otherIncomes = '0.00';


    /*VARIABLES DECLARATION*/
    angular.element('document').ready(function ()
    {
        
        
        
        if ($isMessageSet)
            $('#centralModalSuccess').appendTo("body").modal('show');
    });


    
    angular.forEach($municipality, function (value, key) {
        
        $scope.personProvinces.push(
            {
                id: key.substring(0,key.indexOf(":")),
                label: key.substring(key.indexOf(":")+1),
                subItem:value
            });
        $scope.jobProvinces.push(
            {
                id: key.substring(0, key.indexOf(":")),
                label: key.substring(key.indexOf(":") + 1),
                subItem: value
            });
        
    });

    angular.forEach($car, function (value, key) {

        $scope.brandCars.push(
            {
                id: key.substring(0, key.indexOf(":")),
                label: key.substring(key.indexOf(":") + 1),
                subItem: value
            });

    });

    $scope.update = function (selection)
    {
        switch (selection) {
            case 1:
                personMunicipality($scope);
                break;
            case 2:
                jobMunicipality($scope);
                break;
            case 3:
                
                modelCar($scope);
                break;
        }
        
    }

    $scope.UpdateTypeDocument = function () {
        
        $scope.mask = $scope.typeDocumentSelect.subItem
    }
    
    $scope.personProvinceSelect = $person == null ? $scope.personProvinces[0] : $scope.personProvinces.filter(x => x.id == $person.province)[0];
    $scope.personMunipalitySelect = $scope.personMunicipalities[0];
    
    $scope.jobProvinceSelect = $person == null || $person.jobs == null ? $scope.jobProvinces[0] : $scope.jobProvinces.filter(x => x.id == $person.jobs[0].province)[0];
    $scope.jobMunipalitySelect = $scope.jobMunicipalities[0];

    
    $scope.brandCarsSelect = $person == null || $person.applications == null || $person.applications[0].vehicle == null ? $scope.brandCars[0] : $scope.brandCars.filter(x => x.id == $person.applications[0].vehicle.brand)[0];
    $scope.modelCarsSelect = $scope.modelCars[0];

    

    if ($person != null) {
        personMunicipality($scope, $person.municipality);
        jobMunicipality($scope, $person.jobs == null ? null : $person.jobs[0].municipality);
        if ($scope.brandCarsSelect != undefined)
            modelCar($scope, $person.applications == null ? null : $person.applications[0].vehicle.model);
        
    }

    
    $scope.typeDocumentSelect = $person == null ? $scope.typeDocuments[0] : $scope.typeDocuments.filter(x => x.id == $person.type_Indetification)[0];
    $scope.id = $person == null ? '' : $person.id;
    $scope.cel1 = $person == null ? '' : $person.cel1;
    $scope.cel2 = $person == null ? '' : $person.cel2;
    $scope.jobPhone = $person == null || $person.jobs == null ? '' : $person.jobs[0].companyPhone;

    $scope.incomes = $person == null ? 0 : $person.applications[0].incomes;
    $scope.otherIncomes = $person == null ? 0 : $person.applications[0].otherIncomes;
    $scope.amount = $person == null ? 0 : $person.applications[0].amount;
    $scope.terms = $person == null ? 0 : $person.applications[0].terms;
    
    $scope.ifNull = function (value) {
        
        if (value == undefined || value == '' || value == null)
            return '0.00';
        return value;
    }
    
    $("body").keypress(function (evt) {
        if (evt.originalEvent.code == "NumpadAdd") {
            
            if (document.getElementsByClassName('list-group-item list-group-item-action active')[0].nextElementSibling != null) {
                $(`#${document.getElementsByClassName('list-group-item list-group-item-action active')[0].nextElementSibling.id}`).click();
            }
        } else if (evt.originalEvent.code == "NumpadSubtract") {
            if (document.getElementsByClassName('list-group-item list-group-item-action active')[0].previousElementSibling != null) {
                $(`#${document.getElementsByClassName('list-group-item list-group-item-action active')[0].previousElementSibling.id}`).click();
            }
            
            
        }
       
    });
}]);

function personMunicipality($scope,index = null) {
    $scope.personMunicipalities.splice(1);
    angular.forEach($scope.personProvinceSelect.subItem, function (value, key) {

        $scope.personMunicipalities.push(
            {
                id: key,
                label: value
            });
    });
    
    $scope.personMunipalitySelect = $scope.personMunicipalities.filter(x => x.id == index)[0];
    

}

function jobMunicipality($scope, index = null) {
    $scope.jobMunicipalities.splice(1);
    angular.forEach($scope.jobProvinceSelect.subItem, function (value, key) {

        $scope.jobMunicipalities.push(
            {
                id: key,
                label: value
            });
    });

    $scope.jobMunipalitySelect = $scope.jobMunicipalities.filter(x => x.id == index)[0];


}

function modelCar($scope, index = null) {
    $scope.modelCars.splice(1);
    
    angular.forEach($scope.brandCarsSelect.subItem, function (value, key) {
        
        $scope.modelCars.push(
            {
                id: key,
                label: value
            });
    });
    
    $scope.modelCarsSelect = $scope.modelCars.filter(x => x.id == index)[0];
    
    
}


app.filter('customNumber', function () {
    return function (value) {
        
        value = value == undefined || value == null ? 0 : value;
        
        return parseFloat(value.toString().replace(/,/g,'')) //convert to int
    }
})

app.filter('customFromString', function () {
    return function (value) {

        value = value == undefined || value == null ? 0 : value;

        return parseInt(value.toString().replace(/,/g, '')) //convert to int
    }
})