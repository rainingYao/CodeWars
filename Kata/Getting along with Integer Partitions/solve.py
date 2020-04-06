# for x in range(1,20):
n = 11
ns = set()
ns.add(n)
l1 = [n]

# ts = set()
# ts.add(tuple(l1))


def dis(l):
    for x in l:
        if x >= 2:
            for y in range(1, x):
                l2 = l.copy()
                l2.remove(x)
                l2.append(y)
                l2.append(x-y)
                l2.sort()
                # ts.add(tuple(l2))
                q = 1
                for z in l2:
                    q *= z
                ns.add(q)
                dis(l2)


dis(l1)


ns = list(ns)
print(ns)

# ts=list(ts)
# ts.sort()
# for t in ts:
#     print(t)
len = len(ns)
print(ns[-1]-ns[0])
print(sum(ns)/len)
if len % 2 == 0:
    print(sum(ns[len//2-1:len//2+1])/2)
else:
    print(ns[len//2])
