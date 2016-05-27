import unittest
import abcproblem

class Test_abcproblem(unittest.TestCase):
    def test_check_word(self):
        testcases = {}
        testcases[""] = True
        testcases["ABC"] = True
        testcases["baRk"] = True
        testcases["booK"] = False
        testcases["treat"] = True
        testcases["COMMON"] = False
        testcases["squad"] = True
        testcases["Confused"] = True

        abc = abcproblem.ABCProblem()

        for word, expected in testcases.items():
            actual = abc.check_word(word)
            self.assertEqual(expected, actual, "expected that " + word + " is "+ str(expected) + " but was " + str(actual))

if __name__ == '__main__':
    unittest.main()
