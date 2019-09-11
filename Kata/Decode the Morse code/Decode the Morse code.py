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
    '.----': '1',
    '..---': '2',
    '...--': '3',
    '....-': '4',
    '.....': '5',
    '-....': '6',
    '--...': '7',
    '---..': '8',
    '----.': '9',
    '-----': '0',
    '!': ' '
}


def decodeMorse(morse_code):
    morse_code = morse_code.strip()
    ans = ''
    while len(morse_code) > 0:
        if morse_code[0:2] == '  ':
            morse_code = morse_code[2:]
            ans = ans + ' '
        elif morse_code[0] == ' ':
            morse_code = morse_code[1:]
        else:
            right = morse_code.find(' ')
            if right == -1:
                sp = morse_code
                morse_code = ''
            else:
                sp = morse_code[0:right]
                morse_code = morse_code[right:]
            ans = ans + MORSE_CODE[sp]
    return ans


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
