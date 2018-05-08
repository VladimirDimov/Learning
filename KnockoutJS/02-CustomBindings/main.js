ko.bindingHandlers.color = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        $(element).css('color', valueAccessor());
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        $(element).css('color', valueAccessor());
    }
}

$(document).ready(function () {
    var people = [
        { name: ko.observable("name 1"), age: ko.observable(102) },
        { name: ko.observable("name 2"), age: ko.observable(76) },
        { name: ko.observable("name 3"), age: ko.observable(56) },
        { name: ko.observable("name 4"), age: ko.observable(98) },
    ];

    var Model = function () {
        var self = this;

        self.red = 'red';

        return self;
    };

    var model = document.getElementById('wrapper');
    var scope = new Model();
    ko.applyBindings(scope, model);
});