using System;
using System.Linq;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create word list
            string[] words = { "ALMANYA", "TÜRKİYE", "FİNLANDİYA", "SAMOA", "SOMALİ", "AVUSTRALYA", "AVUSTURYA", "LİHTENŞTAYN" };

            //Generate a random number
            Random rnd = new Random();
            int num = rnd.Next(0, (words.Length - 1));

            //Pick a random word
            string pickedWord = words[num];

            //Convert it to a list so we can check if the game is over
            List<string> pickedWordList = new List<string>();
            for (int i = 0; i < pickedWord.Length; i++)
            {
                pickedWordList.Add(pickedWord[i] + " ");
            }
            //Convert it back to a string
            string pickedWordListString = String.Join("", pickedWordList);

            //Create a puppet word with "__"s
            Console.WriteLine(pickedWord);
            List<string> dashes = new List<string>();

            for (int i = 0; i < pickedWord.Length; i++)
            {
                dashes.Add("__ ");
            }
            foreach (string i in dashes)
            {
                Console.Write(i);
            }

            bool gameOver = false;
            //Get an input from the user
            List<string> guessedOnes = new List<string>();
            Console.Write("\nInput a guess or a letter: ");
            string input = Console.ReadLine();
            guessedOnes.Add(input);

            //Health system
            int counter = 0;
            while (!gameOver)
            {
                //Check if the given input is a character or a word
                if (input.Length == 1)
                {
                    //If the input exists in the picked word than add the index of that input in pickedWord to a list
                    char inputChar = input[0];
                    List<int> indexList = new List<int>();
                    for (int index = 0; index < pickedWord.Length; index++)
                    {
                        if (pickedWord[index] == inputChar)
                        {
                            indexList.Add(index);
                        }
                    }

                    //If idexList is not empty replace the dashes in puppet word to found character and ask for a new input
                    if (indexList.Count != 0)
                    {
                        foreach (int i in indexList)
                        {
                            dashes[i] = input + " ";
                        }
                        //Convert dashes to string
                        string dashesStr = String.Join("", dashes);
                        if (dashesStr != pickedWordListString)
                        {
                            Console.WriteLine(dashesStr);
                            Console.Write("Input a guess or a letter: ");
                            guessedOnes.Add(input);
                            input = Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("CONGRATS! YOU WIN THE WORD WAS: " + pickedWord);
                            gameOver = true;
                        }

                    }
                    else
                    {
                        Console.WriteLine("HARF BU DEĞİL!");
                        Console.WriteLine("KALAN HAK: " + (8 - counter));
                        Console.Write("Input a guess or a letter: ");
                        input = Console.ReadLine();
                        counter++;
                        if (counter == 8)
                        {
                            gameOver = true;
                            Console.WriteLine("KAYBETTİNİZ KELİME: " + pickedWord);
                        }
                    }

                }
                else
                {
                    if (input != pickedWord)
                    {
                        Console.WriteLine("KELİME BU DEĞİL! ");
                        Console.WriteLine("KALAN HAK: " + (8 - counter));
                        counter++;
                        Console.Write("Input a guess or a letter: ");
                        input = Console.ReadLine();
                        counter++;
                        if (counter == 8)
                        {
                            gameOver = true;
                            Console.WriteLine("KAYBETTİNİZ KELİME: " + pickedWord);
                        }
                    }
                    else
                    {
                        Console.WriteLine("CONGRATS YOU WIN THE WORD WAS: " + pickedWord);
                        gameOver = true;
                    }
                }
            }

        }
    }
}
