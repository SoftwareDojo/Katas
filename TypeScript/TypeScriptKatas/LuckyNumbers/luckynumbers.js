var LuckyNumbers = (function () {
    function LuckyNumbers() {
    }
    LuckyNumbers.prototype.getLuckyNumbers = function (range) {
        return this.toString(this.findLuckyNumbers(range));
    };
    LuckyNumbers.prototype.getLuckyPrimeNumbers = function (range) {
        var numbers = this.findLuckyNumbers(range);
        for (var i = 0; i < numbers.length; i++) {
            if (numbers[i])
                continue;
            numbers[i] = !this.isPrime(i + 1);
        }
        return this.toString(numbers);
    };
    LuckyNumbers.prototype.findLuckyNumbers = function (range) {
        var numbers = this.getNumbersArray(range);
        var luckyCounter = 2;
        while (luckyCounter < range) {
            luckyCounter = this.strikeOutNumbers(numbers, luckyCounter);
        }
        return numbers;
    };
    LuckyNumbers.prototype.strikeOutNumbers = function (numbers, luckyCounter) {
        var strikeCounter = 0;
        for (var i = 0; i < numbers.length; i++) {
            if (numbers[i])
                continue;
            strikeCounter++;
            if (strikeCounter === luckyCounter) {
                numbers[i] = true;
                strikeCounter = 0;
            }
        }
        return this.getLuckyCounter(numbers, luckyCounter);
    };
    LuckyNumbers.prototype.getLuckyCounter = function (numbers, luckyCounter) {
        var numbersLength = numbers.length;
        if (luckyCounter >= numbersLength)
            return numbersLength;
        for (var i = luckyCounter; i < numbersLength; i++) {
            if (!numbers[i])
                return i + 1;
        }
        return numbersLength;
    };
    LuckyNumbers.prototype.isPrime = function (num) {
        if (num === 1)
            return false;
        for (var i = 3; i <= Math.sqrt(num); i += 2) {
            if (num % i === 0)
                return false;
        }
        return true;
    };
    LuckyNumbers.prototype.toString = function (numbers) {
        var result = "";
        for (var i = 0; i < numbers.length; i++) {
            if (!numbers[i])
                result += (i + 1) + ",";
        }
        if (result)
            result = result.substring(0, result.length - 1);
        return result;
    };
    LuckyNumbers.prototype.getNumbersArray = function (range) {
        var numbers = [];
        for (var i = 0; i < range; i++) {
            numbers.push(false);
        }
        return numbers;
    };
    return LuckyNumbers;
}());
//# sourceMappingURL=luckynumbers.js.map