class FizzBuzz {

    doFizzBuzz(value: number): string {

        var result = "";
        if (value <= 0) return result;

        if (value % 3 === 0) result = "fizz";
        if (value % 5 === 0) result += "buzz";

        return !result ? value.toString() : result;
    }

    doFizzBuzzExtended(value: number): string {

        var result = "";
        if (value <= 0) return result;
        var text = value.toString();

        if (value % 3 === 0 || text.search("3") !== -1) result = "fizz";
        if (value % 5 === 0 || text.search("5") !== -1) result += "buzz";

        return !result ? text : result;
    }

}