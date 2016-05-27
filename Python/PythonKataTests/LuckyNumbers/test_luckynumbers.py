import unittest
import luckynumbers

class Test_Luckynumbers(unittest.TestCase):
    def test_luckynumbers(self):
        testcases = {}
        testcases[-1] = ""
        testcases[0] = ""
        testcases[1] = "1"
        testcases[10] = "1,3,7,9"
        testcases[30] = "1,3,7,9,13,15,21,25"
        testcases[100] = "1,3,7,9,13,15,21,25,31,33,37,43,49,51,63,67,69,73,75,79,87,93,99"

        for range, expected in testcases.items():
            actual = luckynumbers.LuckyNumbers.get_lucky_numbers(range)
            self.assertEqual(expected, actual, "expected " + str(expected) + " but was " + str(actual))

    def test_luckynumbers_prime(self):
        testcases = {}
        testcases[-1] = ""
        testcases[0] = ""
        testcases[1] = ""
        testcases[10] = "3,7"
        testcases[30] = "3,7,13"
        testcases[100] = "3,7,13,31,37,43,67,73,79"

        for range, expected in testcases.items():
            actual = luckynumbers.LuckyNumbers.get_lucky_prime_numbers(range)
            self.assertEqual(expected, actual, "expected " + str(expected) + " but was " + str(actual))

if __name__ == '__main__':
    unittest.main()
