export class LuckyNumbers {

    getLuckyNumbers(range: number): string {

        return this.toString(this.findLuckyNumbers(range));
    }

    getLuckyPrimeNumbers(range: number): string {

        var numbers = this.findLuckyNumbers(range);

        for (let i = 0; i < numbers.length; i++) {
            if (numbers[i]) continue;
            numbers[i] = !this.isPrime(i + 1);
        }

        return this.toString(numbers);
    }

    private findLuckyNumbers(range: number): boolean[] {

        var numbers = this.getNumbersArray(range);
        var luckyCounter = 2;

        while (luckyCounter < range) {
            luckyCounter = this.strikeOutNumbers(numbers, luckyCounter);
        }

        return numbers;
    }

    private strikeOutNumbers(numbers: boolean[], luckyCounter: number): number {

        var strikeCounter = 0;

        for (let i = 0; i < numbers.length; i++) {
            if (numbers[i]) continue;
            strikeCounter++;

            if (strikeCounter === luckyCounter) {
                numbers[i] = true;
                strikeCounter = 0;
            }
        }

        return this.getLuckyCounter(numbers, luckyCounter);
    }

    private getLuckyCounter(numbers: boolean[], luckyCounter: number): number {

        var numbersLength = numbers.length;
        if (luckyCounter >= numbersLength) return numbersLength;

        for (let i = luckyCounter; i < numbersLength; i++) {
            if (!numbers[i]) return i + 1;
        }

        return numbersLength;
    }

    private isPrime(num: number): boolean {

        if (num === 1) return false;

        for (let i = 3; i <= Math.sqrt(num); i += 2) {
            if (num % i === 0) return false;
        }

        return true;
    }

    private toString(numbers: boolean[]): string {

        var result = "";

        for (let i = 0; i < numbers.length; i++) {
            if (!numbers[i]) result += (i + 1) + ",";
        }

        if (result) result = result.substring(0, result.length - 1);

        return result;
    }

    private getNumbersArray(range: number): boolean[] {

        var numbers: boolean[] = [];
        for (let i = 0; i < range; i++) {
            numbers.push(false);
        }

        return numbers;
    }
}
