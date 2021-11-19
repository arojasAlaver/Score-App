/// <reference path="../../lib/angularjs/angular.min.js" />



var app = angular.module('indexModule', ['ui.mask', 'cur.$mask']);

app.controller('indexController', ['$scope','$settings', function ($scope, $settings)
{
    $scope.settings = [];
    
    
    angular.forEach($settings, function (array, index) {
        
        $scope.settings.push(
            {
                id: array.id,
                setting: array.setting,
                value: array.value,
                editableSetting: array.id != '00000000-0000-0000-0000-000000000000' ? false : true
            }
        );

    });
    
    $scope.add = function ()
    {
        $scope.settings.unshift(
            {       
                id: '00000000-0000-0000-0000-000000000000',
                setting: '',
                value: '',
                editableSetting:true
            }
        );
    }

    $scope.remove = function (index)
    {
        $scope.settings.splice(index,1)
    }
}]);

app.directive("contenteditable", function () {
    return {
        require: "ngModel",
        link: function (scope, element, attrs, ngModel) {

            function read() {
                ngModel.$setViewValue(element.html());
            }

            ngModel.$render = function () {
                element.html(ngModel.$viewValue || "");
            };

            element.bind("blur keyup change", function () {
                scope.$apply(read);
            });
        }
    };
});