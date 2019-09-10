# <6 kyu> Take a Number And Sum Its Digits Raised To The Consecutive Powers And ....¡Eureka!!
# https://www.codewars.com/kata/5626b561280a42ecc50000d1

import codewars_test as test

def sum_dig_pow(a, b): # range(a, b + 1) will be studied by the function
    l = []
    for n in range(a, b + 1):
        s = 0
        i = 1
        for x in str(n):
            s += int(x)**i
            i += 1
        if s == n:
            l.append(n)
    return l

test.describe("Example Tests")
test.assert_equals( sum_dig_pow(1, 10), [1, 2, 3, 4, 5, 6, 7, 8, 9])
test.assert_equals(sum_dig_pow(1, 100), [1, 2, 3, 4, 5, 6, 7, 8, 9, 89])
test.assert_equals(sum_dig_pow(10, 89),  [89])
test.assert_equals(sum_dig_pow(10, 100),  [89])
test.assert_equals(sum_dig_pow(90, 100), [])
test.assert_equals(sum_dig_pow(89, 135), [89, 135])
