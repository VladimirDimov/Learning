System.register(['angular2/core', './employee'], function(exports_1, context_1) {
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
    var core_1, employee_1;
    var EmployeeForm;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (employee_1_1) {
                employee_1 = employee_1_1;
            }],
        execute: function() {
            EmployeeForm = (function () {
                function EmployeeForm() {
                    this.model = new employee_1.Employee(123, "Some Employee", new Date());
                    this.submitted = false;
                    this.active = true;
                    this.onSubmit = function () {
                        this.submitted = true;
                    };
                    this.newEmployee = function () {
                        this.model = new employee_1.Employee(124, "New Employee", new Date());
                    };
                }
                Object.defineProperty(EmployeeForm.prototype, "diagnostic", {
                    get: function () {
                        return JSON.stringify(this.model);
                    },
                    enumerable: true,
                    configurable: true
                });
                EmployeeForm = __decorate([
                    core_1.Component({
                        selector: 'employeeForm',
                        templateUrl: '/app/employeeForm.html'
                    }), 
                    __metadata('design:paramtypes', [])
                ], EmployeeForm);
                return EmployeeForm;
            }());
            exports_1("EmployeeForm", EmployeeForm);
        }
    }
});
//# sourceMappingURL=employeeForm.component.js.map