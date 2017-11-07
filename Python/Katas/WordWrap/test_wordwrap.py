import unittest
import wordwrap

class test_wordwrap(unittest.TestCase):
    def test_wrap_simple_start(self):
        result = wordwrap.wordwrap.wrap("zeile1 zeile2", 0)
        self.assertEqual("zeile1\nzeile2", result)

    def test_wrap_simple_center(self):
        result = wordwrap.wordwrap.wrap("zeile1 zeile2", 7)
        self.assertEqual("zeile1\nzeile2", result)

    def test_wrap_simple_end(self):
        result = wordwrap.wordwrap.wrap("zeile1 zeile2", 13)
        self.assertEqual("zeile1 zeile2", result)

    def test_wrap_complex_center(self):
        result = wordwrap.wordwrap.wrap("Let's Go outside.", 8)
        self.assertEqual("Let's Go\noutside.", result)

if __name__ == '__main__':
    unittest.main()
