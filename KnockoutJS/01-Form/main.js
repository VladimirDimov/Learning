$(document).ready(function () {
    var people = [
        { name: ko.observable("name 1"), age: ko.observable(102) },
        { name: ko.observable("name 2"), age: ko.observable(76) },
        { name: ko.observable("name 3"), age: ko.observable(56) },
        { name: ko.observable("name 4"), age: ko.observable(98) },
    ];

    var Model = function () {
        var self = this;
        self.people = ko.observableArray(people);
        self.orderByAge = function () {
            self.people.sort(function (a, b) {
                if (a.age > b.age) return 1;
                if (a.age < b.age) return -1;
                return 0;
            });
        };

        self.form = {
            currentContext: ko.observable({}),

            loadForm: function (data) {
                self.form.currentContext(data);
            }
        };

        return self;
    };

    var model = document.getElementById('wrapper');
    var scope = new Model();
    ko.applyBindings(scope, model);
});