app.controller("descMCtrl", function ($scope, descMService) {


    //Obter Todas as Casas
    $scope.obterCasas = function() {

        var casasData = descMService.ObterCasas();

        casasData.then(function (casa) {

            $scope.casas = casa.data;

        }, function () {

            toastr["error"]("Erro ao obter os Registros!", "DTI - Grupo VDL");
        });
    }
});