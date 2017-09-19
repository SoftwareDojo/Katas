"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class OddEven {
    convert(num) {
        if (num % 2 === 0)
            return OddEven.even;
        if (this.isPrime(num))
            return num.toString();
        return OddEven.odd;
    }
    convertRange(start, end) {
        var result = "";
        for (let i = start; i <= end; i++) {
            result += this.convert(i) + " ";
        }
        return result.trim();
    }
    isPrime(num) {
        if (num === 1)
            return false;
        for (let i = 3; i <= Math.sqrt(num); i += 2) {
            if (num % i === 0)
                return false;
        }
        return true;
    }
}
OddEven.even = "Even";
OddEven.odd = "Odd";
exports.OddEven = OddEven;
//# sourceMappingURL=oddeven.js.map