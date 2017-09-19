"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const assert = require("assert");
const luckynumbers_1 = require("./luckynumbers");
function getLuckyNumbers() {
    assertLuckyNumbers(-1, "");
    assertLuckyNumbers(0, "");
    assertLuckyNumbers(1, "1");
    assertLuckyNumbers(10, "1,3,7,9");
    assertLuckyNumbers(30, "1,3,7,9,13,15,21,25");
    assertLuckyNumbers(100, "1,3,7,9,13,15,21,25,31,33,37,43,49,51,63,67,69,73,75,79,87,93,99");
}
exports.getLuckyNumbers = getLuckyNumbers;
function getLuckyPrimeNumbers() {
    assertLuckyPrimeNumbers(-1, "");
    assertLuckyPrimeNumbers(0, "");
    assertLuckyPrimeNumbers(1, "");
    assertLuckyPrimeNumbers(10, "3,7");
    assertLuckyPrimeNumbers(30, "3,7,13");
    assertLuckyPrimeNumbers(100, "3,7,13,31,37,43,67,73,79");
}
exports.getLuckyPrimeNumbers = getLuckyPrimeNumbers;
function assertLuckyNumbers(value, expected) {
    var actual = new luckynumbers_1.LuckyNumbers().getLuckyNumbers(value);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}
function assertLuckyPrimeNumbers(value, expected) {
    var actual = new luckynumbers_1.LuckyNumbers().getLuckyPrimeNumbers(value);
    assert.equal(new luckynumbers_1.LuckyNumbers().getLuckyPrimeNumbers(value), expected, value + " should return " + expected + " but was " + actual);
}
//# sourceMappingURL=luckynumbers.spec.js.map