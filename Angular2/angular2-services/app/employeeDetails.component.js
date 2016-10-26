System.register(['angular2/core', 'angular2/router', './employees.service'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, employees_service_1;
    var EmployeeDetails;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (employees_service_1_1) {
                employees_service_1 = employees_service_1_1;
            }],
        execute: function() {
            EmployeeDetails = (function () {
                function EmployeeDetails(params, data, employeesService) {
                    this.employeesService = employeesService;
                    this.employeeId = parseInt(params.get('id'));
                    this.employee = employeesService.getById(this.employeeId);
                }
                EmployeeDetails = __decorate([
                    core_1.Component({
                        selector: 'employeeDetails',
                        templateUrl: '/app/EmployeeDetails.html',
                        providers: [employees_service_1.EmployeesService]
                    }), 
                    __metadata('design:paramtypes', [router_1.RouteParams, router_1.RouteData, employees_service_1.EmployeesService])
                ], EmployeeDetails);
                return EmployeeDetails;
            }());
            exports_1("EmployeeDetails", EmployeeDetails);
        }
    }
});
//# sourceMappingURL=employeeDetails.component.js.map