import { Component, OnInit } from 'angular2/core';
import {Employee} from './employee.interface';
import {EmployeesService} from './employees.service';
import {RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from 'angular2/router';

import {HomeComponent} from './Home.component'
import {EmployeeDetails} from './employeeDetails.component'

@Component({
    selector: 'my-app',
    templateUrl: '/app/app.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [EmployeesService, ROUTER_PROVIDERS]
})

@RouteConfig([
    { path: '/home', component: HomeComponent, name: 'Home', useAsDefault: true },
    { path: '/employeeDetails', component: EmployeeDetails, name: 'EmployeeDetatils' },
])

export class AppComponent {
    employees: Employee[];

    constructor(private _employeeService: EmployeesService) { }

    ngOnInit() {
        this.initEmployees();
    }

    initEmployees() {
        this._employeeService.getEmployees()
            .then(employees => this.employees = employees);
    }
}