var helpers = (function () {
    'use strict';

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function areArraysEqual(arr1, arr2, comparator) {
        if (arr1.length != arr2.length) {
            console.log(arr1);
            console.log(arr2);
            return false;
        }

        for (var i = 0, length = arr1.length; i < length; i += 1) {
            if (!comparator(arr1[i], arr2[i])) {
                console.log(arr1);
                console.log(arr2);
                return false;
            }
        }

        return true;
    }

    function getRandomArray(length, valueProvider) {
        var arr = [];
        for (var i = 0; i < length; i += 1) {
            arr.push(valueProvider());
        }

        return arr;
    }

    function maxNumberComparator(right, left) {
        return left > right;
    };

    function minNumberComparator(right, left) {
        return left < right;
    };

    function getRandomString(length) {
        var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
        var randomstring = '';
        for (var i = 0; i < length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }

        return randomstring;
    }

    function getRandomStringArray(arrayLength, stringMinLength, stringMaxLength) {
        var arr = [];

        for (var i = 0; i < length; i++) {
            arr.push(randomString(Math.floor(Math.random() * stringMaxLength + stringMinLength)));
        }
    }

    return {
        getRandomInt: getRandomInt,
        maxNumberComparator: maxNumberComparator,
        minNumberComparator: minNumberComparator,
        getRandomString: getRandomString,
        getRandomStringArray: getRandomStringArray,
        getRandomArray: getRandomArray,
        areArraysEqual: areArraysEqual
    };
} ());