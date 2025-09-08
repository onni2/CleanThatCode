using System.Linq;
using System;

namespace CleanThatCode.Community.Common;

// Your job is to implement this class
public static class StringHelpers
{
    // Instead of spaces it should be separated with dots, e.g. Hello World -> Hello.World
    public static string ToDotSeparatedString(this string str)
    {
        string final = "";
        foreach (char ch in str){
            if (ch == ' ')
            {
                final+='.';
            }else
            {
                final+=ch;
            }
        }
        return final;
    }
        
    // All words in the string should be capitalized, e.g. teenage mutant ninja turtles -> Teenage Mutant Ninja Turtles
    public static string CapitalizeAllWords(this string str)
    {
        bool next_ch = true;
        string final = "";
        foreach (char ch in str){
            if (next_ch)
            {
                final += char.ToUpper(ch);
                next_ch = false;
            }
            else
            {
                
                final+=ch;
            }
            if (ch == ' ')
            {
                next_ch = true;
            }
        }
        return final;
    }

    // The words should be reversed in the string, e.g. Hi Ho Silver Away! -> Away! Silver Ho Hi
    public static string ReverseWords(this string str)
    {
        string[] words = str.Split(' ');
        string final = "";
        Array.Reverse(words);
        return string.Join(" ", words);
        
    }
}