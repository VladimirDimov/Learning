// uncomment to use via mocha
var assert = chai.assert;
var expect = chai.expect;

function getEmptyHeap() {
    return heap.init(function (right, left) {
        return right < left;
    });
}

describe('heap.push()', function () {
    
    it('should be a function', function() {
        var heap = getEmptyHeap();
        expect(typeof heap.push).to.equal('function');
    })

    it('should add item to heap.elements', function () {
        var heap = getEmptyHeap();

        for (var i = 1; i < 100; i++) {
            heap.push(i);
            expect(heap.elements.length).to.equal(i);
        }
    });
});