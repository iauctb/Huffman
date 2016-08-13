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
            //sb.Append("{");
            //sb.Append("\"Codex\":[");
            //foreach(var item in input)
            //{
            //    sb.AppendFormat("{0}\"Key\":\"{1}\",\"Value\":{2}{3}", "{", item.Key.ToString(), item.Value, "}");
            //    sentinel++;
            //    if (sentinel <= input.Count)
            //        sb.Append(",");

            //}
            //sb.Append("]}");



            sb.Append("{");
            foreach (var item in input)
            {
                sb.AppendFormat("\"{0}\":\"{1}\"", item.Key.ToString(), item.Value);
                sentinel++;
                if (sentinel <= input.Count)
                    sb.Append(",");

            }
            sb.Append("}");
            return sb.ToString();
        }


    }
}
