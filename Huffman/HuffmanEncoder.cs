#define TEST
#undef TEST
#define ISCONSOLE
using System;
using System.Collections.Generic;
using System.Linq;

namespace CACTB.Coding.Huffman
{

    class HuffmanEncoder
    {



        //******************************Fields***********************************
        List<HuffmanElement<char>> FrequencyList;
        HuffmanTree<char> Tree;
        public Dictionary<char, string> Codex { get; private set; }
        public string Standard { get; private set; }
        public string Bitwise { get; private set; }
        public byte OriginalSize { get; private set; }
        //*****************************End of Fields*****************************
        //******************************Constructors*****************************
        public HuffmanEncoder()
        {

        }
        public HuffmanEncoder(string inputString)
        {
            Standard = inputString;
            OriginalSize = (byte)inputString.Length;
            PopulateFrequencyList();
            PopulateTree();
            Codex = new Dictionary<char, string>();
            GenerateDictionary();
            PrintDictionary();
            Encode();

        }
        //**************************End of Constructors**************************

        //********************************Methods********************************
        public void ManualStart(string inputString)
        {
            OriginalSize = (byte)inputString.Length;
            Standard = inputString;
            PopulateFrequencyList();
            PopulateTree();
            Codex = new Dictionary<char, string>();
            GenerateDictionary();
            PrintDictionary();
            Encode();

        }
        private void PopulateFrequencyList()
        {
            SortedSet<char> characters = new SortedSet<char>();

            foreach (char ch in Standard)
            {
                characters.Add(ch);
            }
            FrequencyList = new List<HuffmanElement<char>>();
            foreach (var x in characters)
            {
                FrequencyList.Add(new HuffmanElement<char>(x, Standard.Count(ch => ch == x)));
                FrequencyList.Sort();
            }
        }
        void GenerateDictionary()
        {
            foreach (var x in Tree.TreeNodes)
            {
                if (x.Value == Tree.TreeNodes.Last().Value)
                {
                    continue;
                }
                else
                {
                    Codex.Add(x.Value, GetCode(x));

                }
            }


        }
        public void GetFrequency()
        {
            //foreach(var element in Frequency)
            //{
            //    Console.WriteLine("{0} is repeated {1} times", element.Key, element.Value);
            //}

            foreach (var element in FrequencyList)
            {
                Console.WriteLine("{0} is repeated {1} times", element.Value, element.Frequency);
            }


        }
        void PopulateTree()
        {
            Tree = new HuffmanTree<char>();
            while (FrequencyList.Count > 1)
            {
#if TEST
                
                Console.WriteLine("****************************************");
                FrequencyList.ForEach(x => Console.WriteLine(x.GetData()));
                Console.ReadKey();
                
#endif
                var selected = FrequencyList.OrderBy(x => x.Frequency).Take(2).ToList();
                var tempArr = selected.ToArray();
                var left = tempArr[0];
                tempArr[0].PathCode = "0";
                var right = tempArr[1];
                tempArr[1].PathCode = "1";
                var parent = new HuffmanElement<char>(left.Frequency + right.Frequency, left, right);
                left.Parent = parent;
                right.Parent = parent;
                Tree.AddNode(left);
                Tree.AddNode(right);
                Tree.AddNode(parent);
                selected.ForEach(x => FrequencyList.Remove(x));
                FrequencyList.Add(parent);
                FrequencyList.Sort();
            }
#if ISCONSOLE
            Console.Clear();
            Console.WriteLine("Tree elements are:");
            Tree.TreeNodes.ForEach(x => Console.WriteLine(x.GetData()));
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
#endif

        }
        string GetCode(HuffmanElement<char> criteria)
        {
            if (criteria.Parent == null)
                return "";
            else
                return GetCode(criteria.Parent) + criteria.PathCode;
        }
#if ISCONSOLE
        void PrintDictionary()
        {
            Console.Clear();
            foreach (var x in Codex)
            {
                Console.WriteLine("{0} is encoded as {1}", x.Key, x.Value);
            }
        }
#endif
        void Encode()
        {
            string Bit = Standard;
            foreach (var code in Codex)
            {
                Bit = Bit.Replace(code.Key.ToString(), code.Value);
                //Console.WriteLine(Bitwise);
            }

            Bitwise = Bit;
        }
        //************************End of Methods**********************************
    }
}
