"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const assert = require("assert");
const fizzbuzz_1 = require("./fizzbuzz");
function doFizzBuzzReturnEmpty() {
    assertFizzBuzz(-1, "");
    assertFizzBuzz(0, "");
}
exports.doFizzBuzzReturnEmpty = doFizzBuzzReturnEmpty;
function doFizzBuzzReturnNumber() {
    assertFizzBuzz(1, "1");
    assertFizzBuzz(2, "2");
    assertFizzBuzz(4, "4");
}
exports.doFizzBuzzReturnNumber = doFizzBuzzReturnNumber;
function doFizzBuzzReturnFizz() {
    assertFizzBuzz(3, fizzbuzz_1.FizzBuzz.fizz);
    assertFizzBuzz(6, fizzbuzz_1.FizzBuzz.fizz);
}
exports.doFizzBuzzReturnFizz = doFizzBuzzReturnFizz;
function doFizzBuzzReturnBuzz() {
    assertFizzBuzz(5, fizzbuzz_1.FizzBuzz.buzz);
    assertFizzBuzz(10, fizzbuzz_1.FizzBuzz.buzz);
}
exports.doFizzBuzzReturnBuzz = doFizzBuzzReturnBuzz;
function doFizzBuzzReturnFizzBuzz() {
    assertFizzBuzz(15, fizzbuzz_1.FizzBuzz.fizz + fizzbuzz_1.FizzBuzz.buzz);
}
exports.doFizzBuzzReturnFizzBuzz = doFizzBuzzReturnFizzBuzz;
function doFizzBuzzExtendedReturnEmpty() {
    assertFizzBuzz(-1, "");
    assertFizzBuzz(0, "");
}
exports.doFizzBuzzExtendedReturnEmpty = doFizzBuzzExtendedReturnEmpty;
function doFizzBuzzExtendedReturnNumber() {
    assertFizzBuzzExtended(1, "1");
    assertFizzBuzzExtended(2, "2");
    assertFizzBuzzExtended(4, "4");
}
exports.doFizzBuzzExtendedReturnNumber = doFizzBuzzExtendedReturnNumber;
function doFizzBuzzExtendedReturnFizz() {
    assertFizzBuzzExtended(3, fizzbuzz_1.FizzBuzz.fizz);
    assertFizzBuzzExtended(6, fizzbuzz_1.FizzBuzz.fizz);
    assertFizzBuzzExtended(13, fizzbuzz_1.FizzBuzz.fizz);
}
exports.doFizzBuzzExtendedReturnFizz = doFizzBuzzExtendedReturnFizz;
function doFizzBuzzExtendedReturnBuzz() {
    assertFizzBuzzExtended(5, fizzbuzz_1.FizzBuzz.buzz);
    assertFizzBuzzExtended(10, fizzbuzz_1.FizzBuzz.buzz);
    assertFizzBuzzExtended(25, fizzbuzz_1.FizzBuzz.buzz);
    assertFizzBuzzExtended(52, fizzbuzz_1.FizzBuzz.buzz);
}
exports.doFizzBuzzExtendedReturnBuzz = doFizzBuzzExtendedReturnBuzz;
function doFizzBuzzExtendedReturnFizzBuzz() {
    assertFizzBuzzExtended(15, fizzbuzz_1.FizzBuzz.fizz + fizzbuzz_1.FizzBuzz.buzz);
    assertFizzBuzzExtended(35, fizzbuzz_1.FizzBuzz.fizz + fizzbuzz_1.FizzBuzz.buzz);
    assertFizzBuzzExtended(53, fizzbuzz_1.FizzBuzz.fizz + fizzbuzz_1.FizzBuzz.buzz);
}
exports.doFizzBuzzExtendedReturnFizzBuzz = doFizzBuzzExtendedReturnFizzBuzz;
function assertFizzBuzz(value, expected) {
    var actual = new fizzbuzz_1.FizzBuzz().doFizzBuzz(value);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}
function assertFizzBuzzExtended(value, expected) {
    var actual = new fizzbuzz_1.FizzBuzz().doFizzBuzzExtended(value);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}
//# sourceMappingURL=fizzbuzz.spec.js.map