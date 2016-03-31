def FizzBuzz(value):
    result = ""
    if value <= 0:
        return result

    if value % 3 == 0:
        result += "fizz"
    if value % 5 == 0:
        result += "buzz"
    if not result:
        result += str(value)

    return result

def FizzBuzzExtended(value):
    result = ""
    if value <= 0:
        return result

    if value % 3 == 0 or "3" in str(value):
        result += "fizz"
    if value % 5 == 0 or "5" in str(value):
        result += "buzz"
    if not result:
        result += str(value)

    return result