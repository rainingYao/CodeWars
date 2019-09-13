# Decode the Morse code
# https://www.codewars.com/kata/54b724efac3d5402db00065e/train/python

import codewars_test as test

MORSE_CODE = {
    '.-': 'A',
    '-...': 'B',
    '-.-.': 'C',
    '-..': 'D',
    '.': 'E',
    '..-.': 'F',
    '--.': 'G',
    '....': 'H',
    '..': 'I',
    '.---': 'J',
    '-.-': 'K',
    '.-..': 'L',
    '--': 'M',
    '-.': 'N',
    '---': 'O',
    '.--.': 'P',
    '--.-': 'Q',
    '.-.': 'R',
    '...': 'S',
    '-': 'T',
    '..-': 'U',
    '...-': 'V',
    '.--': 'W',
    '-..-': 'X',
    '-.--': 'Y',
    '--..': 'Z',
    '-----': '0',
    '.----': '1',
    '..---': '2',
    '...--': '3',
    '....-': '4',
    '.....': '5',
    '-....': '6',
    '--...': '7',
    '---..': '8',
    '----.': '9',
    '.-.-.-': '.',
    '--..--': ',',
    '..--..': '?',
    '.----.': "'",
    '-.-.--': '!',
    '-..-.': '/',
    '-.--.': '(',
    '-.--.-': ')',
    '.-...': '&',
    '---...': ':',
    '-.-.-.': ';',
    '-...-': '=',
    '.-.-.': '+',
    '-....-': '-',
    '..--.-': '_',
    '.-..-.': '"',
    '...-..-': '$',
    '.--.-.': '@',
    '...---...': 'SOS'
}

MORSE_CODE['~'] = ' '


def decodeMorse(morse_code):
    return ''.join(MORSE_CODE[c]
                   for c in morse_code.strip().replace('  ', ' ~').split(' '))


def test_and_print(got, expected):
    if got == expected:
        test.expect(True)
    else:
        print("<pre style='display:inline'>Got {}, expected {}</pre>".format(
            got, expected))
        test.expect(False)


test.describe("Example from description")
test_and_print(decodeMorse('.... . -.--   .--- ..- -.. .'), 'HEY JUDE')

test.describe("Your own tests")
# Add more tests here

test.describe("Basic Morse decoding")
test_and_print(decodeMorse('.-'), 'A')
test_and_print(decodeMorse('.'), 'E')
test_and_print(decodeMorse('..'), 'I')
test_and_print(decodeMorse('. .'), 'EE')
test_and_print(decodeMorse('.   .'), 'E E')
test_and_print(decodeMorse('...---...'), 'SOS')
test_and_print(decodeMorse('... --- ...'), 'SOS')
test_and_print(decodeMorse('...   ---   ...'), 'S O S')

test.describe("Extra zeros handling")
test_and_print(decodeMorse(' . '), 'E')
test_and_print(decodeMorse('   .   . '), 'E E')

test.describe("Complex tests")
test_and_print(
    decodeMorse(
        '      ...---... -.-.--   - .... .   --.- ..- .. -.-. -.-   -... .-. --- .-- -.   ..-. --- -..-   .--- ..- -- .--. ...   --- ...- . .-.   - .... .   .-.. .- --.. -.--   -.. --- --. .-.-.-  '
    ), 'SOS! THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG.')
