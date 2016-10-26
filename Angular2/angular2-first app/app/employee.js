System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Employee;
    return {
        setters:[],
        execute: function() {
            Employee = (function () {
                function Employee(id, name, birthday) {
                    this.id = id;
                    this.name = name;
                    this.birthday = birthday;
                }
                return Employee;
            }());
            exports_1("Employee", Employee);
        }
    }
});
//# sourceMappingURL=employee.js.map