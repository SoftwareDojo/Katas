class stringcalculator(object):
    
    def add(numbers, delimeter):
        result = 0
        if numbers == "": return result
        
        for value in str(numbers).split(delimeter):
            if not stringcalculator.__check_int(value): continue
            result += int(value)

        return result 

    def __check_int(s):
        if s == "": 
            return False
        if s[0] in ('-', '+'):
    	    return s[1:].isdigit()
        return s.isdigit()



