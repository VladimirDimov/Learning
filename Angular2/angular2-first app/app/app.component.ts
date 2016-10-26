import { Component } from 'angular2/core';
import { Employee } from './employee';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';
import { EmployeeForm } from './employeeForm.component'

@Component({
    selector: 'my-app',
    templateUrl: '/app/app.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [ROUTER_PROVIDERS]
})

@RouteConfig([
    { path: '/employee', component: EmployeeForm, name: 'Employee', useAsDefault: true }
])

export class AppComponent {
    title = "Employee Data";
    myEmployee = "Mr John";
    showMoreThanNumberOfEmployees = 2;

    employees = [
        new Employee(1, "Pesho", new Date(1990, 5, 5)),
        new Employee(2, "Gosho", new Date(1984, 6, 5)),
        new Employee(3, "Misho", new Date(1970, 10, 18)),
        new Employee(4, "Tosho", new Date(1981, 3, 25)),
    ];

    values: string = 'Empty';
    isClicked: boolean = false;

    onKey(el) {
        var word = el.value;
        var wordArr = [];
        for (var index = 0; index < word.length; index++) {
            wordArr.push(word[index]);
        }

        this.values = wordArr.join('|');
    }

    addEmployee(el) {
        if (!el.value) {
            return;
        }

        this.employees.push(new Employee(0, el.value, new Date()));
        el.value = null;
        this.isClicked = true;
    }

    // Employee form

}