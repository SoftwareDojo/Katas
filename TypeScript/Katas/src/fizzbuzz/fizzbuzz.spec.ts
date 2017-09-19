import * as assert from 'assert';
import { FizzBuzz } from './fizzbuzz';

export function doFizzBuzzReturnEmpty() {
    assertFizzBuzz(-1, "");
    assertFizzBuzz(0, "");
}

export function doFizzBuzzReturnNumber() {
    assertFizzBuzz(1, "1");
    assertFizzBuzz(2, "2");
    assertFizzBuzz(4, "4");
}

export function doFizzBuzzReturnFizz() {
    assertFizzBuzz(3, FizzBuzz.fizz);
    assertFizzBuzz(6, FizzBuzz.fizz);
}

export function doFizzBuzzReturnBuzz() {
    assertFizzBuzz(5, FizzBuzz.buzz);
    assertFizzBuzz(10, FizzBuzz.buzz);
}

export function doFizzBuzzReturnFizzBuzz() {
    assertFizzBuzz(15, FizzBuzz.fizz + FizzBuzz.buzz);
}

export function doFizzBuzzExtendedReturnEmpty() {
    assertFizzBuzz(-1, "");
    assertFizzBuzz(0, "");
}

export function doFizzBuzzExtendedReturnNumber() {
    assertFizzBuzzExtended(1, "1");
    assertFizzBuzzExtended(2, "2");
    assertFizzBuzzExtended(4, "4");
}

export function doFizzBuzzExtendedReturnFizz() {
    assertFizzBuzzExtended(3, FizzBuzz.fizz);
    assertFizzBuzzExtended(6, FizzBuzz.fizz);
    assertFizzBuzzExtended(13, FizzBuzz.fizz);
}

export function doFizzBuzzExtendedReturnBuzz() {
    assertFizzBuzzExtended(5, FizzBuzz.buzz);
    assertFizzBuzzExtended(10, FizzBuzz.buzz);
    assertFizzBuzzExtended(25, FizzBuzz.buzz);
    assertFizzBuzzExtended(52, FizzBuzz.buzz);
}

export function doFizzBuzzExtendedReturnFizzBuzz() {
    assertFizzBuzzExtended(15, FizzBuzz.fizz + FizzBuzz.buzz);
    assertFizzBuzzExtended(35, FizzBuzz.fizz + FizzBuzz.buzz);
    assertFizzBuzzExtended(53, FizzBuzz.fizz + FizzBuzz.buzz);
}

function assertFizzBuzz(value: number, expected: string) {
    var actual = new FizzBuzz().doFizzBuzz(value);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}

function assertFizzBuzzExtended(value: number, expected: string) {
    var actual = new FizzBuzz().doFizzBuzzExtended(value);
    assert.equal(actual, expected, value + " should return " + expected + " but was " + actual);
}
