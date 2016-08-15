# Huffman 
### A simple library set for Huffman's Coding algorithm
This is a hobby project initiated by Ashkan Taravati and Behzad Chizari alongside with Dr. Jahanshahi's 'Design and Analysis of Algorithms' Course.
The major classes of this library are as follows:

## -HuffmanTree:
A Binary tree that stores Huffman Elements in a Generic List.

## -HuffmanElement (Implements IComparable):
A class declaration for objects holding values and frequencies for each character found in input string. It also represents Huffman Tree Nodes. and 

## -HuffmanEncoder:
The main body for the encoder; Gets a string, finds frequencies of each character, instatiates Huffman Elements for each character, builds a Huffman tree, generates a dictionary according to each element and generates a string of bits by replacing each character in the input string with their Huffman code.

## -HuffmanDecoder:
The main body for the decoder; Reads a .bin file parsing it as a binary string and parses a json file converting it to a dictionary. It will then replace binary Huffman codes in the binary string with their corresponding characters, rebuilding the original string.

## -OutputStream:
A class for File IO Procedures. 

## -JSONWriter:
A class featuring required methods for generating a string containing json object out of the Generic Dictionary used in HuffmanEncoder.
