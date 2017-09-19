"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const assert = require("assert");
const oddeven_1 = require("./oddeven");
function testOddEvenReturnNumber() {
    assertOddEven(1, "1");
    assertOddEven(2, "2");
    assertOddEven(3, "3");
}
exports.testOddEvenReturnNumber = testOddEvenReturnNumber;
function assertOddEven(value, expected) {
    assert.equal(new oddeven_1.OddEven().convert(value), expected, value + " should return " + expected);
}
//# sourceMappingURL=UnitTest1.js.map