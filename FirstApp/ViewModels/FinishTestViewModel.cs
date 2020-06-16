using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FirstApp.Models;

namespace FirstApp.ViewModels
{
    public class FinishTestViewModel
    {
        public TestModel Test;
        public ShellViewModel controler;

        private string _grade;

        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public FinishTestViewModel(TestModel test, ShellViewModel shell)
        {
            Test = test;
            controler = shell;
            Grade = "Grade: " + Test.Check() + " = " + Test.GradeNum.ToString();
        }

        public void Exit()
        {
            controler.ReturnToMenu();
        }

        public void WrongQuestions()
        {
            Test.Questions = Test.Wrong;
            Test.NumberOfQuestions = Test.Wrong.Count;
            Test.GradeNum = 0;
            Test.Time = 8200;
            Test.Wrong = new BindableCollection<QuestionModel>();
            controler.StartTest(Test);
        }
    }
}
