var assert = chai.assert;
var expect = chai.expect;

describe('Validation', function () {

    it('should throw if invalid comparator name is provided', function () {
        expect(function () {
            mergeSorter.sort([], helpers.getRandomString(16));
        }).to.throw(Error);
    });

    it('should throw if no array is provided', function () {
        expect(function () {
            mergeSorter.sort(null, 'asc');
        }).to.throw(Error);
    });
});