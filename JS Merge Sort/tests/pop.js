(function () {
    'use strict';

    var assert = chai.assert;
    var expect = chai.expect;

    describe('heap.pop()', function () {

        it('should be a function', function () {
            var heap = getEmptyHeap();
            expect(typeof heap.pop).to.equal('function');
        });

        it('should throw if the heap is empty', function () {
            var heap = getEmptyHeap();
            expect(function () {
                var x = heap.pop();
            }).to.throw(Error);
        });

        it('should always return the right max value', function () {
            var heap = getEmptyHeap();

            for (var i = 0; i < 1000; i++) {
                var comparator = helpers.maxNumberComparator;
                var heap = heap.init(comparator);

                for (var j = 0; j < 10; j++) {
                    heap.push(helpers.getRandomInt(1, 1000));
                }

                var orderedList = heap._elements.slice().sort(function (a, b) {
                    return b - a;
                });

                for (var j = 0; j < 10; j++) {
                    var currentBestNumber = heap.pop();
                    expect(currentBestNumber).to.equal(orderedList[j]);
                }
            }
        });

        it('should always return the right min value', function () {
            var heap = getEmptyHeap();

            for (var i = 0; i < 1000; i++) {
                var comparator = helpers.minNumberComparator;
                var heap = heap.init(comparator);

                for (var j = 0; j < 10; j++) {
                    heap.push(helpers.getRandomInt(1, 1000));
                }

                var orderedList = heap._elements.slice().sort(function (a, b) {
                    return a - b;
                });

                for (var j = 0; j < 10; j++) {
                    var currentBestNumber = heap.pop();
                    expect(currentBestNumber).to.equal(orderedList[j]);
                }
            }
        });

        it('should always return the right longest word value', function () {
            var heap = getEmptyHeap();

            for (var i = 0; i < 1000; i++) {
                var comparator = helpers.minNumberComparator;
                var heap = heap.init(function (right, left) {
                    return left.length > right.length;
                });

                for (var j = 0; j < 100; j++) {
                    heap.push(helpers.randomString(helpers.getRandomInt(1, 50)));
                }

                var orderedList = heap._elements.slice().sort(function (a, b) {
                    return b.length - a.length;
                });

                for (var j = 0; j < 10; j++) {
                    var currentBestNumber = heap.pop();
                    expect(currentBestNumber.length).to.equal(orderedList[j].length);
                }
            }
        });

        it('should always return the right shortest word value', function () {
            var heap = getEmptyHeap();

            for (var i = 0; i < 1000; i++) {
                var comparator = helpers.minNumberComparator;
                var heap = heap.init(function (right, left) {
                    return left.length < right.length;
                });

                for (var j = 0; j < 100; j++) {
                    heap.push(helpers.randomString(helpers.getRandomInt(1, 50)));
                }

                var orderedList = heap._elements.slice().sort(function (a, b) {
                    return a.length - b.length;
                });

                for (var j = 0; j < 10; j++) {
                    var currentBestNumber = heap.pop();
                    expect(currentBestNumber.length).to.equal(orderedList[j].length);
                }
            }
        });
    });
} ());