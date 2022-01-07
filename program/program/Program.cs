using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        
        
                        
        static void Main()
        {
            var voteList = new Dictionary<string, int>
            {

            };

            Console.WriteLine("Enter your survey text:");
            string surveyText = Console.ReadLine();

            Console.WriteLine("Write the variant for vote or <Enter> when you finish add:");
            string newCandidate = Console.ReadLine();
            int i = 0;

            while (newCandidate != "Enter")
            {
                voteList.TryAdd(newCandidate, i);
                newCandidate = Console.ReadLine();
            }
            Console.Clear();

            Console.WriteLine("Pls choose candidate: (For end write <Finish>)");
            ShowAll(voteList);

            string enterVote = Console.ReadLine();

            bool findCandidate = voteList.ContainsKey(enterVote);
            

            while (enterVote != "Finish")
            {
                if (findCandidate == true && voteList.ContainsKey(enterVote))
                {
                    voteList[enterVote]++;
                }
                else
                {
                    Console.WriteLine("You have mistake. Pls write a candidate");
                }
                enterVote = Console.ReadLine();
            }

            Console.Clear();

            Console.Write("Winer is: ");
            var result = voteList.Max(s => s.Key);
            //var result = voteList.Where(s => s.Value.Equals(max)).Select(s => s.Key).ToList();
            Console.WriteLine(result);

            voteList.Clear();

            

        }
        static void ShowAll<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

       
    }

}