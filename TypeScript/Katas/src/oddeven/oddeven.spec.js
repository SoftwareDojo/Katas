"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const assert = require("assert");
const oddeven_1 = require("./oddeven");
function oddEvenReturnNumber() {
    assertOddEven(3, "3");
    assertOddEven(5, "5");
    assertOddEven(7, "7");
}
exports.oddEvenReturnNumber = oddEvenReturnNumber;
function oddEvenReturnOdd() {
    assertOddEven(1, oddeven_1.OddEven.odd);
    assertOddEven(9, oddeven_1.OddEven.odd);
}
exports.oddEvenReturnOdd = oddEvenReturnOdd;
function oddEvenReturnEven() {
    assertOddEven(2, oddeven_1.OddEven.even);
    assertOddEven(4, oddeven_1.OddEven.even);
    assertOddEven(6, oddeven_1.OddEven.even);
    assertOddEven(8, oddeven_1.OddEven.even);
    assertOddEven(10, oddeven_1.OddEven.even);
}
exports.oddEvenReturnEven = oddEvenReturnEven;
function oddEvenRange() {
    var actual = new oddeven_1.OddEven().convertRange(1, 10);
    var expected = "Odd Even 3 Even 5 Even 7 Even Odd Even";
    assert.equal(actual, expected, "ConvertRange(1,10) should return " + expected + " but was " + actual);
}
exports.oddEvenRange = oddEvenRange;
function assertOddEven(value, expected) {
    var actual = new oddeven_1.OddEven().convert(value);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}
//# sourceMappingURL=oddeven.spec.js.map