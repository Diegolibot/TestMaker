using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Models
{
    public class AnswerModel
    {
        private string _answerText;
        public string AnswerText
        {
            get { return _answerText; }
            set { _answerText = value; }
        }

        public AnswerModel(int id, string text)
        {
            AnswerText = id.ToString() + ") "+text;
        }
    }
}
