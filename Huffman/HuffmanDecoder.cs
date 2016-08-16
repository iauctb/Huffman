using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CACTB.Coding.Huffman
{
    class HuffmanDecoder : OutputStream
    {
        public static string Decode(string folderPath)
        {
            Dictionary<string, string> Codex = OutputStream.ReadDictionary(folderPath);
            string Bitwise = OutputStream.ReadBitwise(folderPath);
            int c = 0;
            bool isCompelete = false;
            int extra = Convert.ToInt32(Bitwise.Substring(0, 8), 2);
            int stringSize = Convert.ToInt32(Bitwise.Substring(8, 8), 2);
            Bitwise = Bitwise.Remove(0, 16);
            Bitwise = Bitwise.Remove(Bitwise.Length - extra, extra);
            int s = 0;
            while (!isCompelete)
            {

                foreach (var item in Codex)
                {
                    string key = item.Key;
                    string val = item.Value;
                    int ln = val.Length;
                    try
                    {
                        string sub = Bitwise.Substring(s, ln);

                        if (sub == val)
                        {
                            Bitwise = Bitwise.Remove(s, ln);
                            Bitwise = Bitwise.Insert(s, key);
                            s++;
                        }
                    }
                    catch (Exception)
                    {
                        //throw;
                        isCompelete = true;
                    }
                }
            }
            return Bitwise;
        }
    }
}
