using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GamePrint.Box("Hangman");

        /*  Step 1.
        Player selects one of the existing categories.
        */

        // We need a list of categories, each with multiple items inside (e.g. movies, books, tv shows, etc);
        string[] categories = new string[] {
            "TV Shows",
            "Movies"
        };

        string[] tvShows = new string[] {
            "Breaking Bad",
            "The Sopranos",
            "The Wire"
        };

        string[] movies = new string[] {
            "Snatch",
            "Pulp Fiction",
            "Fight Club"
        };

        // Display the categories list.
        string categoriesList = "";
        for (int i = 0; i < categories.Length; i++)
        {
            categoriesList += "\n" + i + ": " + categories[i];
        }

        GamePrint.Input("Select category to play with:" + categoriesList);

        // Player selects one of the categories.
        int selectedCategory = GameInput.Number(0, categories.Length - 1);

        /*  Step 2.
        Present the game screen.
        */

        // We select a random item from the selected category;
        string word = null;
        switch (selectedCategory)
        {
            case 0: // TV Shows
                word = tvShows[GameRandom.Number(0, tvShows.Length - 1)];
                break;
            case 1: // Movies
                word = movies[GameRandom.Number(0, movies.Length - 1)];
                break;
        }
        word = word.ToUpper();

        // Display the game screen:

        List<string> guessedLetters = new List<string>();
        List<string> wrongLetters = new List<string>();

        int letterCount = word.Replace(" ", "").Length;
        int correctLetters = 0;
        while (wrongLetters.Count < 7)
        {
            // - Hanged man display:
            /*
            ._______.
            |/      |
            |       @
            |      /|\
            |       |
            |      / \
            |
            __|__
            */

            string hangmanTemplate = "    .________.\n" +
                                "    |/       |\n" +
                                "    |        {0}\n" +
                                "    |       {2}{1}{3}\n" +
                                "    |        {1}\n" +
                                "    |       {4} {5}\n" +
                                "    |\n" +
                                "____|____\n";

            string[] hangmanArgs = new string[] { " ", " ", " ", " ", " ", " " };
            for (int i = 0; i < wrongLetters.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        hangmanArgs[i] = "@";
                        break;
                    case 1:
                        hangmanArgs[i] = "|";
                        break;
                    case 2:
                    case 4:
                        hangmanArgs[i] = "/";
                        break;
                    case 3:
                    case 5:
                        hangmanArgs[i] = "\\";
                        break;
                }
            }

            Console.WriteLine(string.Format(hangmanTemplate, hangmanArgs));

            // - Row of dashes representing each letter of the words to guess;
            // Category: _ _ _ _ _  _ _ _

            string wordTemplate = "{0}: {1}";
            string wordArgs = "";
            for (int i = 0; i < word.Length; i++)
            {
                string wordLetter = word[i].ToString();
                if (wordLetter == " ")
                {
                    wordArgs += wordLetter;
                    continue;
                }

                string displayLetter = "_";
                if (guessedLetters.Contains(wordLetter))
                {
                    displayLetter = wordLetter;
                }

                wordArgs += displayLetter.ToUpper();
                wordArgs += " ";
            }

            Console.WriteLine(string.Format(wordTemplate, categories[selectedCategory], wordArgs));

            // - Set of wrong letters chosen by the player;
            // Misses: A, A, E

            string missesTemplate = "Misses: {0}";
            string missesArgs = string.Join(", ", wrongLetters);
            Console.WriteLine(missesTemplate, missesArgs);

            if (correctLetters == letterCount)
            {
                break;
            }

            /* Step 3.
           Player selects a letter.

               - If the letter exists, we replace the corresponding dashes by the letter;
               - If the letter does not exist:
                   - We draw one element of the hanged man;
                   - We add the letter to the list of Misses;
           */

            GamePrint.Input("Choose a letter:");
            string selectedLetter = null;
            while (selectedLetter == null)
            {
                selectedLetter = GameInput.Text(1).ToUpper();
                if (guessedLetters.Contains(selectedLetter))
                {
                    selectedLetter = null;
                }
            }

            bool isCorrect = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].ToString() != selectedLetter)
                {
                    continue;
                }

                isCorrect = true;
                correctLetters++;
            }

            if (isCorrect)
            {
                guessedLetters.Add(selectedLetter);
            }
            else
            {
                wrongLetters.Add(selectedLetter);
            }
        }

        /* Step 4.
        Evaluate game win/lose condition.

            - If all letters are discovered, player wins.
            - If hanged man is fully drawn - maximum 7 errors, player loses.
            - Else game continues.
        */

        /* Step 5.
        If payer wins/loses, show menu to continue playing.
        */

        // 1: select category, 2: same category, 3: quit
        int gameSelection = 1;
        int selectedCategory = 0;
        while (gameSelection != 3)
        {
            if (gameSelection == 1)
            {
                string categoriesList = "";
                for (int i = 0; i < categories.Length; i++)
                {
                    categoriesList += "\n" + i + ": " + categories[i];
                }

                GamePrint.Input("Select category to play with:" + categoriesList);
                selectedCategory = GameInput.Number(0, categories.Length - 1);
            }

            string word = null;
            switch (selectedCategory)
            {
                case 0: // TV Shows
                    word = tvShows[GameRandom.Number(0, tvShows.Length - 1)];
                    break;
                case 1: // Movies
                    word = movies[GameRandom.Number(0, movies.Length - 1)];
                    break;
            }
            word = word.ToUpper();



            if (correctLetters == letterCount)
            {
                GamePrint.Success("You Win!");
            }
            else
            {
                GamePrint.Error("Game Over!");
            }

            GamePrint.Input("What do you want to do?\n1. Select a new category\n2. Continue with same category\n3. Quit");
            gameSelection = GameInput.Number(1, 2, 3);
        }
    }
}