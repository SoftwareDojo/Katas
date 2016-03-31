import math

class OddEven(object):

    Even = ("""Even""")
    Odd = ("""Odd""")

    def convert(number):
        if number % 2 == 0:
            return OddEven.Even
        if OddEven.__is_prime(number):
            return number

        return OddEven.Odd

    def convert_range(start, stop):
        result = ""
        for x in range(start, stop):
            result += str(OddEven.convert(x)) + " "
        return result.rstrip()

    def convert_with_string(number):

        if (str(number).endswith("0") or 
            str(number).endswith("2") or 
            str(number).endswith("4") or 
            str(number).endswith("6") or 
            str(number).endswith("8")):
            return OddEven.Even
        
        if OddEven.__is_prime(number):
            return number

        return OddEven.Odd

    def __is_prime(n):
        if n == 2 or n == 3: return True
        if n < 2 or n%2 == 0: return False
        if n < 9: return True
        if n%3 == 0: return False
  
        r = int(n**0.5)
        f = 5
        while f <= r:
            if n%f == 0: return False
            if n%(f+2) == 0: return False
            f +=6
        return True 
