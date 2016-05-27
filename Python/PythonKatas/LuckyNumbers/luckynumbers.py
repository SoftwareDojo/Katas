class LuckyNumbers(object):
    
    def get_lucky_numbers(range):
        numbers = LuckyNumbers.__find_lucky_numbers(range+1)
        return ','.join(str(n) for n in numbers)

    def get_lucky_prime_numbers(range):
        numbers = LuckyNumbers.__find_lucky_numbers(range+1)
        return ','.join(str(n) for n in numbers if LuckyNumbers.__is_prime(n) == True)

    def __find_lucky_numbers(max):
        numbers = list(range(1, max))
        count = 2
        while count != 0 & count <= len(numbers):
            count = LuckyNumbers.__remove_numbers(numbers, count)

        return numbers

    def __remove_numbers(numbers, count):
        toRemove = list()
        index = count -1
        
        while index < len(numbers):
            toRemove.append(numbers[index])
            index = index + count

        for number in toRemove:
            numbers.remove(number)

        return next( (x for x in numbers if x > count), 0)

    def __is_prime(n):
        if n == 2 or n == 3: return True
        if n%2 == 0 or n < 2: return False
        for i in range(3,int(n**0.5)+1,2):
            if n%i == 0:
                return False    

        return True