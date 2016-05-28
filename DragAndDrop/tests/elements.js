// uncomment to use via mocha
var assert = chai.assert;
var expect = chai.expect;

function getEmptyHeap() {
    return heap.init(function (right, left) {
        return right < left;
    });
}

describe('heap.elements', function () {

    it('should return empty array after init', function () {
        var x = heap.init(function (right, left) {
            return right < left;
        });

        expect(typeof x.elements).to.equal('object');
        expect(x.elements.length).to.equal(0);
    });    
});