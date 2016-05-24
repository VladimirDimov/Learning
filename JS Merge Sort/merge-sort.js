var mergeSorter = (function () {
    'use strict';

    return {
        sort: function (arr, comparator) {
            if (!arr) {
                throw new Error('Invalid null or undefined array!');
            }

            merge(arr, 0, Math.max(arr.length - 1, 0), getComparator(comparator));
        }
    };

    function getComparator(comparator) {
        if (!comparator) return ascendingComparator;
        if (typeof comparator == 'function') return comparator;
        if (typeof comparator == 'string') {
            switch (comparator) {
                case 'asc':
                    return ascendingComparator;
                case 'desc':
                    return descendingComparator;
                default:
                    throw new Error('Invalid comparator name');
            }
        }
    }

    function ascendingComparator(left, right) {
        return left <= right;
    }

    function descendingComparator(left, right) {
        return left >= right;
    }

    function merge(arr, left, right, comparator) {
        if (left == right) {
            return;
        } else {
            var l = merge(arr, left, left + Math.floor((right - left) / 2), comparator);
            var r = merge(arr, left + Math.floor((right - left) / 2) + 1, right, comparator);
            sort(arr, left, left + Math.floor((right - left) / 2), left + Math.floor((right - left) / 2) + 1, right, comparator);
        }
    }

    function flip(arr, left, right) {
        var tmp = arr[left];
        arr[left] = arr[right];
        arr[right] = tmp;
    }

    function sort(arr, l, lm, rm, r, comparator) {
        var sortedSubArray = [];
        var lArr = arr.slice(l, lm + 1);
        var rArr = arr.slice(rm, r + 1);

        while (lArr.length != 0 || rArr.length != 0) {
            if (lArr.length != 0 && rArr.length != 0) {
                if (comparator(lArr[0], rArr[0])) {
                    sortedSubArray.push(lArr.shift());
                } else {
                    sortedSubArray.push(rArr.shift());
                }
            } else if (lArr.length != 0) {
                sortedSubArray.push(lArr.shift());
            } else {
                sortedSubArray.push(rArr.shift());
            }
        }

        // arr.splice(l, r - l + 1, sortedSubArray);
        var spliceArguments = [l, r - l + 1];
        Array.prototype.push.apply(spliceArguments, sortedSubArray);
        Array.prototype.splice.apply(arr, spliceArguments);
    }
} ());