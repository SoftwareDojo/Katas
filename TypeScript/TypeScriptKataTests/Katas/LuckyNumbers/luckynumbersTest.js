/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../TypeScriptKatas/LuckyNumbers/luckynumbers.ts" />
describe("LuckyNumbers", function () {
    var luckyNumbers = new LuckyNumbers();
    it("LuckyNumbers with -1 should return a empty string", function () {
        expect(luckyNumbers.getLuckyNumbers(-1)).toBe("");
    });
    it("LuckyNumbers with 0 should return a empty string", function () {
        expect(luckyNumbers.getLuckyNumbers(0)).toBe("");
    });
    it("LuckyNumbers with 1 should return the expected string", function () {
        expect(luckyNumbers.getLuckyNumbers(1)).toBe("1");
    });
    it("LuckyNumbers with 10 should return the expected string", function () {
        expect(luckyNumbers.getLuckyNumbers(10)).toBe("1,3,7,9");
    });
    it("LuckyNumbers with 30 should return the expected string", function () {
        expect(luckyNumbers.getLuckyNumbers(30)).toBe("1,3,7,9,13,15,21,25");
    });
    it("LuckyNumbers with 100 should return the expected string", function () {
        expect(luckyNumbers.getLuckyNumbers(100)).toBe("1,3,7,9,13,15,21,25,31,33,37,43,49,51,63,67,69,73,75,79,87,93,99");
    });
});
describe("LuckyPrimeNumbers", function () {
    var luckyNumbers = new LuckyNumbers();
    it("LuckyPrimeNumbers with -1 should return a empty string", function () {
        expect(luckyNumbers.getLuckyPrimeNumbers(-1)).toBe("");
    });
    it("LuckyPrimeNumbers with 0 should return a empty string", function () {
        expect(luckyNumbers.getLuckyPrimeNumbers(0)).toBe("");
    });
    it("LuckyPrimeNumbers with 1 should return the expected string", function () {
        expect(luckyNumbers.getLuckyPrimeNumbers(1)).toBe("");
    });
    it("LuckyPrimeNumbers with 10 should return the expected string", function () {
        expect(luckyNumbers.getLuckyPrimeNumbers(10)).toBe("3,7");
    });
    it("LuckyPrimeNumbers with 30 should return the expected string", function () {
        expect(luckyNumbers.getLuckyPrimeNumbers(30)).toBe("3,7,13");
    });
    it("LuckyPrimeNumbers with 100 should return the expected string", function () {
        expect(luckyNumbers.getLuckyPrimeNumbers(100)).toBe("3,7,13,31,37,43,67,73,79");
    });
});
//# sourceMappingURL=luckynumbersTest.js.map