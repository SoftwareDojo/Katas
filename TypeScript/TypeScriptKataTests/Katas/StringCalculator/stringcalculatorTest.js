/// <reference path="../../Scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../TypeScriptKatas/StringCalculator/stringcalculator.ts" />
describe("StringCalculator", function () {
    var calc = new StringCalculator();
    it("Add with \"\" should return 0", function () {
        expect(calc.add("", ",")).toBe(0);
    });
    it("Add with \"15\" should return 15", function () {
        expect(calc.add("15", ",")).toBe(15);
    });
    it("Add with \"1,2\" should return 3", function () {
        expect(calc.add("1,2", ",")).toBe(3);
    });
    it("Add with \"1,2,3\" should return 6", function () {
        expect(calc.add("1,2,3", ",")).toBe(6);
    });
    it("Add with \"1,2,3,4,5,6,7,8,9\" should return 45", function () {
        expect(calc.add("1,2,3,4,5,6,7,8,9", ",")).toBe(45);
    });
    it("Add with \"dgdgdg\" should return 0", function () {
        expect(calc.add("dgdgdg", ",")).toBe(0);
    });
    it("Add with \",\" should return 0", function () {
        expect(calc.add(",", ",")).toBe(0);
    });
    it("Add with \"1,  ,2\" should return 3", function () {
        expect(calc.add("1,  ,2", ",")).toBe(3);
    });
    it("Add with \"dgdgdg,2\" should return 2", function () {
        expect(calc.add("dgdgdg,2", ",")).toBe(2);
    });
    it("Add with \"asdad1,fgdgf,8\" should return 8", function () {
        expect(calc.add("asdad1,fgdgf,8", ",")).toBe(8);
    });
});
describe("StringCalculator_with_sharp", function () {
    var calc = new StringCalculator();
    it("Add with \"1#2\" should return 3", function () {
        expect(calc.add("1#2", "#")).toBe(3);
    });
});
//# sourceMappingURL=stringcalculatorTest.js.map