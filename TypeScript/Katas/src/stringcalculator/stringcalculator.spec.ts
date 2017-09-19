import * as assert from 'assert';
import { StringCalculator } from './stringcalculator'

export function stringCalculator() {
    assertAdd("15", 15);
    assertAdd("1,2", 3);
    assertAdd("1,2,3", 6);
    assertAdd("1,2,3,4,5,6,7,8,9", 45);
}

export function stringCalculatorWithInvalidParameters() {
    assertAdd("", 0);
    assertAdd(",", 0);
    assertAdd("dgdgdg", 0);
    assertAdd("1,  ,2", 3);
    assertAdd("dgdgdg,2", 2);
    assertAdd("asdad1,fgdgf,8", 8);
}

export function stringCalculatorWithSharp() {
    assertAddWithSeperator("1#2#3", "#", 6);
}

function assertAdd(value: string, expected: number) {
    assertAddWithSeperator(value, ",", expected);
}

function assertAddWithSeperator(value: string, seperator: string, expected: number) {
    var actual = new StringCalculator().add(value, seperator);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}
