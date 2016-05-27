class ABCProblem(object):

    def __init__(self):
        self.abcBlocks = ["bo", "xk", "dq",
                        "cp", "na", "gt",
                        "re", "tg", "qd",
                        "fs", "jw", "hu",
                        "vi", "an", "ob",
                        "er", "fs", "ly",
                        "pc", "zm"]

    def check_word(self, word):
        word = str.lower(word)
        blocks = list(self.abcBlocks)

        for char in word:
            block = ABCProblem.__get_first_block_with_char(blocks, char)
            if block == "":
                return False
            else:
                blocks.remove(block)
        return True

    def __get_first_block_with_char(blocks, char):
        for block in blocks:
            if char in block:
                return block

        return ""


