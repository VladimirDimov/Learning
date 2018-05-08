
$(document).ready(function () {

    var Model = function () {

        var validatableForm = {
            form: ko.validatedObservable({
                testRequired: ko.observable().extend({
                    required: true
                }),

                testRange: ko.observable().extend({
                    required: true,
                    min: 3,
                    max: 7
                }),

                submit: submit,
            })
        };

        function submit(scope) {
            for(var item in scope.form()){
                if(scope.form()[item].valueHasMutated) {
                    scope.form()[item].valueHasMutated();
                }

                console.log(item);
            }

            if(!scope.form().isValid) {
                console.log(scope.form.errors());
                return;
            }
        };

        return validatableForm;
    };

    ko.validation.locale('en-US');
    // ko.validation.configure({
    //     insertMessages: true,
    // });

    var model = document.getElementById('wrapper');
    var scope = new Model();
    ko.applyBindings(scope, model);
});