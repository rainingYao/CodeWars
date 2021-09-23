import re

def cal_atomexp(atom_exp):
    # 计算乘除法
    if '*' in atom_exp:
        a, b = atom_exp.split('*')
        atom_res = float(a) * float(b)
    elif '/' in atom_exp:
        a, b = atom_exp.split('/')
        atom_res = float(a) / float(b)
    return str(atom_res)

def cal_muldiv(inner_bracket):
    while True:  # 计算括号里的所有乘除法
        # 匹配第一个乘除法  inner_bracket = (9-2*5/3+7/3*99/4*2998+10*568/14)
        ret = re.search('\d+(\.\d+)?[*/]-?\d+(\.\d+)?', inner_bracket)
        if not ret: break
        atom_exp = ret.group()  # 获取乘除法表达式  # 2*5
        atom_res = cal_atomexp(atom_exp)  # 计算乘除法的函数，得到结果  10.0
        inner_bracket = inner_bracket.replace(atom_exp, str(atom_res))
        # inner_bracket = (9-10.0/3+7/3*99/4*2998+10*568/14)
        # 将得到的结果与匹配到的表达式进行兑换
    return inner_bracket  # 返回的是一个纯加减法组成的算式

def cal_addsub(inner_bracket):
    # 计算括号中的所有加减法
    # (9 - 3.3333333333333335 + 173134.50000000003 + 405.7142857142857)
    ret_l = re.findall('[-+]?\d+(?:\.\d+)?', inner_bracket)
    sum = 0
    for i in ret_l:
        sum += float(i)
    return str(sum)

def format_exp(exp):
    # 给表达式做格式化
    exp = exp.replace('--','+')
    exp = exp.replace('+-','-')
    exp = exp.replace('++','+')
    exp = exp.replace('-+','-')
    return exp

def main(s):
    s = s.replace(' ', '')
    while True:
        # 找最内层的小括号
        inner_bracket = re.search('\([^()]+\)', s)
        if not inner_bracket: break  # 找不到小括号了就退出
        inner_bracket = inner_bracket.group()
        inner_bracket_bak = inner_bracket
        inner_bracket = cal_muldiv(inner_bracket)  # 括号内的 : 计算了所有乘除法，只剩下加减法的表达式
        inner_bracket = format_exp(inner_bracket)
        res = cal_addsub(inner_bracket)
        s = s.replace(inner_bracket_bak, res)
    s = cal_muldiv(s)
    s = format_exp(s)
    s = cal_addsub(s)
    return s

s = '1-2*((60-30 +(9-2*5/3+7/3*99/4*2998+10*568/14)*(-40 / 5))-(-4*3)/(16-3*2))'
s = '3333 - 0.0000002 * ( (6-30 +(-222/5) * (9-2*5/3 + 7 /3*99/4*2222298 +10 * 1 )) - (-4*3)/ (5-3*2) )'
print(main(s))
print(eval(s))