import {Employees} from './mock-Employees';
import {Employee} from './Employee.interface';
import {Injectable} from 'angular2/core';

@Injectable;
export class EmployeesService {
    getEmployees = function () {
        return Promise.resolve(Employees);
    }

    getById = function (id: number) {
        for (var i = 0; i < Employees.length; i++) {
            if (Employees[i].id == id) return Employees[i];
        }
    }
}