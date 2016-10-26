System.register(['angular2/core', './employee', 'angular2/router', './employeeForm.component'], function(exports_1, context_1) {
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
    var core_1, employee_1, router_1, employeeForm_component_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (employee_1_1) {
                employee_1 = employee_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (employeeForm_component_1_1) {
                employeeForm_component_1 = employeeForm_component_1_1;
            }],
        execute: function() {
            AppComponent = (function () {
                function AppComponent() {
                    this.title = "Employee Data";
                    this.myEmployee = "Mr John";
                    this.showMoreThanNumberOfEmployees = 2;
                    this.employees = [
                        new employee_1.Employee(1, "Pesho", new Date(1990, 5, 5)),
                        new employee_1.Employee(2, "Gosho", new Date(1984, 6, 5)),
                        new employee_1.Employee(3, "Misho", new Date(1970, 10, 18)),
                        new employee_1.Employee(4, "Tosho", new Date(1981, 3, 25)),
                    ];
                    this.values = 'Empty';
                    this.isClicked = false;
                }
                AppComponent.prototype.onKey = function (el) {
                    var word = el.value;
                    var wordArr = [];
                    for (var index = 0; index < word.length; index++) {
                        wordArr.push(word[index]);
                    }
                    this.values = wordArr.join('|');
                };
                AppComponent.prototype.addEmployee = function (el) {
                    if (!el.value) {
                        return;
                    }
                    this.employees.push(new employee_1.Employee(0, el.value, new Date()));
                    el.value = null;
                    this.isClicked = true;
                };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'my-app',
                        templateUrl: '/app/app.html',
                        directives: [router_1.ROUTER_DIRECTIVES],
                        providers: [router_1.ROUTER_PROVIDERS]
                    }),
                    router_1.RouteConfig([
                        { path: '/employee', component: employeeForm_component_1.EmployeeForm, name: 'Employee', useAsDefault: true }
                    ]), 
                    __metadata('design:paramtypes', [])
                ], AppComponent);
                return AppComponent;
            }());
            exports_1("AppComponent", AppComponent);
        }
    }
});
//# sourceMappingURL=app.component.js.map