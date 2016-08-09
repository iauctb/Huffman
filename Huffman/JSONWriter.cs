using System.Collections.Generic;
using System.Text;

namespace CACTB.Coding.Huffman
{
    public static class JSONWriter
    {
        
            public static string DictionaryToJSON(Dictionary<char, string> input)
        {
            StringBuilder sb = new StringBuilder();
            int sentinel = 1;
            sb.Append("{");
            sb.Append("\"Codex\":[\n");
            foreach(var item in input)
            {
                sb.AppendFormat("\t{0}\"Key\":\"{1}\",\"Value\":{2}{3}", "{", item.Key.ToString(), item.Value, "}");
                sentinel++;
                if (sentinel <= input.Count)
                    sb.Append(",\n");

            }
            sb.Append("\n]}");
            return sb.ToString();
        }

        
    }
}
