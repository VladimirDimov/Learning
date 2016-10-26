import {Component} from 'angular2/core';
import {RouteParams, RouteData} from 'angular2/router';
import {EmployeesService} from './employees.service';
import {Employee} from './Employee.interface';

@Component({
    selector: 'employeeDetails',
    templateUrl: '/app/EmployeeDetails.html',
    providers: [EmployeesService]
})

export class EmployeeDetails {
    employeeId: number;
    employee;

    constructor(params: RouteParams, data: RouteData, private employeesService: EmployeesService) {
        this.employeeId = parseInt(params.get('id'));
        this.employee = employeesService.getById(this.employeeId);
    }
}