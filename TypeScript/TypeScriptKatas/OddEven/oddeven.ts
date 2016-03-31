class OddEven {
    
    even = "Even";
    odd = "Odd";

    convert(num: number): string {

        if (num % 2 === 0) return this.even;
        if (this.isPrime(num)) return num.toString();

        return this.odd;
    }

    convertRange(start: number, end: number): string {

        var result = "";

        for (let i = start; i <= end; i++) {
            result += this.convert(i) + " ";
        }

        return result.trim();
    }

    convertWithString(num: number): string {

        var numString = num.toString();

        if (StringUtilities.endsWith(numString, "0") ||
            StringUtilities.endsWith(numString, "2") ||
            StringUtilities.endsWith(numString, "4") ||
            StringUtilities.endsWith(numString, "6") ||
            StringUtilities.endsWith(numString, "8"))
            return this.even;

        return this.isPrime(num) ? numString : this.odd;
    }

    private isPrime(num: number): boolean {

        if (num === 1) return false;

        for (let i = 3; i <= Math.sqrt(num); i += 2) {
            if (num % i === 0) return false;
        }

        return true;
    }
}

class StringUtilities {

    static endsWith(source: string, value: string): boolean {

        return source.substring(source.length - value.length, source.length) === value;
    }
}