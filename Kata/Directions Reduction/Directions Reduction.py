# Directions Reduction
# https://www.codewars.com/kata/550f22f4d758534c1100025a/train/python

import codewars_test as test

def dirReduc(arr):
    l = ["EAST", "NORTH", "SOUTH", "WEST"]
    for w in arr:
        l.append(w)
        if len(l) > 5 and l.index(l[-1]) ^ l.index(l[-2]) == 3:
            l = l[0:-2]
    return l[4:]


a = ["NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"]
test.assert_equals(dirReduc(a), ['WEST'])
u = ["NORTH", "WEST", "SOUTH", "EAST"]
test.assert_equals(dirReduc(u), ["NORTH", "WEST", "SOUTH", "EAST"])