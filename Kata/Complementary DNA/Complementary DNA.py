# <7 kyu> Complementary DNA
# https://www.codewars.com/kata/554e4a2f232cdd87d9000038

import codewars_test as Test

d = {'A': 'T', 'T': 'A', 'G': 'C', 'C': 'G'}

def DNA_strand(dna):
    return ''.join(d[c] for c in dna)

Test.assert_equals(DNA_strand("AAAA"),"TTTT","String AAAA is")
Test.assert_equals(DNA_strand("ATTGC"),"TAACG","String ATTGC is")
Test.assert_equals(DNA_strand("GTAT"),"CATA","String GTAT is")
