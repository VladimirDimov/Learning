var person = (function () {
    var person = {
        init: function (name, age) {
            this.name = name;
            this.age = age;

            return this;
        },
        set name(value) {
            this._name = value;
        },
        get name() {
            return this._name;
        },
        get age() {
            return this._age;
        },
        set age(value) {
            this._age = value;
        },
        toString: function () {
            return this.name + " age: " + this.age;
        }
    }

    return person;
})();

var student = (function (parent) {
    var student = Object.create(parent);

    Object.defineProperties(student, {
        init: {
            value: function (name, age, grade) {
                parent.init.call(this, name, age);
                this._grade = grade;

                return this;
            }
        },

        grade: {
            get: function () {
                return this._grade;
            },
            set: function (value) {
                this._grade = value;
            }
        },

        toString: {
            value: function () {
                return parent.toString.call(this, toString) + " grade: " + this.grade;
            }
        }
    });

    return student;
})(person);

var pesho = person.init('Petar Petrov', 20);

var gosho = student.init('Gosho Goshev', 15, 10);

console.log(pesho.toString());

console.log(gosho.toString());