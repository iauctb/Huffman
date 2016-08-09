#define TEST
#undef TEST
using System;
using System.IO;
using static System.Environment;


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
            var size = binaryString.Length / 8;//just to reduce code
            //Create complete octets
            var bound = binaryString.Length%8;
            for (int i = 0; i < bound; i++)
                binaryString += "0";
            
            //split to octets
            string[] sub = new string[size];
            for (int i = 0; i < size; i++)
            {
                sub[i] = binaryString.Substring(i * 8, 8);
            }

            //Convert to binary octets
            byte[] x = new byte[size];
            for(int i=0;i<size;i++)
             x[i]=Convert.ToByte(sub[i], 2);
            
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
    }
}
