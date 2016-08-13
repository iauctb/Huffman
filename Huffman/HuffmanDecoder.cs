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
            Bitwise = Bitwise.Remove(0, 8);
            while (isCompelete != true)
            {

                foreach (var item in Codex)
                {
                    string key = item.Key;
                    string val = item.Value;
                    int ln = val.Length;
                    try
                    {
                        string sub = Bitwise.Substring(c, ln);

                        if (sub == val)
                        {
                            Bitwise = Bitwise.Remove(c, ln);
                            Bitwise = Bitwise.Insert(c, key);
                            c++;
                        }
                    }
                    catch (Exception)
                    {
                        isCompelete = true;
                        break;
                    }
                }
                if (isCompelete)
                    break;
            }
            Bitwise = Bitwise.Remove(c, extra);
            return Bitwise;
        }
    }
}
