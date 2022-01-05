namespace Homework
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Formats;
    using System.Text.RegularExpressions;



    /// <summary>
    /// Comented parts of code - for normal implementation, bit reach than in homework requirement. Just to observe idea.
    /// </summary>
    public class Program
    {
        public static List<Poll> pollList = new List<Poll>();
        //public static List<User> Users = new List<User>();  
        public static void Main()
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            bool stat = true;
            while (stat)
            {
                Console.Clear();
                Console.WriteLine("1. Create poll \n 2.Show poll results \n 3.Vote for something\n 4.Exit");
                char key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '1':
                        {
                            Console.WriteLine("Input your poll question");
                            pollList.Add(new Poll(Console.ReadLine()));
                        }
                        break;
                    case '2':
                        {
                            int ccount = 0;
                            foreach (Poll poll in pollList)
                            {
                                Console.WriteLine($"{ccount}. {poll.Question} {poll.Result}");
                                ++ccount;
                            }

                        }
                        break;
                    case '3':
                        int count = 0;
                        foreach (Poll poll in pollList)
                        {
                            Console.WriteLine($"{count}. {poll.Question}");
                            ++count;
                        }
                        Console.WriteLine("Choose question");
                        int k = Int32.MaxValue;
                        try
                        {
                            k = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {

                        }
                        if (k != Int32.MaxValue)
                        {
                            Console.Clear();
                            Console.WriteLine(pollList[k].Question);
                            Console.WriteLine("Are you agree? y/n");
                            char c = Console.ReadKey().KeyChar;
                            switch (c)
                            {
                                case ('y'):
                                    pollList[k].Voters.Add(new Voter { User = (pollList[k].Voters.Count + 1), vote = true });
                                    break;
                                default:
                                    pollList[k].Voters.Add(new Voter { User = (pollList[k].Voters.Count + 1), vote = false });
                                    break;
                            }
                            
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        stat = false;
                        break;
                }

            }
        }

        public class Poll
        {
            //Lazy implemenation
            public Poll(string question)
            {
                Question = question;
                Voters = new List<Voter>();
            }
           public string Question { get; set; }
           public List<Voter> Voters { get; set; }
           private string _result { get; set; }
           public string Result { 
                get 
                {
                    int positive = 0;
                    int negative = 0;
                    foreach(Voter vooter in Voters)
                    {
                        if (vooter.vote == true) positive++;else negative++;
                    }
                    return $"Voted {Voters.Count} users, where {positive} agree and {negative} disagree";
                } 
            }

            public void Vote(bool value)
            {

            }
            



            //Normal Implementation:
            //public List<Voter> Voters { get; set; }

            // public override string ToString()
            // {
            //     StringBuilder sb = new StringBuilder();
            //     sb.Append(Question);
            //     sb.Append(';');
            //     int count = 1;
            //     foreach (var voter in Voters)
            //     {
            //         if (Voters.Count > 1)
            //         {
            //             if (count == 1)
            //             {
            //                 sb.Append("[{");
            //                 sb.Append(voter.ToString());
            //                 sb.Append("};");
            //             }
            //             else if (count > 1 && count < Voters.Count)
            //             {
            //                 sb.Append("{");
            //                 sb.Append(voter.ToString());
            //                 sb.Append("};");
            //             }
            //             else if (count == Voters.Count)
            //             {
            //                 sb.Append("{");
            //                 sb.Append(voter.ToString());
            //                 sb.Append("}]");
            //             }

            //         }
            //         else if (Voters.Count == 1)
            //         {
            //             sb.Append("[{");
            //             sb.Append(voter.ToString());
            //             sb.Append("}]");
            //         }
            //         count++;
            //     }
            //     return sb.ToString();
            // }
        }

        public class Voter
        {
            public int User { get; set; }
            public bool vote { get; set; }

            //public override string ToString()
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append(User);
            //    sb.Append('|');
            //    sb.Append(vote);
            //    return sb.ToString();
            //}
        }

        //public class User
        //{
        //    public int ID { get; set; }
        //    public string Name { get; set; }
        //    public string Email { get; set; }

        //    public override string ToString()
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(ID);
        //        sb.Append(';');
        //        sb.Append(Name);
        //        sb.Append(';');
        //        sb.Append(Email);
        //        return sb.ToString();
        //    }

        //}

        //public class FileIO
        //{

        //}

    }
}