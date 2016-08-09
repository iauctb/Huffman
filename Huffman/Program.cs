using System;
using CACTB.Coding.Huffman;
using static System.Environment;

namespace HuffmanProject
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Implementing Mode I: Encoder
             * Prompts the user for input string
             * initializes a new HuffmanEncoder object
             * Finds the frequencies
             * creates the Huffman tree
             * generates the dictionary
             * converts the inout string
             * Attention! Program may fail if only one type of character is given as input
             * please give at least to different characters.
             */
            Console.WriteLine("Please enter your text");
            string x = Console.ReadLine();
            try
            {
                var hfc = new HuffmanEncoder(x);
                OutputStream.Write(Environment.GetFolderPath(SpecialFolder.DesktopDirectory), hfc);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            /*
             * Implementing Mode II: Decoder
             * Not Implemented yet!
             */



            Console.ReadKey();

        }
    }
}
