System.register(['angular2/core', './employees.service', 'angular2/router', './Home.component', './employeeDetails.component'], function(exports_1, context_1) {
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
    var core_1, employees_service_1, router_1, Home_component_1, employeeDetails_component_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (employees_service_1_1) {
                employees_service_1 = employees_service_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (Home_component_1_1) {
                Home_component_1 = Home_component_1_1;
            },
            function (employeeDetails_component_1_1) {
                employeeDetails_component_1 = employeeDetails_component_1_1;
            }],
        execute: function() {
            AppComponent = (function () {
                function AppComponent(_employeeService) {
                    this._employeeService = _employeeService;
                }
                AppComponent.prototype.ngOnInit = function () {
                    this.initEmployees();
                };
                AppComponent.prototype.initEmployees = function () {
                    var _this = this;
                    this._employeeService.getEmployees()
                        .then(function (employees) { return _this.employees = employees; });
                };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'my-app',
                        templateUrl: '/app/app.html',
                        directives: [router_1.ROUTER_DIRECTIVES],
                        providers: [employees_service_1.EmployeesService, router_1.ROUTER_PROVIDERS]
                    }),
                    router_1.RouteConfig([
                        { path: '/home', component: Home_component_1.HomeComponent, name: 'Home', useAsDefault: true },
                        { path: '/employeeDetails', component: employeeDetails_component_1.EmployeeDetails, name: 'EmployeeDetatils' },
                    ]), 
                    __metadata('design:paramtypes', [employees_service_1.EmployeesService])
                ], AppComponent);
                return AppComponent;
            }());
            exports_1("AppComponent", AppComponent);
        }
    }
});
//# sourceMappingURL=app.component.js.map