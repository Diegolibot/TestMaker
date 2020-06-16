using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FirstApp.Models;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace FirstApp.ViewModels
{
    public class TestViewModel : Screen
    {
        //Variables
        public TestModel Test;
        private BindableCollection<QuestionModel> _questions;
        private string _currentQuestionText;
        private string _chosen;
        private List<string> _options;
        private BindableCollection<AnswerModel> _answers = new BindableCollection<AnswerModel>();
        private BitmapImage _currentImage;
        public int CurrentQuestionId;
        public System.Timers.Timer Timer = new System.Timers.Timer();
        public int TimeLeft;
        private string _time;
        private ShellViewModel controler;


        //Variable controlers
        public string CurrentQuestionText
        {
            get { return _currentQuestionText; }
            set
            {
                _currentQuestionText = value;
                NotifyOfPropertyChange(()=>CurrentQuestionText);
            }
        }
        public string Chosen
        {
            get { return _chosen; }
            set
            {
                _chosen = value;
                NotifyOfPropertyChange(()=>Chosen);
                if(value != null)
                    Questions[CurrentQuestionId].Chosen = Int32.Parse(Chosen);
            }
        }
        public List<string> Options
        {
            get { return _options; }
            set
            {
                _options = value;
                NotifyOfPropertyChange(()=>Options);
            }
        }
        public BindableCollection<AnswerModel> Answers
        {
            get { return _answers; }
            set
            {
                _answers = value;
                NotifyOfPropertyChange(()=>Answers);
            }
        }
        public BitmapImage CurrentImage
        {
            get { return _currentImage; }
            set
            {
                _currentImage = value;
                NotifyOfPropertyChange(()=>CurrentImage);
            }
        }
        public BindableCollection<QuestionModel> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                NotifyOfPropertyChange(() => Questions);
            }
        }
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                NotifyOfPropertyChange(() => Time);
            }
        }


        //Constructor

        public TestViewModel(TestModel test, ShellViewModel shell)
        {
            controler = shell;
            Test = test;
            Questions = Test.Questions;
            CurrentQuestionId = 0;
            GetQuestion();
            TimeLeft = Test.Time * 60;
            Timer.Elapsed += new ElapsedEventHandler(TimeLeftDisplay);
            Timer.Interval = 1000;
            Timer.Enabled = true;
        }

        //Functions

        public void GetOptions(int num)
        {
            List<string> op = new List<string>();
            for (int i = 1; i <= num; i++)
            {
                op.Add(i.ToString());
            }

            Options = op;
        }

        public void GetQuestion()
        {
            //Createt a question variable with the current question
            QuestionModel question = Questions[CurrentQuestionId];
            //Asignt the Question text to that of the question
            CurrentQuestionText = question.Number.ToString()+") "+question.QuestionText;

            //Add the answers to display
            Answers = new BindableCollection<AnswerModel>();
            int n = 1;
            foreach (var ans in question.Answers)
            {
                Answers.Add(new AnswerModel(n,ans));
                n++;
            }
            //Get the possible answers
            GetOptions(question.Answers.Count);
            Chosen = "0";
            //Get the image
            CurrentImage=question.Image;
        }

        public void Next()
        {
            if (CurrentQuestionId != Test.NumberOfQuestions - 1)
            {
                CurrentQuestionId++;
                GetQuestion();
            }
        }

        public void Previous()
        {
            if (CurrentQuestionId >= 1)
            {
                CurrentQuestionId--;
                GetQuestion();
            }
        }

        public void ItemClick(string n)
        {
            CurrentQuestionId = Int32.Parse(n)-1;
            GetQuestion();
        }

        private void TimeLeftDisplay(object source, ElapsedEventArgs e)
        {
            
            TimeLeft--;
            if (TimeLeft >= 0)
            {
                TimeSpan t = TimeSpan.FromSeconds(TimeLeft);

                if(TimeLeft > 3600)
                    Time = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                else
                    Time = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            }
            else
            {
                Finished();
            }
            
        }

        public void Finished()
        {

            Test.Questions = Questions;
            Test.Time = TimeLeft;
            controler.FinishTest(Test);
        }
    }
}
