import unittest
import stringcalculator

class Test_stringcalculator(unittest.TestCase):
    def test_stringcalculator(self):
        testcases = {}
        testcases[""] = 0
        testcases[" "] = 0
        testcases[","] = 0
        testcases["dgdgdg"] = 0
        testcases["1,2"] = 3
        testcases["12"] = 12
        testcases["1gggd,2"] = 2
        testcases["asdad1,fgdgf,8"] = 8
        testcases["1,2,3"] = 6
        testcases["1,2,3,4,5,6,7,8,9"] = 45

        for key, value in testcases.items():
            result = stringcalculator.stringcalculator.add(key, ",")
            self.assertEqual(value, result)

if __name__ == '__main__':
    unittest.main()
