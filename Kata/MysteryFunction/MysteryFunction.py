import codewars_test as test

def mystery(n):
    return n ^ (n >> 1)

def mystery_inv(n):
    mask = n >> 1
    while mask != 0:
        n ^= mask
        mask >>= 1
    return n

def name_of_mystery():
    return "Gray code"

test.assert_equals(mystery(6), 5, "mystery(6) ")
test.assert_equals(mystery_inv(5), 6, "mystery_inv(5)")
test.assert_equals(mystery(9), 13, "mystery(9) ")
test.assert_equals(mystery_inv(13), 9, "mystery_inv(13)")
test.assert_equals(mystery(19), 26, "mystery(19) ")
test.assert_equals(mystery_inv(26), 19, "mystery_inv(26)")
