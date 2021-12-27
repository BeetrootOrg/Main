using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16Colection
{
    internal class Poll
    {
        private string _question { get; set; }
        private List<AnswerOption> _answerOptions { get; set; }
        public Poll(string question)
        {
            _answerOptions = new List<AnswerOption>();
            _question = question;
        }
        public string GetQuestion()
        {
            return _question;
        }
        public List<AnswerOption> GetAnswer() 
        {
            return _answerOptions;
        }
        public void Vote(int answerId)
        {
            _answerOptions[answerId].VoteForAnswer();
        }
        public void AddOption(AnswerOption option)
        {
            _answerOptions.Add(option);
        }
    }
}
