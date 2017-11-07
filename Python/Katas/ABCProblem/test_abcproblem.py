import unittest
import abcproblem

class Test_test_abcproblem(unittest.TestCase):
    def test_check_word(self):
        testcases = { "": True, "ABC": True, "baRk": True, "booK": False, "treat": True, "COMMON": False, "squad": True, "Confused": True}

        abc = abcproblem.ABCProblem()

        for word, expected in testcases.items():
            actual = abc.check_word(word)
            self.assertEqual(expected, actual, "expected that " + word + " is "+ str(expected) + " but was " + str(actual))

if __name__ == '__main__':
    unittest.main()
