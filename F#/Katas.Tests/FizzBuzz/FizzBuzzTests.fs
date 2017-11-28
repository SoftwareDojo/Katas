module Tests

open System
open Xunit

open Katas

[<Theory>]
[<InlineData(0, "")>]
[<InlineData(1, "1")>]
[<InlineData(2, "2")>]
[<InlineData(3, "fizz")>]
[<InlineData(4, "4")>]
[<InlineData(5, "buzz")>]
[<InlineData(6, "fizz")>]
[<InlineData(10, "buzz")>]
[<InlineData(15, "fizzbuzz")>]
let ``FizzBuzz2`` (value : int, expected : string) =
    Assert.Equal(expected, FizzBuzz.fizzbuzz value)