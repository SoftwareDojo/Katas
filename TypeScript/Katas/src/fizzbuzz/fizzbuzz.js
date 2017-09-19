"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class FizzBuzz {
    doFizzBuzz(value) {
        var result = "";
        if (value <= 0)
            return result;
        if (value % 3 === 0)
            result = FizzBuzz.fizz;
        if (value % 5 === 0)
            result += FizzBuzz.buzz;
        return !result ? value.toString() : result;
    }
    doFizzBuzzExtended(value) {
        var result = "";
        if (value <= 0)
            return result;
        var text = value.toString();
        if (value % 3 === 0 || text.search("3") !== -1)
            result = FizzBuzz.fizz;
        if (value % 5 === 0 || text.search("5") !== -1)
            result += FizzBuzz.buzz;
        return !result ? text : result;
    }
}
FizzBuzz.fizz = "fizz";
FizzBuzz.buzz = "buzz";
exports.FizzBuzz = FizzBuzz;
//# sourceMappingURL=fizzbuzz.js.map