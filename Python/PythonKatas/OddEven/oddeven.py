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
        return ' '.join(str(OddEven.convert(x)) for x in range(start, stop))

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
        if n%2 == 0 or n < 2: return False
        for i in range(3,int(n**0.5)+1,2):
            if n%i == 0:
                return False    

        return True
