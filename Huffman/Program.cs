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
             * converts the input string
             * Attention! Program may fail if only one type of character is given as input
             * please give at least to different characters.
             */
            Console.WriteLine("Please enter your text");
            string x = Console.ReadLine();
            try
            {
                var hfc = new HuffmanEncoder(x);
                Console.WriteLine("The encoded binary string for {0} is:\n {1}", hfc.Standard, hfc.Bitwise);
                Console.WriteLine("The encoded binary string length is:\n {0}bits", hfc.Bitwise.Length);
                Console.WriteLine("Press any key to save data to disk");
                Console.ReadKey();
                OutputStream.Write(Environment.GetFolderPath(SpecialFolder.DesktopDirectory), hfc);
                Console.WriteLine("Output is saved in Desktop\\Huffman Encoder");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            /*
             * Implementing Mode II: Decoder
             * Parse the Binary File
             * 
             */
            try {
                Console.Clear();
                Console.WriteLine("Done!");
                Console.WriteLine("Now, let's decode the encoded binary! Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine(HuffmanDecoder.Decode(Environment.GetFolderPath(SpecialFolder.DesktopDirectory).ToString() + "\\Huffman Encoder"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();

        }
    }
}
