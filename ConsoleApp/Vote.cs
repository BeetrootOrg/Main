using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Vote
    {
        private class Person
        {
            public string? Name { get; set; }
            public string? Answer { get; set; }
        }
        public string Question { get; private set; }
        public string[] Answer { get; set; }

        private LinkedList<Person> stack;
        public Vote()
        {
            Answer = new string[2];
            stack = new LinkedList<Person>();
            stack.Clear();
        }
        public void SetQuestion(string q)
        {
            Question = q;
            stack.Clear();
        }
        public void ShowQuestion()
        {
            if (Question == null)
            {
                Console.WriteLine("No Question!");
                return;
            }

            Console.WriteLine("Question: \"{0}\"", Question);
        }
        public void AddNewVotedPerson(string name, string answer)
        {
            stack.Push(new Person() { Name = name, Answer = answer });
        }
        public void ShowVoteResult()
        {
            int CountAnswer1 = 0;
            int CountAnswer2 = 0;
            int CountAnother = 0;

            Person[] _person = stack.GetAll();

            if (_person != null)
            {
                for (int i = 0; i < _person.Length; i++)
                {
                    if (_person[i].Answer == Answer[0])
                    {
                        CountAnswer1++;
                    }
                    else if (_person[i].Answer == Answer[1])
                    {
                        CountAnswer2++;
                    }
                    else
                    {
                        CountAnother++;
                    }
                }
                Console.WriteLine("Answer 0: {0} - {1} person(s)", Answer[0], CountAnswer1);
                Console.WriteLine("Answer 1: {0} - {1} person(s)", Answer[1], CountAnswer2);
                Console.WriteLine("Answer 2: {0} - {1} person(s)", "Another", CountAnother);
            }

            ShowArray(_person);
        }
        private void ShowArray(Person[] array)
        {
            if (array.Length == 0)
            {
                // Console.Write("Stack is empty!\r\n");
                return;
            }
            Console.Write("Poll result in Stack:\r\n");
            Console.Write("(Name, Answer)\r\n");
            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.WriteLine("({0}, {1})", array[i].Name, array[i].Answer);
            }
            Console.Write("\r\n");
        }
    }
}
