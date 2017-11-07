import unittest
import stringcalculator

class test_stringcalculator(unittest.TestCase):
    def test_stringcalculator_valid_values(self):
        testcases = {"1,2":3, "12":12, "1,2,3":6, "1,2,3,4,5,6,7,8,9":45}

        for key, value in testcases.items():
            result = stringcalculator.stringcalculator.add(key, ",")
            self.assertEqual(value, result)

    def test_stringcalculator_empty_values(self):
        testcases = {"":0, " ":0, ",":0}

        for key, value in testcases.items():
            result = stringcalculator.stringcalculator.add(key, ",")
            self.assertEqual(value, result)

    def test_stringcalculator_invalid_values(self):
        testcases = {"dgdgdg":0, "1gggd,2":2, "asdad1,fgdgf,8":8}

        for key, value in testcases.items():
            result = stringcalculator.stringcalculator.add(key, ",")
            self.assertEqual(value, result)

if __name__ == '__main__':
    unittest.main()
