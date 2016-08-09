using System.Collections.Generic;

namespace CACTB.Coding.Huffman
{
    class HuffmanTree<T>
    {
        public int NumberOfElements { get; private set; }
        public List<HuffmanElement<T>> TreeNodes { get; private set; }
        public HuffmanTree()
        {
            TreeNodes = new List<HuffmanElement<T>>();
        }
        public void AddNode(HuffmanElement<T> newNode)
        {
            TreeNodes.Add(newNode);
            NumberOfElements++;
        }
        
        

    }
}
