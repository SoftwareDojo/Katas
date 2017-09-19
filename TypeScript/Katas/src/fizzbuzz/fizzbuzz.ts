export class FizzBuzz {

    static readonly fizz = "fizz";
    static readonly buzz = "buzz";

    doFizzBuzz(value: number): string {

        var result = "";
        if (value <= 0) return result;

        if (value % 3 === 0) result = FizzBuzz.fizz;
        if (value % 5 === 0) result += FizzBuzz.buzz;

        return !result ? value.toString() : result;
    }

    doFizzBuzzExtended(value: number): string {

        var result = "";
        if (value <= 0) return result;
        var text = value.toString();

        if (value % 3 === 0 || text.search("3") !== -1) result = FizzBuzz.fizz;
        if (value % 5 === 0 || text.search("5") !== -1) result += FizzBuzz.buzz;

        return !result ? text : result;
    }
}