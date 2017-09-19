"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class StringCalculator {
    add(value, seperator) {
        var result = 0;
        if (!value)
            return result;
        var numbers = value.split(seperator);
        for (var i = 0; i < numbers.length; i++) {
            if (!numbers[i])
                continue;
            var number = parseInt(numbers[i]);
            if (isNaN(number))
                continue;
            result = result + number;
        }
        return result;
    }
}
exports.StringCalculator = StringCalculator;
//# sourceMappingURL=stringcalculator.js.map