namespace Katas

module FizzBuzz =

    let fizzbuzz n = 
        if n <= 0 then ""
        else
            match (n % 3) = 0, (n % 5) = 0 with
                | true,false -> "fizz"
                | false,true -> "buzz"
                | true,true -> "fizzbuzz"
                | false,false -> n.ToString()
            
