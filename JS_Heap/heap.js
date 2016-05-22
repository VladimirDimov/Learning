var heap = (function () {
    'use strict';

    var heap = {
        init: function (comparator) {
            if (comparator == null || comparator == 'undefined') {
                throw new Error('You should provide a comparator!');
            }

            if (typeof comparator != 'function') {
                throw new Error('The comparator type must be a function');
            }

            this._elements = [];
            this.comparator = comparator;

            return this;
        },

        get elements() {
            return this._elements;
        },

        get comparator() {
            return this._comparator;
        },

        set comparator(value) {
            this._comparator = value;
        },

        pop: function () {
            if (this._elements.length == 0) {
                throw new Error('The heap is empty!');
            }

            var result = this._elements[0];

            if (this._elements.length > 1) {
                this._elements[0] = this._elements.pop();
                updateAfterPop(0);
            } else {
                this._elements.pop();
            }

            return result;
        },

        push: function (value) {
            this._elements.push(value);
            updateElements(this._elements.length - 1);
        }
    };

    function updateElements(right) {
        if (right <= 0) return;

        var left = Math.floor((right - 1) / 2);

        if (!heap.comparator(heap.elements[right], heap.elements[left])) { // heap.elements[right] > heap.elements[left]
            flip(right, left);
            updateElements(left);
        }
    };

    function updateAfterPop(left) {
        var indexOfBigger;
        if (left * 2 + 1 > heap.elements.length - 1) return;

        indexOfBigger = getIndexOfBigger.call(heap, 2 * left + 1, 2 * left + 2);
        if (!heap.comparator(heap.elements[indexOfBigger], heap.elements[left])) { // heap.elements[left] < heap.elements[indexOfBigger]
            flip(left, indexOfBigger);
            updateAfterPop(indexOfBigger);
        }
    }

    function getIndexOfBigger(left, right) {
        if (right > this._elements.length - 1) return left;
        
        var leftValue = this.elements[left];
        var rightValue = this.elements[right];

        if (!this.comparator(this._elements[right], this._elements[left])) return right; // this.elements[right] > this.elements[left]

        return left;
    }

    function flip(right, left) {
        var temp = heap.elements[left];
        heap.elements[left] = heap.elements[right];
        heap.elements[right] = temp;
    };

    return heap;
} ());