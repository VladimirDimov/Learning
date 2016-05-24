var assert = chai.assert;
var expect = chai.expect;

describe('mergeSorter.sort()', function () {
    this.timeout(15000);

    it('should sort ascending if no comparator name is provided', function () {
        for (var i = 0; i < 100; i++) {
            var randomArr = helpers.getRandomArray(helpers.getRandomInt(10, 50), function () {
                return helpers.getRandomInt(0, 100);
            });

            var sortedArray = randomArr.slice().sort(function (a, b) {
                return a - b;
            });
            mergeSorter.sort(randomArr);

            expect(helpers.areArraysEqual(sortedArray, randomArr, function (a, b) {
                return a === b;
            })).to.be.true;
        }
    });

    it('should sort ascending if "asc" comparator name is provided', function () {
        for (var i = 0; i < 100; i++) {
            var randomArr = helpers.getRandomArray(helpers.getRandomInt(10, 50), function () {
                return helpers.getRandomInt(0, 100);
            });

            var sortedArray = randomArr.slice();
            sortedArray.sort(function (a, b) {
                return a - b;
            });

            mergeSorter.sort(randomArr, 'asc');

            expect(helpers.areArraysEqual(sortedArray, randomArr, function (a, b) {
                return a === b;
            })).to.be.true;
        }
    });

    it('should sort descending if "desc" comparator name is provided', function () {
        for (var i = 0; i < 100; i++) {
            var randomArr = helpers.getRandomArray(helpers.getRandomInt(10, 50), function () {
                return helpers.getRandomInt(0, 100);
            });

            var sortedArray = randomArr.slice().sort(function (a, b) {
                return b - a;
            });

            mergeSorter.sort(randomArr, 'desc');

            expect(helpers.areArraysEqual(sortedArray, randomArr, function (a, b) {
                return a === b;
            })).to.be.true;
        }
    });

    it('should sort by string length asc', function () {
        for (var i = 0; i < 100; i++) {
            var randomArr = helpers.getRandomArray(helpers.getRandomInt(10, 100), function () {
                return helpers.getRandomString(helpers.getRandomInt(10, 20));
            });

            var sortedArray = randomArr.slice().sort(function (a, b) {
                return a.length - b.length;
            });

            mergeSorter.sort(randomArr, function (l, r) {
                return l.length < r.length;
            });

            expect(helpers.areArraysEqual(sortedArray, randomArr, function (a, b) {
                return a.length === b.length;
            })).to.be.true;
        }
    });

    it('should return empty array if empty array is passed', function () {
        for (var i = 0; i < 100; i++) {
            var emptyArray = [];
            mergeSorter.sort(emptyArray);

            expect(emptyArray && emptyArray.length == 0).to.be.true;
        }
    });

    it('should work properly with big arrays (100\'000 elements)', function () {
        var randomArr = helpers.getRandomArray(100000, function () {
            return helpers.getRandomInt(0, 1000);
        });

        var sortedArray = randomArr.slice().sort(function (a, b) {
            return a - b;
        });

        mergeSorter.sort(randomArr);

        expect(helpers.areArraysEqual(sortedArray, randomArr, function (a, b) {
            return a === b;
        })).to.be.true;
    });
});