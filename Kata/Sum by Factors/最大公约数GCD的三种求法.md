# 最大公约数GCD的三种求法
> 转载自 [简书]：<https://www.jianshu.com/p/25d0ca88a4a1>

最大公约数(GCD, Greatest Common Divisor，为简便下文都使用GCD表示最大公约数)：指某几个整数共有约数中最大的一个。
由于多个数的GCD可以拆分成两个数的GCD，所以一般来说常见的是求两个数的GCD。废话不多说，来看看目前我已知的求GCD的方法。

+ 穷举法
+ 辗转相除法
+ 辗转相减法

下面来一个一个看。约定待求GCD的数为a, b。
1. 穷举法
这是最容易想到，而且是最直接的方法。简言之，就是从1开始，到a,b中比较小的那个结束，看能不能同时被a, b整除（如果能即为公约数），这样一个循环下来一定可以找出GCD。
代码如下：
```
    // 穷举法
    public static int gcd_enumeration(int a, int b){
        // 先找出a,b中小的那个
        int smaller = a;
        if (b < a) {
            smaller = b;
        }

        int gcd = 1;
        for (int i = 2; i <= smaller; i++) {
            // 如果能同时被a和b除尽，则更新GCD
            if ((a % i == 0) && (b % i == 0)) {
                gcd = i;
            }
        }
        return gcd;
    }
```

2. 辗转相除法
辗转相除法又称为欧几里得算法，大概公元前300年欧几里得老大爷就想出来这么个算法了，厉害了！
该方法依托于一个定理：
`gcd(a, b) = gcd(b, a mod b)`

其中，a mod b是a除以b所得的余数。
啥意思呢，就是说a,b的最大公约数就是b,a mod b的最大公约数。
证明如下：

> (1)充分性：
> 设g是a,b的公约数，则a,b可由g来表示：
> a = xg, b = yg (x,y为整数)
> 又，a可由b表示（任意一个数都可以由另一个数来表示）：
> a = kb + r (k为整数，r为a除以b所得余数)
> => r = a - kb = xg - kyg = (x - ky)g
> 即，g也是r的约数。
> 这样，g就是(b, r)即(b, a mod b)的公约数。
> 
> 
> (2)必要性：
> 设g是(b, a mod b)的公约数，类似于(1)，同样可以推出g也是(a, b)的公约数。
> 
> 
> 综合(1)(2)可得(a, b)和(b, a mod b)的公约数是一样的，当然最大公约数也是一样的。

好了，有了理论基础，下面总结成算法步骤：

a % b得余数r
若r == 0，则b即为GCD
若r != 0，则a = b, b = r，返回步骤1

代码如下
```
    // 辗转相除法（递归写法）
    public static int gcd_division_recursive(int a, int b){
        if (b == 0) {
            return a;
        }
        return gcd_division_recursive(b, a % b);
    }

    // 辗转相除法（迭代写法）
    public static int gcd_division_iteration(int a, int b){
        while(b != 0){// 为什么用b判断呢？因为b就是用来存a%b的，即上面算法步骤里的r的
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
```

3. 辗转相减法
这个方法出处目前我也不知道，而且证明过程我也不知道，先写在这里，过后待我研究研究。
算法步骤：

若a > b，则a = a - b
若b > a，则b = b - a
若a == b，则a(或b)即为最大公约数
若a != b，则回到1

既然没有证明，那就举个栗子瞧瞧看吧。
求32,12的最大公约数：
```
32 - 12 = 20 (20 > 12)
20 - 12 = 8 (8 < 12)
12 - 8 = 4 (4 < 8)
8 - 4 = 4 (4 == 4)
```
所以最大公约数是4.

代码如下：
```
    // 辗转相减法（递归写法）
    public static int gcd_substract_recursive(int a, int b){
        if(a == b)
            return a;
        return a > b ? gcd_substract_recursive(a - b, b) : gcd_substract_recursive(a, b - a);
    }

    // 辗转相减法（迭代写法）
    public static int gcd_substract_iteration(int a, int b){
        // 如果a,b不相等，则用大的数减去小的数，直到相等为止
        while(a != b){
            if(a > b)
                a = a - b;
            else
                b = b - a;
        }
        return a;
    }
```

以上，我们知道了怎么求两个数的最大公约数，那最小公倍数呢？
其实，只要知道了a,b的最大公约数，那最小公倍数不就是a * b / gcd(a, b)吗？
[完整代码](https://github.com/adty1992/DataStructures-Algorithms/blob/master/GCD.java)

作者：JxYoung
链接：https://www.jianshu.com/p/25d0ca88a4a1
來源：简书
简书著作权归作者所有，任何形式的转载都请联系作者获得授权并注明出处。

[简书]: https://www.jianshu.com "简书"
