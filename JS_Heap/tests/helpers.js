var helpers = (function () {
    'use strict';

    function getEmptyHeap() {
        return heap.init(function (right, left) {
            return right > left;
        });
    };

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    var maxNumberComparator = function (right, left) {
        return left > right;
    };

    var minNumberComparator = function (right, left) {
        return left < right;
    };

    function randomString(length) {
        var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
        var randomstring = '';
        for (var i = 0; i < length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }

        return randomstring;
    }

    function randomStringArray(length) {
        var arr = [];

        for (var i = 0; i < length; i++) {
            arr.push(randomString(Math.floor(Math.random() * 20 + 1)));
        }
    }

    return {
        getEmptyHeap: getEmptyHeap,
        getRandomInt: getRandomInt,
        maxNumberComparator: maxNumberComparator,
        minNumberComparator: minNumberComparator,
        randomString: randomString,
        randomStringArray: randomStringArray
    }
} ());