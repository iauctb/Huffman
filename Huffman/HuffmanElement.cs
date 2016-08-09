using System;
using System.Text;

namespace CACTB.Coding.Huffman
{
    class HuffmanElement<T>:IComparable
    {
        public T Value { get; private set; }
        public int Frequency { get; private set; }
        public HuffmanElement<T> LeftChild;
        public HuffmanElement<T> RightChild;
        public HuffmanElement<T> Parent;
        public string PathCode { get; set; }
        public  HuffmanElement()
        { }
        public HuffmanElement(T value,int frequency)
        {
            Value = value;
            Frequency = frequency;
        }
        public HuffmanElement(int frequency, HuffmanElement<T> left, HuffmanElement<T> right)
        {
            LeftChild = left;
            RightChild = right;
            Frequency = frequency;
        }
        public int CompareTo(object obj)
        {
            HuffmanElement<T> that = obj as HuffmanElement<T>;
            if (that != null)
                return this.Frequency.CompareTo(that.Frequency);
            else
                throw new ArgumentException("Object is not a valid Huffman Element!");
            
        }
        public string GetData()
        {
            if (this == null)
                return "null";
            else
                return new StringBuilder().AppendFormat("Character {0}: Repeat {1}",Value, Frequency).ToString();
            
        }
        public bool IsLeaf()
        {
            if ((LeftChild == null) && (RightChild == null))
                return true;
            else
                return false;
        }
    }
}
