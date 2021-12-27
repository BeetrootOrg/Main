using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16Colection
{
    internal class AnswerOption
    {
        private string _answerOption { get; set; }
        private int _count { get; set; }

        public AnswerOption(string answerOption)
        {
            _answerOption = answerOption;
            _count = 0;
        }
        public int GetCount()
        {
            return _count;
        }
        public string GetAnswerOption()
        {
            return _answerOption;
        }
        public void VoteForAnswer()
        {
            _count++;
        }
    }
}
