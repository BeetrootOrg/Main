using System;
using System.Collections.Generic;

class ConsoleAppHomeWorkString07
{
    static void Main(string[] args)
    {
        Console.WriteLine(Compare("string", "string")); 

        Analyze("gag12aga!@@!", out int digits, out int letters, out int other);
        Console.WriteLine($"\nDigits: {digits}" +
                          $"\nLetters: {letters}" +
                          $"\nOther: {other}");

        Console.WriteLine(Sort("Hello"));
        foreach (var item in Duplicate("Hello and Hi"))
        {
            Console.Write($"{item} ");
        }
    }
    static bool Compare(string a, string b) => a == b;
    static void Analyze(string text, out int digits, out int letters, out int other)
    {
        digits = 0;
        letters = 0;
        other = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                letters++;
            }
            else if (char.IsDigit(text[i]))
            {
                digits++;
            }
            else
            {
                other++;
            }
        }
        Console.Write($"Total: {text.Length}");
    }
    static string Sort(string text) 
    {
        char[] arr = text.ToLower().ToCharArray();
        Array.Sort(arr);
        return new string(arr);
    }
    
    static char[] Duplicate(string text)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        char[] duplicates = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            if (dict.ContainsKey(text[i]))
            {
                dict[text[i]]++;
                continue;
            }
            dict.Add(text[i], 1);
        }

        int count = 0;
        foreach (var item in dict)
        {
            if (item.Value > 1)
            {
                duplicates[count] = item.Key;
                count++;
            }
        }
        return duplicates;
    }
}