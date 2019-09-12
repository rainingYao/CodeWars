# <4 kyu> Snail
# https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/python

import codewars_test as test

def snail(snail_map):
    s = []
    while snail_map != []:
        # top
        s.extend(snail_map.pop(0))
        if snail_map == []:
            return s
        # right
        for x in snail_map:
            s.append(x.pop())
        # bottom
        r = snail_map.pop()
        r.reverse()
        s.extend(r)
        if snail_map == []:
            return s
        # left
        l = []
        for x in snail_map:
            l.append(x.pop(0))
        l.reverse()
        s.extend(l)
    return s

array = [[1,2,3],
         [4,5,6],
         [7,8,9]]
expected = [1,2,3,6,9,8,7,4,5]
test.assert_equals(snail(array), expected)
