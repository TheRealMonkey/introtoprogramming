
namespace morse
{
    class Program
    {
        static void showError(string error)
        //handled error messages will be displayed through this writeline method
        {
            Console.WriteLine(error);
        }
        static void showMenu()
        //displays menu to user
        {
            Console.WriteLine(@"
Please Choose one of the following options:
1. Decode morse code from file
2. Decode morse from user input
3. Encode morse code from file
4. Encode morse code from user input
5. Exit Program");
        }
        private static int returnChosenMenu()
        {
            string userinput, userMessage = "";
            int userInputAsInt = 1;
            //tryParse will return a true/false depending if the input was able to be converted to an int
            //which will then set userInputAsInt as the pasred string
            //the while loop will also check that the user input is bwtween the valid rang(1,5)
            do
            {
                showError(userMessage);
                userMessage = "Your input is invalid, please try again: ";
                userinput = Console.ReadLine();
            } while (!int.TryParse(userinput, out userInputAsInt) || userInputAsInt < 1 || userInputAsInt > 5);
            return userInputAsInt;
        }
        private static string encode(string[] morse, char[] letters, string text)
        {
            string output = "";
            bool validLetter = false;
            //the first for loop will loop through the length of the entered text
            //the second for loop will go through the length of the array of letters
            //in the second for loop, the text index of the first loop will be compared to the letters index of
            //the second for loop and if they are equal, then we know that that letter is valid and the morse
            //equvillent will be the index of the second loop
            //if the if statment is true, then the code will break out of the second for loop which will then
            //move onto the next letter of the text
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < letters.Length; j++)
                {
                    if (letters[j] == text[i])
                    {
                        output += morse[j] + " ";
                        validLetter = true;
                        break;
                    }
                    else
                    {
                        validLetter = false;
                    }
                }
                if (!validLetter)
                //if a letter is not found in the letters array, then an error will be shown that
                //the letter is invalid
                {
                    showError("The letter(" + text[i] + ")is invalid.");
                    break;
                }
            }
            return output;
        }
        private static void encodeFromInput(string[] morse, char[] letters)
        {
            //user will be asked for input that they would like to have encoded to morse code
            Console.WriteLine("Plese enter your text you want to encode(Caps[A-Z] & spaces only!): ");
            string userText = Console.ReadLine();
            //the input will be then given to the encode function as an argument aswell as the morse and letters 
            //arrays that will be used in the encode function
            Console.WriteLine(decode(morse, letters, userText));
        }
        private static string decode(string[] morse, char[] letters, string morseInput)
        {
            //this fucntion is similar to the encode function except for instead of using
            //a string of text, a line of morse code is used that is then split
            //at every space and then an array of morse code characters is compared
            //to the array of morse characters
            string[] morseSplitInput = morseInput.Split(" ");
            string output = "";
            bool validMorse = false;
            for (int i = 0; i < morseSplitInput.Length; i++)
            {
                for (int j = 0; j < morse.Length; j++)
                {
                    if (morseSplitInput[i] == morse[j])
                    {
                        output += letters[j];
                        validMorse = true;
                        break;
                    }
                    else
                    {
                        validMorse = false;
                    }
                }
                if (!validMorse)
                { //if a morse code character is not found in the morseCode array, then an error will be shown that
                  //the morse code character is invalid
                    showError("The morse code of(" + morseSplitInput[i] + ")is invalid.");
                    break;
                }
            }
            return output;
        }
        private static void encodeFromFile(string[] morse, char[] letters)
        {
            Console.WriteLine(@"
Please enter the file you would like to encode
(This will be relative to where the command is ran from): ");
            string fileLocation = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(fileLocation);
            foreach (var line in lines)
            {
                Console.WriteLine(encode(morse, letters, line));
            }
        }
        private static void decodeFromInput(string[] morse, char[] letters)
        {
            //user will be asked for input that they would like to have decoded from morse code
            Console.WriteLine("Plese enter your Morse code(each character separated by a space): ");
            string userText = Console.ReadLine();
            Console.WriteLine(decode(morse, letters, userText));
        }
        private static void decodeFromFile(string[] morse, char[] letters)
        {
            Console.WriteLine(@"
Please enter the file you would like to decode
(This will be relative to where the command is ran from): ");
            string fileLocation = Console.ReadLine();
            string[] lines = System.IO.File.ReadAllLines(fileLocation);
            foreach (var line in lines)
            {
                Console.WriteLine(decode(morse, letters, line));
            }
        }
        private static void chooseTask(int userInput)
        {   //assigning arrays of letters with corresponding morse code which will be used for the decoding/encoding
            char[] letters = new char[] { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string[] morseCode = new string[] { " ", ".-", "-...", "-.-.", "-..", ".", "..-.",
"--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.",
"...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            //using the valid input provided by returnChosenMenu, we will use a switch cae to run the task corresponding to the menu
            switch (userInput)
            {
                case 1:
                    decodeFromFile(morseCode, letters);
                    break;
                case 2:
                    decodeFromInput(morseCode, letters);
                    break;
                case 3:
                    encodeFromFile(morseCode, letters);
                    break;
                case 4:
                    encodeFromInput(morseCode, letters);
                    break;
            }
        }
        //main function that will run when program runs
        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                showMenu();
                int userChoice = returnChosenMenu();
                if (userChoice == 5)
                {
                    break;
                }
                chooseTask(userChoice);
            }
            Console.WriteLine("Goodbye!");
        }
    }
}
