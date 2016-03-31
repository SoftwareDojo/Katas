import unittest
import oddeven

class Test_oddeven(unittest.TestCase):
    def test_oddeven(self):

        testcases = {}
        testcases[1] = "Odd"
        testcases[2] = "Even"
        testcases[3] = 3
        testcases[4] = "Even"
        testcases[5] = 5
        testcases[6] = "Even"
        testcases[7] = 7
        testcases[8] = "Even"
        testcases[9] = "Odd"
        testcases[10] ="Even"

        oddEven = oddeven.OddEven

        for key, value in testcases.items():

            result = oddEven.convert(key)
            self.assertEqual(value, result)

    def test_oddeven_range(self):

        oddEven = oddeven.OddEven
        actual = oddEven.convert_range(1,11)
        self.assertEqual(actual, "Odd Even 3 Even 5 Even 7 Even Odd Even")

    def test_oddeven_with_string(self):

        testcases = {}
        testcases[1] = "Odd"
        testcases[2] = "Even"
        testcases[3] = 3
        testcases[4] = "Even"
        testcases[5] = 5
        testcases[6] = "Even"
        testcases[7] = 7
        testcases[8] = "Even"
        testcases[9] = "Odd"
        testcases[10] ="Even"

        oddEven = oddeven.OddEven

        for key, value in testcases.items():

            result = oddEven.convert_with_string(key)
            self.assertEqual(value, result)

if __name__ == '__main__':
    unittest.main()
