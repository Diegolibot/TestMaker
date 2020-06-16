using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FirstApp.DataAccess;
using FirstApp.Models;

namespace FirstApp.Models
{
    public class TestModel
    {
        public int Id;

        public int NumberOfQuestions;

        public int Time;

        public TopicModel Topic;

        public BindableCollection<QuestionModel> Questions;

        public BindableCollection<QuestionModel> Wrong = new BindableCollection<QuestionModel>();

        public double GradeNum;

        public void GetQuestions(int numberOfQuestions)
        {
            Questions = SqliteDataAccess.RandomQuestions(numberOfQuestions, Topic.IdT);
        }

        public string Check()
        {
            int correct = 0;
            string ans;
            foreach (var question in Questions)
            {
                if (question.Chosen == question.Answer)
                {
                    correct++;
                }
                else
                {
                    question.Chosen = 0;
                    Wrong.Add(question);
                }
            }

            GradeNum = (10*correct);
            GradeNum = Math.Round(GradeNum/NumberOfQuestions,2);

            ans = correct.ToString() + "/" + NumberOfQuestions.ToString();

            return ans;
        }
    }

}
