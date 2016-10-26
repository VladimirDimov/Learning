import { Component } from 'angular2/core';
import { NgForm } from 'angular2/common';
import { Employee } from './employee';

@Component({
    selector: 'employeeForm',
    templateUrl: '/app/employeeForm.html'
})

export class EmployeeForm {
    model = new Employee(123, "Some Employee", new Date());
    submitted = false;
    active = true;

    onSubmit = function () {
        this.submitted = true;
    }

    newEmployee = function () {
        this.model = new Employee(124, "New Employee", new Date());
    }

    get diagnostic() {
        return JSON.stringify(this.model);
    }
}