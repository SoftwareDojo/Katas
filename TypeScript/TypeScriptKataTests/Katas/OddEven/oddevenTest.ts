/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../TypeScriptKatas/OddEven/oddeven.ts" />
/// <reference path="../../Libs/collections.ts"/>
 
describe("OddEven", () => {

    var odd = "Odd";
    var even = "Even";
    var oddeven = new OddEven();

    it("oddeven with 1 should return Odd string", () => {
        expect(oddeven.convert(1)).toBe(odd);
    });

    it("oddeven with 2 should return Even string", () => {
        expect(oddeven.convert(2)).toBe(even);
    });

    it("oddeven with 3 should return 3 string", () => {
        expect(oddeven.convert(3)).toBe("3");
    });

    it("oddeven with 4 should return Even string", () => {
        expect(oddeven.convert(4)).toBe(even);
    });

    it("oddeven with 5 should return 5 string", () => {
        expect(oddeven.convert(5)).toBe("5");
    });

    it("oddeven with 6 should return Even string", () => {
        expect(oddeven.convert(6)).toBe(even);
    });

    it("oddeven with 7 should return 7 string", () => {
        expect(oddeven.convert(7)).toBe("7");
    });

    it("oddeven with 8 should return Even string", () => {
        expect(oddeven.convert(8)).toBe(even);
    });

    it("oddeven with 9 should return Odd string", () => {
        expect(oddeven.convert(9)).toBe(odd);
    });

    it("oddeven with 10 should return Even string", () => {
        expect(oddeven.convert(10)).toBe(even);
    });
});

describe("OddEvenRange", () => {

    var oddeven = new OddEven();

    it("oddeven range with start 1 and end 10 should return a valid string", () => {
        expect(oddeven.convertRange(1, 10)).toBe("Odd Even 3 Even 5 Even 7 Even Odd Even");
    });
});

describe("OddEven with String", () => {

    var odd = "Odd";
    var even = "Even";
    var oddeven = new OddEven();

    it("oddeven with 1 should return Odd string", () => {
        expect(oddeven.convertWithString(1)).toBe(odd);
    });

    it("oddeven with 2 should return Even string", () => {
        expect(oddeven.convertWithString(2)).toBe(even);
    });

    it("oddeven with 3 should return 3 string", () => {
        expect(oddeven.convertWithString(3)).toBe("3");
    });

    it("oddeven with 4 should return Even string", () => {
        expect(oddeven.convertWithString(4)).toBe(even);
    });

    it("oddeven with 5 should return 5 string", () => {
        expect(oddeven.convertWithString(5)).toBe("5");
    });

    it("oddeven with 6 should return Even string", () => {
        expect(oddeven.convertWithString(6)).toBe(even);
    });

    it("oddeven with 7 should return 7 string", () => {
        expect(oddeven.convertWithString(7)).toBe("7");
    });

    it("oddeven with 8 should return Even string", () => {
        expect(oddeven.convertWithString(8)).toBe(even);
    });

    it("oddeven with 9 should return Odd string", () => {
        expect(oddeven.convertWithString(9)).toBe(odd);
    });

    it("oddeven with 10 should return Even string", () => {
        expect(oddeven.convertWithString(10)).toBe(even);
    });
});

describe("StringUtilities", () => {

    it("ends with 3", () => {
        expect(StringUtilities.endsWith("3","3")).toBe(true);
    });
});