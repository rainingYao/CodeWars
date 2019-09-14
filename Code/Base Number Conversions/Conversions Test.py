import math
from functools import reduce
n = 10
print(math.factorial(n)) # 阶乘
print(reduce(lambda x,y:x*y,range(1,n+1))) # 阶乘

# Use TypeAssert
import sys,os
sys.path.append('.')
from Code import TypeAssert
@TypeAssert.typeassert(int)
def toBinary(n):
    return(bin(n))

print(toBinary(15))
print(toBinary(0x15))
# print(toBinary('a'))
try:
    print(toBinary('a'))
except Exception as error:
    print(error.args)
print(int(15) is bin(15))

print(bin(10)) # 转二进制
print(oct(10)) # 转八进制
print(hex(10)) # 转十六进制

import Sample

print(Sample.bin2dec('11011010'))

print(5 in range(6))

hexnum = '6f'
print(int(hexnum,16))
print(Sample.hex2dec(hexnum))

# 最高支持36进制转10进制
print(int('1234',36))
