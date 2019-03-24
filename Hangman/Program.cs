using System;
using System.Linq;
using System.Threading;

namespace Hangman
{
    static class Program
    {

        // Rest of path if needed: C:\Users\User\source\repos\Hangman\Hangman\data\Scores.txt

        static public string[] scoreArray = System.IO.File.ReadAllLines(@"data\Scores.txt");

        static public float wins = float.Parse(scoreArray[0]);
        static public float losses = float.Parse(scoreArray[1]);



        static void Main(string[] args)
        {
            Console.Title = "Hangman!";
            Hangman();
        }

        static void Hangman()
        {

            string[] lifetimeScores = { wins.ToString(), losses.ToString() };

            // Start Conditions:
            int wordLength = 0;
            int lives = 7;
            char choice = '1';
            bool gameSolved = false;
            Console.Clear();
            string word = "";
            char charGuess = '0';
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int timer = 1000;
            bool customWord = false;

            #region StartPage & clear data check
            // Basic game introduction screen
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N   /|\\   |     ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                            / \\   |     ");
            Console.WriteLine("                            _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1: Choose a random word");
            Console.WriteLine("2: Choose your own word.");
            Console.WriteLine("3: Clear saved score data.");
            Console.WriteLine();
            Console.WriteLine("Choosing your own word will clear saved wins & losses.");
            string stringChoice = Console.ReadLine();

            // Figure out how to stop No entry crashing the app.

            try
            {
                choice = Char.Parse(stringChoice);
            }
            catch (global::System.Exception)
            {

                throw;
            }

            // If "1" is selected, create a randon word:

            if (choice == '1')
            {

                // Full path in case of problems: C:\Users\User\source\repos\Hangman\Hangman\data\Words.txt
                string[] words = System.IO.File.ReadAllLines(@"data\Words.txt");
                Random rnd = new Random();
                int random = rnd.Next(0, 58105);
                word = words[random];
                choice = '0';

            }

            // Else let the user enter a word:

            else if (choice == '2')
            {
                Console.WriteLine("Player 1, enter a word between 3 and 10 characters.");
                word = new string(Console.ReadLine().ToUpper());
                customWord = true;

            }
            else if (choice == '3')
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Are you sure? (Y/N) Saved score data will be deleted?");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                string eraseDataCheck = Console.ReadLine();
                eraseDataCheck = eraseDataCheck.ToUpper();

                if (eraseDataCheck.Contains("Y"))
                {
                    timer = 220;
                    Console.Write("             |");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    timer = 100;
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.Write("|");
                    Thread.Sleep(timer);
                    Console.WriteLine();
                    timer = 1000;
                    wins = 0;
                    losses = 0;
                    System.IO.File.WriteAllLines(@"data\Scores.txt", lifetimeScores);
                    Console.WriteLine("Score information deleted.");
                    Hangman();
                }
                else
                {
                    Hangman();
                }
            }
            else
            {
                Console.WriteLine("You failed to follow simple instructions... Please try again.");
                Thread.Sleep(timer);
                Hangman();
            }

            #endregion

            char[] answerArray = word.ToCharArray();
            wordLength = word.Length;

            Console.WriteLine();
            Console.WriteLine();

            char[] starArray = new char[wordLength];
            {
                for (var i = 0; i <= wordLength - 1; i++)
                {
                    starArray[i] = '*';
                };
            }


            while (lives != 0 && !gameSolved)
            {


                // Formatting for hanging man.
                #region lives 7 - 1
                if (lives >= 7)
                {
                    Console.Clear();
                    Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);

                    if (wins != 0 || losses != 0)
                    {
                        Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                    Console.WriteLine("                                        ");
                    Console.WriteLine("                             ,____      ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("            H A N G M A N         |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                            _____/|     ");
                    Console.WriteLine("                                        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("  ");
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        // Get character from array.
                        char letter = alphabet[i];
                        // Display each letter.
                        Console.Write(" {0}", letter);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (lives == 6)
                {
                    Console.Clear();
                    Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                    if (wins != 0 || losses != 0)
                    {
                        Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("                                        ");
                    Console.WriteLine("                             ,____      ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                             O    |     ");
                    Console.WriteLine("            H A N G M A N         |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                            _____/|     ");
                    Console.WriteLine("                                        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("  ");
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        // Get character from array.
                        char letter = alphabet[i];
                        // Display each letter.
                        Console.Write(" {0}", letter);
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                }
                else if (lives == 5)
                {
                    Console.Clear();
                    Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                    if (wins != 0 || losses != 0)
                    {
                        Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("                                        ");
                    Console.WriteLine("                             ,____      ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                             O    |     ");
                    Console.WriteLine("            H A N G M A N    |    |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                            _____/|     ");
                    Console.WriteLine("                                        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("  ");
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        // Get character from array.
                        char letter = alphabet[i];
                        // Display each letter.
                        Console.Write(" {0}", letter);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (lives == 4)
                {
                    Console.Clear();
                    Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                    if (wins != 0 || losses != 0)
                    {
                        Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("                                        ");
                    Console.WriteLine("                             ,____      ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                             O    |     ");
                    Console.WriteLine("            H A N G M A N   /|    |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                            _____/|     ");
                    Console.WriteLine("                                        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("  ");
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        // Get character from array.
                        char letter = alphabet[i];
                        // Display each letter.
                        Console.Write(" {0}", letter);
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                }
                else if (lives == 3)
                {
                    Console.Clear();
                    Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                    if (wins != 0 || losses != 0)
                    {
                        Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("                                        ");
                    Console.WriteLine("                             ,____      ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                             O    |     ");
                    Console.WriteLine("            H A N G M A N   /|\\   |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                            _____/|     ");
                    Console.WriteLine("                                        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("  ");
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        // Get character from array.
                        char letter = alphabet[i];
                        // Display each letter.
                        Console.Write(" {0}", letter);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (lives == 2)
                {
                    Console.Clear();
                    Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                    if (wins != 0 || losses != 0)
                    {
                        Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("                                        ");
                    Console.WriteLine("                             ,____      ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                             O    |     ");
                    Console.WriteLine("            H A N G M A N   /|\\   |     ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                                  |     ");
                    Console.WriteLine("                            _____/|     ");
                    Console.WriteLine("                                        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("  ");
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        // Get character from array.
                        char letter = alphabet[i];
                        // Display each letter.
                        Console.Write(" {0}", letter);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (lives == 1)
                {
                    Console.Clear();
                    Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                    if (wins != 0 || losses != 0)
                    {
                        Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    Console.WriteLine("                                        ");
                    Console.WriteLine("                             ,____      ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                             O    |     ");
                    Console.WriteLine("            H A N G M A N   /|\\   |     ");
                    Console.WriteLine("                             |    |     ");
                    Console.WriteLine("                            /     |     ");
                    Console.WriteLine("                            _____/|     ");
                    Console.WriteLine("                                        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("  ");
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        // Get character from array.
                        char letter = alphabet[i];
                        // Display each letter.
                        Console.Write(" {0}", letter);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                #endregion

                Console.Write("                 ");
                for (int i = 0; i < answerArray.Length; i++)
                {
                    // Get character from array.
                    char letter = starArray[i];
                    // Display each letter.
                    Console.Write(" {0}", letter);

                }

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Enter your guess");

                string guess = (Console.ReadLine()).ToUpper();
                try
                {
                    charGuess = char.Parse(guess);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("What? Plz no.");
                }



                if (alphabet.Contains(charGuess))
                {
                    for (int i = 1; i <= alphabet.Length; i++)
                    {
                        if (alphabet[i - 1] == charGuess)
                        {
                            alphabet[i - 1] = '_';
                        }


                    }
                    #region Add guess to word & Win animation
                    if (answerArray.Contains(charGuess))
                    {

                        // for each loop finding every instance of guessed letter & convert from * to letter.

                        for (int i = 1; i <= wordLength; i++)
                        {
                            if (charGuess == answerArray[i - 1])
                            {
                                starArray[i - 1] = charGuess;
                            }


                        }

                        if (!starArray.Contains('*'))
                        {
                            Thread.Sleep(timer);
                            //Console.BackgroundColor = ConsoleColor.Green;
                            //Console.ForegroundColor = ConsoleColor.Black;
                            if (!customWord)
                            {
                                wins++;
                            }

                            timer = 100;


                            lifetimeScores[0] = wins.ToString();
                            lifetimeScores[1] = losses.ToString();
                            // Rest of path again, just in case: C:\Users\User\source\repos\Hangman\Hangman\data\Scores.txt
                            System.IO.File.WriteAllLines(@"data\Scores.txt", lifetimeScores);


                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N     |                |     ");
                            Console.WriteLine("  |______________|  \\O/           |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    < >     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);

                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N !   |  \\O/           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);
                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N     |  <O>           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);
                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N !   |  \\O/           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N     |                |     ");
                            Console.WriteLine("  |______________|  \\O/           |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    < >     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);

                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N !   |  \\O/           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);
                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N     |  <O>           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);
                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N !   |  \\O/           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N     |                |     ");
                            Console.WriteLine("  |______________|  \\O/           |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    < >     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);

                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N !   |  \\O/           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);
                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N     |  <O>           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            Thread.Sleep(timer);
                            Console.Clear();
                            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                            if (wins != 0 || losses != 0)
                            {
                                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            Console.WriteLine("                                        ");
                            Console.WriteLine("   ______________            ,____      ");
                            Console.WriteLine("  |              |                |     ");
                            Console.WriteLine("  |  Y O U       |                |     ");
                            Console.WriteLine("  |    W I N !   |  \\O/           |     ");
                            Console.WriteLine("  |______________|   |            |     ");
                            Console.WriteLine("                     |            |     ");
                            Console.WriteLine("                    / \\     _____/|     ");
                            Console.WriteLine("                                        ");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("YOU WIN");
                            Console.WriteLine("The word was: {0}", word);
                            timer = 1000;

                            Console.WriteLine("Press \"Q\" to exit or any other key to start another game!");
                            string userInput = Console.ReadLine();

                            if (userInput == "q")
                            {
                                Environment.Exit(1);
                            }

                            else
                            {
                                Hangman();
                            }
                        }

                    }
                    else
                    {
                        lives--;
                    }
                }

                else
                {
                    timer = 1500;
                    Console.WriteLine("Please enter a single character which has not been entered before.");
                    Thread.Sleep(timer);
                    timer = 1000;
                }
                Thread.Sleep(timer);
            }
            #endregion

            Thread.Sleep(timer);
            //Console.BackgroundColor = ConsoleColor.DarkRed;
            //Console.ForegroundColor = ConsoleColor.Black;
            if (!customWord)
            {
                losses++;
            }
            timer = 300;

            #region Lose

            lifetimeScores[0] = wins.ToString();
            lifetimeScores[1] = losses.ToString();
            // Rest of path again, just in case: C:\Users\User\source\repos\Hangman\Hangman\data\Scores.txt
            System.IO.File.WriteAllLines(@"data\Scores.txt", lifetimeScores);
            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N   /|\\   |     ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("           G A M E          / \\   |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                char letter = starArray[i];
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(timer);
            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N  //\\    |     ");
            Console.WriteLine("                            |     |     ");
            Console.WriteLine("           G A M E         / \\    |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                char letter = starArray[i];
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(timer);
            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N    /\\\\  |     ");
            Console.WriteLine("                              |   |     ");
            Console.WriteLine("           G A M E           /|   |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                char letter = starArray[i];
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(timer);
            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N   /|\\   |     ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("           G A M E          / \\   |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                char letter = starArray[i];
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N   /|\\   |     ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("           G A M E          / \\   |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                char letter = starArray[i];
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(timer);
            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N  //\\    |     ");
            Console.WriteLine("                            |     |     ");
            Console.WriteLine("           G A M E         / \\    |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                char letter = starArray[i];
                Console.Write(" {0}", letter);
            }


            Thread.Sleep(timer);
            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N    /\\\\  |     ");
            Console.WriteLine("                              |   |     ");
            Console.WriteLine("           G A M E           /|   |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                char letter = starArray[i];
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(timer);
            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N   /|\\   |     ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("           G A M E          / \\   |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                char letter = starArray[i];
                Console.Write(" {0}", letter);
            }
            #endregion

            #region Slow type... Not used atm
            //Console.WriteLine();
            //Console.WriteLine();
            //Thread.Sleep(timer);
            //Console.Write("T");
            //Thread.Sleep(timer);
            //Console.Write("h");
            //Thread.Sleep(timer);
            //Console.Write("e");
            //Thread.Sleep(timer);
            //Console.Write(" ");
            //Thread.Sleep(timer);
            //Console.Write("w");
            //Thread.Sleep(timer);
            //Console.Write("o");
            //Thread.Sleep(timer);
            //Console.Write("r");
            //Thread.Sleep(timer);
            //Console.Write("d");
            //Thread.Sleep(timer);
            //Console.Write(" ");
            //Thread.Sleep(timer);
            //Console.Write("w");
            //Thread.Sleep(timer);
            //Console.Write("a");
            //Thread.Sleep(timer);
            //Console.Write("s");
            //Thread.Sleep(timer);
            //Console.Write(".");
            //Thread.Sleep(timer);
            //Console.Write(".");
            //Thread.Sleep(timer);
            //Console.Write(".");
            //Thread.Sleep(timer);
            #endregion
            timer = 400;


            ////////////////////////////
            /////NEEDS WORK/////////////
            ////////////////////////////
            ///
            ///I want this to go through the alphabet and pick each letter out, putting it into the game, revealing the word.
            /////

            bool loopFlag = true;
            int h = 0;
            while (h < 26)
            {
                Console.Clear();
                Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
                if (wins != 0 || losses != 0)
                {
                    Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
                }
                else
                {
                    Console.WriteLine();
                }
                Console.WriteLine("                                        ");
                Console.WriteLine("                             ,____      ");
                Console.WriteLine("                             |    |     ");
                Console.WriteLine("                             O    |     ");
                Console.WriteLine("            H A N G M A N   /|\\   |     ");
                Console.WriteLine("                             |    |     ");
                Console.WriteLine("           G A M E          / \\   |     ");
                Console.WriteLine("                 O V E R    _____/|     ");
                Console.WriteLine("                                        ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("  ");
                #region shows alphabet & star arrays

                for (int i = 0; i < alphabet.Length; i++)
                {
                    // Get character from array.
                    char letter = alphabet[i];
                    // Display each letter.
                    Console.Write(" {0}", letter);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("                 ");
                for (int i = 0; i < answerArray.Length; i++)
                {
                    // Get character from array.
                    char letter = starArray[i];
                    // Display each letter.
                    Console.Write(" {0}", letter);

                }

                Console.WriteLine("     SOLVING...");
                #endregion


                // will remove before finished
                // Console.WriteLine(word);


                if (h <= 25)
                {
                    loopFlag = true;
                }
                // DISPLAY ALPHABET
                while (loopFlag)
                {
                    while (alphabet[h] == '_' && h < 26)
                    {
                        // Console.WriteLine("SKIPPED!");
                        ////////////////////////////////////////////////////Thread.Sleep(timer);
                        h++;
                    }
                    char letter = alphabet[h];

                    Thread.Sleep(timer);
                    // Console.WriteLine("While Loopflag... ");
                    // Console.WriteLine("INT h = {0}" , h);
                    if (h < alphabet.Length)
                    {
                        // Console.WriteLine("alphabet letter: {0}" , alphabet[h]);
                    }
                    else
                    {
                        gameSolved = true;
                    }

                    // Get character from alphabet[] starting with a...
                    timer = 200;

                    //Console.Write(" {0}", letter);
                    // if the word contains the current letter of the alphabet...

                    if (word.Contains(letter))
                    {
                        h++;
                        // Console.WriteLine("If word.Contains(alphabet)....");
                        // check every letter in the word, and change star array & alphabet
                        for (int k = 1; k <= word.Length; k++)
                        {
                            if (answerArray[k - 1] == letter)
                            {
                                //                                timer = 2000;
                                answerArray[k - 1] = letter;
                                starArray[k - 1] = answerArray[k - 1];
                                alphabet[h - 1] = '_';
                                Thread.Sleep(timer);
                                //     Console.WriteLine("test");
                            }

                        }

                    }
                    else
                    {
                        // Console.WriteLine("Letter not in word!");
                        h++;
                        // Console.WriteLine("INT h = {0}", h);
                    }
                    loopFlag = false;
                    // Console.ReadLine();
                }

            }

            Console.Clear();
            Console.WriteLine("  Wins: {0}                                           Losses: {1}", wins, losses);
            if (wins != 0 || losses != 0)
            {
                Console.WriteLine("                You have won {0:F0}% of your games.", wins / (wins + losses) * 100);
            }
            else
            {
                Console.WriteLine();
            }
            Console.WriteLine("                                        ");
            Console.WriteLine("                             ,____      ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("                             O    |     ");
            Console.WriteLine("            H A N G M A N   /|\\   |     ");
            Console.WriteLine("                             |    |     ");
            Console.WriteLine("           G A M E          / \\   |     ");
            Console.WriteLine("                 O V E R    _____/|     ");
            Console.WriteLine("                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("  ");


            for (int i = 0; i < alphabet.Length; i++)
            {
                // Get character from array.
                char letter = alphabet[i];
                // Display each letter.
                Console.Write(" {0}", letter);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                 ");
            for (int i = 0; i < answerArray.Length; i++)
            {
                // Get character from array.
                char letter = starArray[i];
                // Display each letter.
                Console.Write(" {0}", letter);

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("    Press \"Q\" to exit or any other key to start another game!");
            string luserInput = Console.ReadLine();

            if (luserInput == "q")
            {
                Environment.Exit(1);
            }

            else
            {
                Hangman();
            }

        }
    }
}
