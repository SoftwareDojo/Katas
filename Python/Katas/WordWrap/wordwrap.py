class wordwrap(object):
    
    def wrap(text, length):
        result = ""
        currentLength = 0

        for value in str(text).split(" "):
            if currentLength > 0:
                result += wordwrap.__newline_or_whitespace(currentLength, len(value), length)
            currentLength += len(value)
            result += value

        return result

    def __newline_or_whitespace(currentLength, wordLength, maxLength):
        if currentLength + wordLength < maxLength:
            currentLength += 1
            return " "
        
        currentLength = 0
        return "\n"


