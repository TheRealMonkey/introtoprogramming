namespace hangman
{
    class hangMan
    {
        static void clearScreen()
        {
            //this will clear the terminal to make the program look tidier
            Console.Clear();
        }
        private static string[] retrieveWordList(int difficulty)
        {
            //a file will be read depending on difficulty
            //NOTE: this will be relative to where the file is wran from.
            //for example if the executable is ran from C:\Users\maris\Documents\
            //the text files will have to be in the same directory
            switch (difficulty)
            {
                case 1:
                    return
                    File.ReadAllLines(("./easy.txt"));
                case 2:
                    return File.ReadAllLines(("./medium.txt"));
                case 3:
                    return File.ReadAllLines(("./hard.txt"));
                default:
                    //we know that this will not exacute since the input has already been validated but
                    //c# insists we have a defualt incase the cases above dont mach which has to return a
                    //string array  
                    return new string[] { };
            }
        }
        static void showStage(int stageNum)
        {
            //an array of stages of the hangman
            string[] stages ={@"
  +---+
  |   |
      |
      |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
@"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="};
            //wites the stage requested as the param stageNum when method is called
            clearScreen();
            Console.WriteLine(stages[stageNum]);
        }
        static private void showMenu()
        {
            //the menu which the user will pick from
            clearScreen();
            Console.WriteLine(@"Please choose one of the following:
1. Start a game of hangman
2. View wins/losses
3. Quit
");
        }
        static private int chooseMenuItem()
        {
            //string text assigned which will be changed while user has entered invalid input
            string text = "";
            string userInput;
            //intiger that will store the parsed input 
            int userChoiceAsInt;
            do
            {
                clearScreen();
                Console.WriteLine(text);
                //the text variable is only changed aftr it is written which will mean that on the first ittiration,
                //text will be an empty string so the error message will not be shown whereas it will be shown,
                //on the next ittirations
                text = "Invalid input. Please try again.";
                //fucntion which will write the menu to the screen
                showMenu();
                //user input will be set to the users entered input
                userInput = Console.ReadLine();
                //not is used to invert the wanted outcome
                //we want the following conditions to be met before leaving the loop:
                //1. userinput can be pares as an intiger meaning that the input is an intigers
                //this is done by the tryparse method to return true/false depending on if the input can be parsed
                //2. the number is between 1 and 4
            } while (!(int.TryParse(userInput, out userChoiceAsInt) && userChoiceAsInt > 0 && userChoiceAsInt < 4));
            //after we know that the initger has met all of the conddtions
            //we return the initger
            return userChoiceAsInt;
        }
        static int chooseDifficulty()
        {

            //this method is similar to the chooseMenuItems but the ranges are different.
            //in the future, i could possibly create a method that takes in
            //the the question it would like to ask and the ranges that the int as to be between
            string text = "";
            string userInput;
            int userChoiceAsInt;
            do
            {
                clearScreen();
                Console.WriteLine(text);
                text = "Invalid input. Please try again.";
                Console.WriteLine(@"Please select a difficulty:
1.Easy
2.Medium
3.Hard");
                userInput = Console.ReadLine();
                //not is used to invert the wanted outcome
            } while (!(int.TryParse(userInput, out userChoiceAsInt) && userChoiceAsInt > 0 && userChoiceAsInt < 4));
            return userChoiceAsInt;
        }
        static private string chooseWord()
        {
            int difficulty = chooseDifficulty();
            string[] wordlist = retrieveWordList(difficulty);
            //initiate random object
            Random random = new Random();
            //gets and returns a random string from the wordlist
            return wordlist[random.Next(wordlist.Length)];
        }
        static private string getValidCharacter()
        {
            string text = "";
            string userInput;
            //a boolean that will be set depending if the character enterd is in the
            //string array bellow
            bool validCharacter;
            //an array of string that contain all valid characters that can be used in hangman
            //i could have used a char array bit if i had, i would have had to convert the value im trying to convert from
            //a string to a character so making the array a string array simplified the code
            string[] validCharacters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            do
            {

                Console.WriteLine(text);
                Console.WriteLine("Please enter a character: ");
                //this will only show if the do loop is re ran only if the character is not
                //valid(in the validCharacters string array)
                text = "Invalid Charater. Please try again: ";
                userInput = Console.ReadLine().ToLower();
                validCharacter = false;
                //for every character in the valid character array, it will compare the userinput to
                //the character nd if it matches, the valid character will be set to true otherwise
                //the valid character will remain false meaning the do while loop will run again
                for (int i = 0; i < validCharacters.Length; i++)
                {
                    if (validCharacters[i] == userInput)
                    {
                        validCharacter = true;
                    }
                }
            } while (!(validCharacter));
            return userInput;
        }
        static private void startGame()
        {
            string word = chooseWord();
            char[] wordAsAray = word.ToCharArray();
            //Console.WriteLine(word);
            string[] unsolvedWord = new string[word.Length];
            for (int i = 0; i < unsolvedWord.Length; i++)
            {
                unsolvedWord[i] = "_";
            }

            int stage = 0;
            List<string> attemptedLetters = new List<string> { };
            string guessedLetter, text;
            bool letterNotAlreadyGuessed;
            bool gameWon = false;
            do
            {

                letterNotAlreadyGuessed = true;
                guessedLetter = getValidCharacter();
                clearScreen();



                for (int i = 0; i < attemptedLetters.Count; i++)
                {
                    if (attemptedLetters[i] == guessedLetter)
                    {
                        letterNotAlreadyGuessed = false;

                    }
                }
                if (letterNotAlreadyGuessed)
                {

                    attemptedLetters.Add(guessedLetter);


                    bool letterInWord = false;
                    for (int i = 0; i < wordAsAray.Length; i++)
                    {

                        if (wordAsAray[i] == char.Parse(guessedLetter))
                        {
                            unsolvedWord[i] = guessedLetter;
                            letterInWord = true;

                        }

                    }

                    if (letterInWord)
                    {


                        text = "Your letter was in the word!";


                    }
                    else
                    {

                        text = "Your letter was NOT in the word!";
                        stage++;

                    }
                    showStage(stage);
                    Console.WriteLine(String.Join("", unsolvedWord));
                    Console.WriteLine("Letters Guessed:");
                    Console.WriteLine(String.Join(", ", attemptedLetters));
                    Console.WriteLine(text);
                    //Console.WriteLine(word);
                }
                else
                {

                    Console.WriteLine("Letter already attempted. Please enter another letter");
                }
                if (!unsolvedWord.Contains("_"))
                {
                    gameWon = true;
                }
            } while (!(stage == 6 || gameWon));
            clearScreen();
            showStage(stage);
            if (gameWon)
            {
                Console.WriteLine("You got the correct word!");
                System.IO.File.AppendAllLines("./scores.txt", new string[] { "Won" });
            }
            else
            {
                Console.WriteLine("You Could not solve the word.");
                Console.WriteLine("The Word was: " + word);
                System.IO.File.AppendAllLines("./scores.txt", new string[] { "Lost" });
            }
            Console.WriteLine("press any key to go back to the menu.");
            Console.ReadKey();
        }
        static void showScores()
        {
            string[] scores = File.ReadAllLines("./scores.txt");


            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine(((i + 1) + ". " + scores[i]));
            }
            int timesLost = scores.Count(stringToMatch => stringToMatch == "Lost");
            int timesWon = scores.Count(stringToMatch => stringToMatch == "Won");
            //print the list of wins and lists aswell as the line number
            //i could have used a foreach but it wiould have not been able
            //to give my the index of the line which i want to use
            //to get the line number


            Console.WriteLine("You have lost " + timesLost + "time(s)");
            Console.WriteLine("You have won " + timesWon + "time(s)");
            Console.WriteLine("Enter any key to go back to the menu");
            Console.ReadKey();
        }
        static void proccessInput(int userInput)
        {
            //The only input can only be between 1-3 as it has already been validated therefore
            // no need for a default case
            switch (userInput)
            {
                case 1:
                    startGame();
                    return;
                case 2:
                    showScores();
                    return;
                case 3:
                    Console.WriteLine("GoodBye!");
                    System.Environment.Exit(0);
                    return;
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int userInput = chooseMenuItem();
                proccessInput(userInput);
            }
        }
    }
}