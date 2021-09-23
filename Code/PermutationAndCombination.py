import itertools as it

print("permutations")
for p in it.permutations("abc"):
    print(p)
print("combinations")
for i in range(1, 4):
    print(i)
    for c in it.combinations("abc", i):
        print(c)
print("combinations_with_replacement")
for c in it.combinations_with_replacement("xyz", 2):
    print(c)
n = 3
for i in range(1, n+1):
    l = [n-i+1]
    for j in range(1, i):
        l.append(1)
    print(l)
