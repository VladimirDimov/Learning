System.register(['./mock-Employees'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var mock_Employees_1;
    var EmployeesService;
    return {
        setters:[
            function (mock_Employees_1_1) {
                mock_Employees_1 = mock_Employees_1_1;
            }],
        execute: function() {
            ;
            EmployeesService = (function () {
                function EmployeesService() {
                    this.getEmployees = function () {
                        return Promise.resolve(mock_Employees_1.Employees);
                    };
                    this.getById = function (id) {
                        for (var i = 0; i < mock_Employees_1.Employees.length; i++) {
                            if (mock_Employees_1.Employees[i].id == id)
                                return mock_Employees_1.Employees[i];
                        }
                    };
                }
                return EmployeesService;
            }());
            exports_1("EmployeesService", EmployeesService);
        }
    }
});
//# sourceMappingURL=employees.service.js.map