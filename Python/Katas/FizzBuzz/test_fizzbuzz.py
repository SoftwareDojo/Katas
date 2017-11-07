import unittest
import fizzbuzz

class Test_test_fizzbuzz(unittest.TestCase):
    def test_fizzbuzz(self):
        testcases = {0:"",1:"1",2:"2",3:"fizz",4:"4",5:"buzz",6:"fizz",10:"buzz",15:"fizzbuzz"}

        for key, value in testcases.items():
            result = fizzbuzz.FizzBuzz(key)
            self.assertEqual(value, result)
  
    def test_fizzbuzz_extended(self):
        testcases = {0:"",1:"1",2:"2",3:"fizz",4:"4",5:"buzz",6:"fizz",10:"buzz",13:"fizz",15:"fizzbuzz",25:"buzz",35:"fizzbuzz",52:"buzz",53:"fizzbuzz"}
        
        for key, value in testcases.items():
            result = fizzbuzz.FizzBuzzExtended(key)
            self.assertEqual(value, result)

if __name__ == '__main__':
    unittest.main()
