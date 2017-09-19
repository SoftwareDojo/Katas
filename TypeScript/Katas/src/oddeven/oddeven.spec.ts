import * as assert from 'assert';
import { OddEven } from './oddeven';

export function oddEvenReturnNumber() {
    assertOddEven(3, "3");
    assertOddEven(5, "5");
    assertOddEven(7, "7");
}

export function oddEvenReturnOdd() {
    assertOddEven(1, OddEven.odd);
    assertOddEven(9, OddEven.odd);
}

export function oddEvenReturnEven() {
    assertOddEven(2, OddEven.even);
    assertOddEven(4, OddEven.even);
    assertOddEven(6, OddEven.even);
    assertOddEven(8, OddEven.even);
    assertOddEven(10, OddEven.even);
}

export function oddEvenRange() {
    var actual = new OddEven().convertRange(1, 10);
    var expected = "Odd Even 3 Even 5 Even 7 Even Odd Even";
    assert.equal(actual, expected, "ConvertRange(1,10) should return " + expected + " but was " + actual);
}

function assertOddEven(value: number, expected: string) {
    var actual = new OddEven().convert(value);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}