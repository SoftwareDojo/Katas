"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const assert = require("assert");
const stringcalculator_1 = require("./stringcalculator");
function stringCalculator() {
    assertAdd("15", 15);
    assertAdd("1,2", 3);
    assertAdd("1,2,3", 6);
    assertAdd("1,2,3,4,5,6,7,8,9", 45);
}
exports.stringCalculator = stringCalculator;
function stringCalculatorWithInvalidParameters() {
    assertAdd("", 0);
    assertAdd(",", 0);
    assertAdd("dgdgdg", 0);
    assertAdd("1,  ,2", 3);
    assertAdd("dgdgdg,2", 2);
    assertAdd("asdad1,fgdgf,8", 8);
}
exports.stringCalculatorWithInvalidParameters = stringCalculatorWithInvalidParameters;
function stringCalculatorWithSharp() {
    assertAddWithSeperator("1#2#3", "#", 6);
}
exports.stringCalculatorWithSharp = stringCalculatorWithSharp;
function assertAdd(value, expected) {
    assertAddWithSeperator(value, ",", expected);
}
function assertAddWithSeperator(value, seperator, expected) {
    var actual = new stringcalculator_1.StringCalculator().add(value, seperator);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}
//# sourceMappingURL=stringcalculator.spec.js.map