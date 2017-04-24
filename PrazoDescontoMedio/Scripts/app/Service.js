app.service("descMService", function ($http) {

    //Obter todas as casas
    this.ObterCasas = function () {

        return $http.get("/api/v1/public/geral")


    }
});