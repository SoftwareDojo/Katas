var OddEven = (function () {
    function OddEven() {
        this.even = "Even";
        this.odd = "Odd";
    }
    OddEven.prototype.convert = function (num) {
        if (num % 2 === 0)
            return this.even;
        if (this.isPrime(num))
            return num.toString();
        return this.odd;
    };
    OddEven.prototype.convertRange = function (start, end) {
        var result = "";
        for (var i = start; i <= end; i++) {
            result += this.convert(i) + " ";
        }
        return result.trim();
    };
    OddEven.prototype.convertWithString = function (num) {
        var numString = num.toString();
        if (StringUtilities.endsWith(numString, "0") ||
            StringUtilities.endsWith(numString, "2") ||
            StringUtilities.endsWith(numString, "4") ||
            StringUtilities.endsWith(numString, "6") ||
            StringUtilities.endsWith(numString, "8"))
            return this.even;
        return this.isPrime(num) ? numString : this.odd;
    };
    OddEven.prototype.isPrime = function (num) {
        if (num === 1)
            return false;
        for (var i = 3; i <= Math.sqrt(num); i += 2) {
            if (num % i === 0)
                return false;
        }
        return true;
    };
    return OddEven;
}());
var StringUtilities = (function () {
    function StringUtilities() {
    }
    StringUtilities.endsWith = function (source, value) {
        return source.substring(source.length - value.length, source.length) === value;
    };
    return StringUtilities;
}());
//# sourceMappingURL=oddeven.js.map