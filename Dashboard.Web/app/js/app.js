var app = angular.module('dashboardHaven', ['adf', 'adf.structures.base', 'adf.widget.clock', 'adf.widget.weather', 'adf.widget.iframe' , 'adf.widget.news', 'adf.widget.investments', 'adf.widget.calcSimple']);

app.controller('MainController', MainController) 

function MainController($timeout, $rootScope, $http) {

    var vm = this;
    vm.working = "Yes";
    vm.userId = "";
    debugger;
    vm.login = function (username, password) {
        debugger;
        if (username === "test" && password === "test") {
            vm.userId = '1234';
            vm.getDashboardData();
        }
    }

    vm.getDashboardData = function () {
        vm.model = getFromStorage();
    }

    vm.displayResult = "from MainController";
    vm.model = getFromStorage();

    $rootScope.$on('adfDashboardChanged', function (e, name, model) {
        //TODO: SEND TO DB
        var sLayout = JSON.stringify(model);
        localStorage.setItem(name, sLayout);
        $http.put("../api/dashboarddata/28dcd081-c775-4ab3-b684-d17e50ae5015", { data: sLayout });
    });

    function getFromStorage() {
        return JSON.parse(localStorage.getItem("mydashboard"));
    }

}
