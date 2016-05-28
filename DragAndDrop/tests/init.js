// uncomment to use via mocha
var assert = chai.assert;
var expect = chai.expect;

describe('heap.init()', function () {

    it('should return object', function () {
        var heapObject = heap.init(function (right, left) {
            return right.length > left.length;
        });

        expect(typeof heapObject === 'object').to.be.true;
    });

    it('should throw if no comparator is given', function () {
        assert.throw(function () {
            heap.init();
        }, Error);
    });

    it('should throw if the comparator is not a function', function () {
        expect(function () {
            heap.init("some string");
        }).to.throw(Error);
    });

    it('should not to throw if a comparator is provided', function () {
        expect(function () {
            heap.init(function () { });
        }).to.not.throw(Error);
    });
});