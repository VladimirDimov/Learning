// var arr = [2, 1, 3, 5, 4, 6];
var arr = [4, 3, 8, 9, 11, 2, 1];
console.log(arr);

mergeSorter.sort(arr, function (l, r) {
    return l > r;
});
console.log(arr);