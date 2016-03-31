var FizzBuzz = (function () {
    function FizzBuzz() {
    }
    FizzBuzz.prototype.doFizzBuzz = function (value) {
        var result = "";
        if (value <= 0)
            return result;
        if (value % 3 === 0)
            result = "fizz";
        if (value % 5 === 0)
            result += "buzz";
        return !result ? value.toString() : result;
    };
    FizzBuzz.prototype.doFizzBuzzExtended = function (value) {
        var result = "";
        if (value <= 0)
            return result;
        var text = value.toString();
        if (value % 3 === 0 || text.search("3") !== -1)
            result = "fizz";
        if (value % 5 === 0 || text.search("5") !== -1)
            result += "buzz";
        return !result ? text : result;
    };
    return FizzBuzz;
}());
//# sourceMappingURL=fizzbuzz.js.map