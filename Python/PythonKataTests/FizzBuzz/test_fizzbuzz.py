import unittest
import fizzbuzz

class Test_FizzBuzzTests(unittest.TestCase):
    def test_fizzbuzz(self):
        testcases = {}
        testcases[0] = ""
        testcases[1] = "1"
        testcases[2] = "2"
        testcases[3] = "fizz"
        testcases[4] = "4"
        testcases[5] = "buzz"
        testcases[6] = "fizz"
        testcases[10] = "buzz"
        testcases[15] = "fizzbuzz"

        for key, value in testcases.items():
            result = fizzbuzz.FizzBuzz(key)
            self.assertEqual(value, result)
  
    def test_fizzbuzz_extended(self):
        testcases = {}
        testcases[0] = ""
        testcases[1] = "1"
        testcases[2] = "2"
        testcases[3] = "fizz"
        testcases[4] = "4"
        testcases[5] = "buzz"
        testcases[6] = "fizz"
        testcases[10] = "buzz"
        testcases[13] = "fizz"
        testcases[15] = "fizzbuzz"
        testcases[25] = "buzz"
        testcases[35] = "fizzbuzz"
        testcases[52] = "buzz"
        testcases[53] = "fizzbuzz"
        
        for key, value in testcases.items():
            result = fizzbuzz.FizzBuzzExtended(key)
            self.assertEqual(value, result)

if __name__ == '__main__':
    unittest.main()