# 矩阵旋转180
a = [
    [1, 1, 1, 3],
    [1, 1, 1, 0],
    [1, 1, 0, 0],
    [1, 0, 0, 0]
]
c = [b[::-1] for b in a][::-1]
print(c)
# 矩阵对角翻转
# 矩阵旋转90
d=[[1,2],[3,4]]
def demo1(d):
    return [[j[i] for j in d] for i in range(len(d[0]))]
def demo2(d):
    return [[j[i] for j in d] for i, _ in enumerate(d[0])]
def demo3(d):
    return list(map(list,zip(*d)))
print(demo3(d))
print(demo3(d)[::-1])

for x in map(list,zip(*d)):
    print(x)

from numpy import *
import numpy as np

x = arange(3*3)
x.shape = (3,3)
rx = [
    [1,0,0],
    [0,0,-1],
    [0,1,0]
]
ry = [
    [0,0,1],
    [0,1,0],
    [-1,0,0]
]
rz = [
    [0,-1,0],
    [1,0,0],
    [0,0,1]
]
ep = np.eye(3,3)[:,::-1]
print(ep)
print(x*rx)
print(x*ry)
print(x*rz)
print(x*ep)
print(x)
y=np.rot90(x,-1)
print(y)


a = np.array([[3,3,2,1],
              [0,0,1,5],
              [3,1,2,0],
              [5,3,1,0]])
e_1 = np.identity(a.shape[0], dtype=np.int8)[:,::-1]
print(a)
print(e_1)
print(a.T)
# 方阵的行交换
print(e_1.dot(a))
# 方阵的列交换
print(a.dot(e_1))
# 方阵逆时针旋转90度
print(e_1.dot(a.T))
print(np.rot90(a))
# 方阵顺时针旋转90度
print(a.T.dot(e_1))
print(np.rot90(a,-1))
# 方阵旋转180度
print(e_1.dot(a.dot(e_1)))
print(e_1.dot(a).dot(e_1))
print(np.rot90(a, 2))
# 负对角线镜像
print(e_1.dot(a.T.dot(e_1)))
print(e_1.dot(a.T).dot(e_1))

# Python实现矩阵的旋转
a = np.array([[1,2,8],[3,4, 9]])
print(a, "# orignal")
# 获得a的行和列数
r, c = a.shape
#print n, r, c
zs = np.zeros((max(a.shape) - min(a.shape), max(a.shape)))
#print zs
# 0填充，将a变成一个方阵
a_1 = np.vstack([a, zs])
#print a_1
# 构建一个负对角线上均是1,其余为0的方阵
e_1 = np.identity(max(a.shape), dtype=np.int8)[:,::-1]
#print e_1
# 逆时针旋转90度
a_1_left90 = e_1.dot(a_1.T)
#print a_1_left9
# 切片切出rxc的矩阵a的左旋90度的结果
print(a_1_left90[:c,:r], "# anti-clockwise 90")