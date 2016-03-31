/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../TypeScriptKatas/FizzBuzz/fizzbuzz.ts" />
describe("FizzBuzz", function () {
    var fizzbuzz = new FizzBuzz();
    it("fizzbuzz with 0 should return empty string", function () {
        expect(fizzbuzz.doFizzBuzz(0)).toBe("");
    });
    it("fizzbuzz with 1 should return 1", function () {
        expect(fizzbuzz.doFizzBuzz(1)).toBe("1");
    });
    it("fizzbuzz with 2 should return 2", function () {
        expect(fizzbuzz.doFizzBuzz(2)).toBe("2");
    });
    it("fizzbuzz with 3 should return fizz", function () {
        expect(fizzbuzz.doFizzBuzz(3)).toBe("fizz");
    });
    it("fizzbuzz with 4 should return 4", function () {
        expect(fizzbuzz.doFizzBuzz(4)).toBe("4");
    });
    it("fizzbuzz with 5 should return buzz", function () {
        expect(fizzbuzz.doFizzBuzz(5)).toBe("buzz");
    });
    it("fizzbuzz with 6 should return fizz", function () {
        expect(fizzbuzz.doFizzBuzz(6)).toBe("fizz");
    });
    it("fizzbuzz with 10 should return buzz", function () {
        expect(fizzbuzz.doFizzBuzz(10)).toBe("buzz");
    });
    it("fizzbuzz with 15 should return fizzbuzz", function () {
        expect(fizzbuzz.doFizzBuzz(15)).toBe("fizzbuzz");
    });
});
describe("FizzBuzz extended", function () {
    var fizzbuzz = new FizzBuzz();
    it("fizzbuzz extended with 0 should return empty string", function () {
        expect(fizzbuzz.doFizzBuzzExtended(0)).toBe("");
    });
    it("fizzbuzz extended with 1 should return 1", function () {
        expect(fizzbuzz.doFizzBuzzExtended(1)).toBe("1");
    });
    it("fizzbuzz extended with 2 should return 2", function () {
        expect(fizzbuzz.doFizzBuzzExtended(2)).toBe("2");
    });
    it("fizzbuzz extended with 3 should return fizz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(3)).toBe("fizz");
    });
    it("fizzbuzz extended with 4 should return 4", function () {
        expect(fizzbuzz.doFizzBuzzExtended(4)).toBe("4");
    });
    it("fizzbuzz extended with 5 should return buzz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(5)).toBe("buzz");
    });
    it("fizzbuzz extended with 6 should return fizz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(6)).toBe("fizz");
    });
    it("fizzbuzz extended with 10 should return buzz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(10)).toBe("buzz");
    });
    it("fizzbuzz extended with 13 should return fizz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(13)).toBe("fizz");
    });
    it("fizzbuzz extended with 15 should return fizzbuzz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(15)).toBe("fizzbuzz");
    });
    it("fizzbuzz extended with 25 should return buzz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(25)).toBe("buzz");
    });
    it("fizzbuzz extended with 35 should return fizzbuzz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(35)).toBe("fizzbuzz");
    });
    it("fizzbuzz extended with 52 should return buzz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(52)).toBe("buzz");
    });
    it("fizzbuzz extended with 53 should return fizzbuzz", function () {
        expect(fizzbuzz.doFizzBuzzExtended(53)).toBe("fizzbuzz");
    });
});
//# sourceMappingURL=fizzbuzzTest.js.map