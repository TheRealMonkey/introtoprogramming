

letters = [' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
           'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']
morse = [" ", ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..",
         "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."]


word = "HEY"


def Encode(word):

    finalWord = ""
    for i in range(len(word)):
        for k in range(len(letters)):

            if (word[i] == letters[k]):
                finalWord += morse[k] + " "

    return finalWord


print(Encode("WORD"))


def Decode(morseCode):
    word = morseCode.split(" ")
    finalWord = ""
    for i in range(len(word)):
        for k in range(len(morse)):
            if (word[i] == morse[k]):
                finalWord += letters[k]

    return finalWord


print(Decode("-... .- .-.. .-.. ..."))
