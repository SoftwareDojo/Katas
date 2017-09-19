export class OddEven {

    static readonly even = "Even";
    static readonly odd = "Odd";

    convert(num: number): string {

        if (num % 2 === 0) return OddEven.even;
        if (this.isPrime(num)) return num.toString();

        return OddEven.odd;
    }

    convertRange(start: number, end: number): string {

        var result = "";

        for (let i = start; i <= end; i++) {
            result += this.convert(i) + " ";
        }

        return result.trim();
    }

    private isPrime(num: number): boolean {

        if (num === 1) return false;

        for (let i = 3; i <= Math.sqrt(num); i += 2) {
            if (num % i === 0) return false;
        }

        return true;
    }
}