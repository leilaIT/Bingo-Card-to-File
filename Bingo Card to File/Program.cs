using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_Card_to_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PP01_Dela Rea
            //PROGRAM FLOW
            //prog will read input file w/ a number
            //the number will dictate how many cards will be generated
            //after all cards are generated, each card will be displayed in a text file

            string numFilePath = "number.txt";
            string cardFile = "Bingo Card.txt";
            int cardNum = 0;

            int[,] bCard = new int[5, 5];
            List<int> listNum = new List<int>();
            Random rnd = new Random();
            int num = 0;

            //reading the file with the number
            string line = "";
            using (StreamReader sr = new StreamReader(numFilePath))
            {

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine("The number in the file is: " + line);
                    cardNum = int.Parse(line);
                }
            }

            //generating the bingo cards and writing them to the file
            for (int i = 0; i < cardNum; i++) //tells the program how many cards to generate
            {
                //initialize card contents to 0
                for (int x = 0; x < bCard.GetLength(0); x++) //card row
                {
                    for (int y = 0; y < bCard.GetLength(1); y++) //card col
                    {
                        bCard[x, y] = 0;
                    }
                }

                //bingo card generation
                for (int x = 0; x < bCard.GetLength(0); x++) //card row
                {
                    listNum.Clear();
                    for (int c = 1; c < 16; c++) //for generating possible numbers from 1-15
                    {
                        listNum.Add(c);
                    }

                    for (int y = 0; y < bCard.GetLength(1); y++) //card col
                    {
                        //generate numbers
                        num = rnd.Next(0, listNum.Count);
                        bCard[y, x] = listNum[num];
                        listNum.RemoveAt(num);
                    }
                }

                using (StreamWriter sw = new StreamWriter(cardFile + (i + 1) + ".txt"))
                {
                    //display
                    sw.WriteLine("B\tI\tN\tG\tO");
                    for (int x = 0; x < bCard.GetLength(0); x++)
                    {
                        for (int y = 0; y < bCard.GetLength(1); y++)
                        {
                            bCard[x, y] += (15 * y);
                            sw.Write(bCard[x, y] + "\t");
                        }
                        sw.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}