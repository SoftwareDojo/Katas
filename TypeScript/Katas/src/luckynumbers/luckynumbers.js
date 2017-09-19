"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class LuckyNumbers {
    getLuckyNumbers(range) {
        return this.toString(this.findLuckyNumbers(range));
    }
    getLuckyPrimeNumbers(range) {
        var numbers = this.findLuckyNumbers(range);
        for (let i = 0; i < numbers.length; i++) {
            if (numbers[i])
                continue;
            numbers[i] = !this.isPrime(i + 1);
        }
        return this.toString(numbers);
    }
    findLuckyNumbers(range) {
        var numbers = this.getNumbersArray(range);
        var luckyCounter = 2;
        while (luckyCounter < range) {
            luckyCounter = this.strikeOutNumbers(numbers, luckyCounter);
        }
        return numbers;
    }
    strikeOutNumbers(numbers, luckyCounter) {
        var strikeCounter = 0;
        for (let i = 0; i < numbers.length; i++) {
            if (numbers[i])
                continue;
            strikeCounter++;
            if (strikeCounter === luckyCounter) {
                numbers[i] = true;
                strikeCounter = 0;
            }
        }
        return this.getLuckyCounter(numbers, luckyCounter);
    }
    getLuckyCounter(numbers, luckyCounter) {
        var numbersLength = numbers.length;
        if (luckyCounter >= numbersLength)
            return numbersLength;
        for (let i = luckyCounter; i < numbersLength; i++) {
            if (!numbers[i])
                return i + 1;
        }
        return numbersLength;
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
    toString(numbers) {
        var result = "";
        for (let i = 0; i < numbers.length; i++) {
            if (!numbers[i])
                result += (i + 1) + ",";
        }
        if (result)
            result = result.substring(0, result.length - 1);
        return result;
    }
    getNumbersArray(range) {
        var numbers = [];
        for (let i = 0; i < range; i++) {
            numbers.push(false);
        }
        return numbers;
    }
}
exports.LuckyNumbers = LuckyNumbers;
//# sourceMappingURL=luckynumbers.js.map