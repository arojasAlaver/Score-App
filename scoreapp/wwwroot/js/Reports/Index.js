/// <reference path="../../lib/angular-file-saver/angular-file-saver.js" />
/// <reference path="../../lib/angularjs/angular.min.js" />
/// <reference path="../../lib/exceljs/exceljs.js" />



var app = angular.module('indexModule', ['ngFileSaver']);
var reportGlobal = '';

app.controller('indexController', ['$scope', '$http', 'FileSaver', function ($scope, $http, FileSaver)
{
    $scope.method = 'GET';
    $scope.url = 'https://172.16.0.25:8088/api/getPrinters';
    $scope.fileUrl = 'https://localhost:44351/documents/Report.xlsx';

    $scope.config = {
        headers: {
            "Content-Type": "application/json; charset = utf-8;",
            "X-Requested-With": "XMLHttpRequest"
        }
    };


    $http({
        method: $scope.method, url: $scope.fileUrl, responseType: 'arraybuffer', headers: {
            'Content-Type': "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            'Accept': "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        }
    }).then(function (data, status, headers, config) {

        $scope.file = new Blob([data.data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;' })
        
    });

    $scope.filter = async function (report) {
        reportGlobal = report;
        const { value: formValues } = await Swal.fire({
            title: 'Rango de fechas',
            html:
                `
                <div class="row">
                    <div class="col-md-12">
                        <div class="md-form md-outline mt-3">
                            <input
                            id="from"
                            type="number"
                            oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
                            maxlength="8"
                            class="form-control"
                            autocomplete="off"
                            placeholder="aaaammdd">
                            <label for="from">Fecha Desde</label>
                        </div>
                    </div>


                    <div class="col-md-12">
                       <div class="md-form md-outline mt-3">
                            <input id="to" type="number" oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
                                maxlength="8" class="form-control" autocomplete="off" placeholder="aaaammdd">
                            <label for="to">Fecha Hasta</label>
                        </div>
                    </div>
                </div>`,
            focusConfirm: false,
            didOpen: () => {
                $('input:not([type="email"]):not([type="date"]):not([type="checkbox"]):not([type="number"]):not([type="hidden"])').attr('type', 'text');

                $('input:not([type="date"]):not([type="hidden"])').each(function () {

                    $(this).parent().find('label').addClass("activeCustom");

                })
                
                
            },
            preConfirm: () => {
                
                return [
                    document.getElementById('from').value,
                    document.getElementById('to').value
                ]
            }
        })

        if (formValues) {
            $http.post('/api/2f8629c9-45ac-433c-aa97-8bf50b86d2f6/Post',
                JSON.stringify({ 'Report': reportGlobal, 'DateFrom': formValues[0], 'DateTo': formValues[1] }),
                $scope.config).then(
                function (response) {
                        let data = response.data;

                        createReport($scope, data, FileSaver);
                }
                , function (error) {
                    console.log(error);
                });
        }
    }
}]);

function createReport($scope, data, FileSaver) {
    var reader = new FileReader();

    reader.onload = async function () {
        var fileData = reader.result;
        //var workbook = XLSX.read(fileData, { type: 'array', cellStyles: true });

        var workbook = new ExcelJS.Workbook();

        workbook = await workbook.xlsx.load($scope.file);

        workSheet = workbook.getWorksheet("Sheet1");


        //let worksheet = workbook.Sheets[workbook.SheetNames[0]];
        let row = 8;
        let name = '';
        let init = 0;

        workSheet.getRow('6').getCell('A').value = reportGlobal;
        workSheet.getRow('6').getCell('A').aligment = { horizontal: 'center' };
        let letter = 65;
        for (x in data[0]) {
            workSheet.getRow('7').getCell(String.fromCharCode(letter)).value = x.toString().replace('_', ' ').toUpperCase();
            letter++;
        }
        letter = 65;
        angular.forEach(data, function (value, index) {
            for (x in value) {
                workSheet.getRow(row.toString()).getCell(String.fromCharCode(letter)).value = value[x];
                letter++;
            }
            letter = 65;
            row = row + 1;

        });

        
        /*workSheet.getColumn(6).numFmt = '#,##0'*/

        //workbook.xlsx.writeFile($scope.file);
        var date = new Date();


        workbook.xlsx.writeBuffer()
            .then(buffer => FileSaver.saveAs(new Blob([buffer]), `REPORT_${date.getDate().toString().padStart(2, '0')}_${(date.getMonth() + 1).toString().padStart(2, '0')}_${date.getFullYear().toString().padStart(4, '0')}.xlsx`))
            .catch(err => console.log('Error writing excel export', err));

        //FileSaver.saveAs(new Blob([workbook], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;' }), 'prueba.xlsx');

    };

    reader.readAsArrayBuffer($scope.file);
}

