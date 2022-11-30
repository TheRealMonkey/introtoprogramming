
import random


def test():
    with open("allwords.txt", "r") as f:
        words = f.readlines()
        random.shuffle(words)
    easy = []
    med = []
    hard = []
    for i in words[0:100]:
        print(i)
        user = int(input("1.Easy|2.med|3.Hard|4.remove:\n"))
        if user == 1:
            easy.append(i)
        elif user == 2:
            med.append(i)
        elif user == 3:
            hard.append(i)
    with open("easy.txt", "w") as f:
        f.write("\n".join(easy))
    with open("med.txt", "w") as f:
        f.write("\n".join(med))
    with open("hard.txt", "w") as f:
        f.write("\n".join(hard))


with open("../hard.txt", "r") as f:
    lines = f.readlines()
    for i in lines:
        if "a" not in i and "e" not in i and "i" not in i and "o" not in i and "u" not in i:
            print(i)
