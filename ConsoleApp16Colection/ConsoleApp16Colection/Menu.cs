using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16Colection
{
    internal class Menu
    {
        private List<Poll> _polls { get; set; }
        public Menu()
        {
            _polls = new List<Poll>();
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("'1' Create poll");
            Console.WriteLine("'2' Show poll results");
            Console.WriteLine("'3' Vote for something");
            Console.WriteLine("'4' Exit");
            int temp = int.Parse(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    CreatePoll();
                    break;
                case 2:
                    ShowPollResults();
                    break;
                case 3:
                    VoteForSomething();
                    break;
                    
            }
        }
        public void CreatePoll()
        {
            Console.Clear();
            Console.WriteLine("Enter the question");
            string question = Console.ReadLine();
            Console.WriteLine("Enter the comma - separated answers");
            string answers = Console.ReadLine();
            //"da, net, hz"
            //[da, net, hz]
            var answersArr = answers.Split(',');
            var poll = new Poll(question);
            foreach (var item in answersArr)
            {
                poll.AddOption(new AnswerOption(item));
            }
            _polls.Add(poll);
            Console.WriteLine("Success");
            Console.ReadKey();
            MainMenu();
            return;
        }
        
        public void ShowPollResults()
        {
            Console.Clear();
            PrintPollInfo(true);
            Console.ReadKey();
            MainMenu();
        }

        public void VoteForSomething()
        {
            Console.Clear();
            int pollId = PrintPollInfo();
            Console.WriteLine("Insert number response for poll");
            int response = int.Parse(Console.ReadLine());
            _polls[pollId].Vote(response);
            Console.WriteLine("Succes!");
            Console.ReadKey();
            MainMenu();
            return;
        }
        public int PrintPollInfo(bool withResults = false)
        {
            int i = 0;
            foreach (var item in _polls)
            {
                Console.WriteLine($"Poll {i} {item.GetQuestion()}");
                i++;
            }
            Console.WriteLine("PRESS ANY NUMBER");
            int number = int.Parse(Console.ReadLine());
            var element = _polls.ElementAt(number);
            int j = 0;
            foreach (var item in element.GetAnswer())
            {
                if (withResults)
                {
                    Console.WriteLine($"{j} Answer {item.GetAnswerOption()} : {item.GetCount()} person(s)");
                }
                else
                {
                    Console.WriteLine($"{j} Answer {item.GetAnswerOption()}");

                }
                j++;
            }
            return number;
        }
    }
}
