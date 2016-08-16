#define TEST
#undef TEST
using System;
using System.IO;
using static System.Environment;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Text;

namespace CACTB.Coding.Huffman
{
    class OutputStream
    {
        public static void Write(string filePath, HuffmanEncoder hfc)
        {
#if TEST
            Console.WriteLine(hfc.Bitwise);

#endif
            //*****************************Initiating File Streams*******************************************
            string strPath = Environment.GetFolderPath(SpecialFolder.Desktop);
            var dir = @strPath + "\\Huffman Encoder";  // folder location
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if (!Directory.Exists(dir + "Codex.json"))
            {
                File.WriteAllText(Path.Combine(dir, "Codex.json"), JSONWriter.DictionaryToJSON(hfc.Codex));
            }
            //*********************************Preparing Data************************************************
            var binaryString = hfc.Bitwise;

            //Create complete octets
            var lack =(8-( binaryString.Length % 8)==8)?0: 8 - (binaryString.Length % 8);//number of bits needed to append to the binaryString until it is octet.
            for (int i = 0; i < lack; i++)
                binaryString += "0";


            var stringArraySize = binaryString.Length / 8;//just to reduce code
            var ByteArraySize = stringArraySize + 2;
            //split to octets
            string[] sub = new string[stringArraySize];
            for (int i = 0; i < stringArraySize; i++)
                sub[i] = binaryString.Substring(i * 8, 8);
            

            //Convert to binary octets
            byte[] x = new byte[ByteArraySize];
            x[0] = (byte)(lack);//first byte will represent the redundant 0s used for making octets
            x[1] = hfc.OriginalSize;//second byte will represent the size for the oroginal input string
            for (int i = 2; i < ByteArraySize; i++)
                x[i] = Convert.ToByte(sub[i - 2], 2);

            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(dir + "\\Encoded Message.bin", FileMode.Create)))
                {

                    for (int i = 0; i < x.Length; i++)
                    {
                        bw.Write(x[i]);

                    }
                }
            }
            catch (Exception ex)
            {
                /*Known Issues are:
                 * UnauthorizedAccessException: if the file exists and is open in another process
                 * 
                 * 
                 * 
                 * 
                 * 
                 * 
                 */
                throw ex;
            }




        }
        protected static Dictionary<string, string> ReadDictionary(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath, "*.json");
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var json = System.IO.File.ReadAllText(files[0]);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            try
            {
                dic = jsonSerializer.Deserialize<Dictionary<string, string>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dic;
        }
        protected static string ReadBitwise(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath, "*.bin");
            //Open .bin certain file
            FileStream readStream = new FileStream(files[0], FileMode.Open);
            BinaryReader readBinary = new BinaryReader(readStream);
            //Save Content of file as a decimal bytes array
            byte[] decimalByte = readBinary.ReadBytes(Convert.ToInt32(readStream.Length));
            readStream.Close();
            string[] binaryArray = new string[decimalByte.Length];
            int counter = 0;
            foreach (var item in decimalByte)
            {
                //converting decimal array to a binary array as string
                binaryArray[counter++] = Convert.ToString(item, 2).PadLeft(8, '0');
            }
            StringBuilder s = new StringBuilder();
            foreach (var item in binaryArray)
            {
                //Attaching string array Elements to Create a string
                s.Append(item);
            }
            return s.ToString();
        }
    }
}