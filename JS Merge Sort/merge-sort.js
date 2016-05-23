var mergeSorter = (function () {
    'use strict';
    return {
        sort: function (arr) {
            merge(arr, 0, arr.length - 1);
        }
    };

    function merge(arr, left, right) {
        if (left == right) {
            return;
        } else {
            var l = merge(arr, left, left + Math.floor((right - left) / 2));
            var r = merge(arr, left + Math.floor((right - left) / 2) + 1, right);
            sort(arr, left, left + Math.floor((right - left) / 2), left + Math.floor((right - left) / 2) + 1, right);
        }
    }

    function flip(arr, left, right) {
        var tmp = arr[left];
        arr[left] = arr[right];
        arr[right] = tmp;
    }

    function sort(arr, l, lm, rm, r) {
        var sortedSubArray = [];
        var lArr = arr.slice(l, lm + 1);
        var rArr = arr.slice(rm, r + 1);

        while (lArr[0] || rArr[0]) {
            if (lArr[0] && rArr[0]) {
                if (lArr[0] < rArr[0]) {
                    sortedSubArray.push(lArr.shift());
                } else {
                    sortedSubArray.push(rArr.shift());
                }
            } else if (lArr[0]) {
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

    function sortPair(arr, left, right) {
        if (arr[left] > arr[right]) {
            flip(arr, left, right);
        }
    }
} ());