import unittest
import oddeven

class Test_test_oddeven(unittest.TestCase):

    def test_oddeven(self):
        testcases = {1:"Odd",2:"Even",3:3,4:"Even",5:5,6:"Even",7:7,8:"Even",9:"Odd",10:"Even"}

        for key, value in testcases.items():
            result = oddeven.OddEven.convert(key)
            self.assertEqual(value, result)

    def test_oddeven_range(self):

        actual = oddeven.OddEven.convert_range(1,11)
        self.assertEqual(actual, "Odd Even 3 Even 5 Even 7 Even Odd Even")

if __name__ == '__main__':
    unittest.main()
