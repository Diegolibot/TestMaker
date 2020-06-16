using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FirstApp.Models;
using Microsoft.Win32;
using FirstApp.DataAccess;

namespace FirstApp.ViewModels
{
    public class NewQuestionViewModel : Screen
    {
        //Variables
        private string _questionText;
        private string _answersText = "No Answers";
        private string _newAnswer;
        private string _correct;
        public BindableCollection<string> Answers = new BindableCollection<string>();
        private BindableCollection<int> _correctOptions = new BindableCollection<int>();
        private string _imageSource;
        public Guid id;
        private string _topicsText = "";
        private BindableCollection<TopicModel> _topics = SqliteDataAccess.LoadTopics();
        private TopicModel _selectedTopic;
        private string _newTopic;
        private BindableCollection<TopicModel> _selectedTopics = new BindableCollection<TopicModel>();



        //Variable controlers
        public string QuestionText
        {
            get { return _questionText; }
            set
            {
                _questionText = value;
                NotifyOfPropertyChange(()=>QuestionText);
            }
        }
        public string AnswersText
        {
            get { return _answersText; }
            set
            {
                _answersText = value;
                NotifyOfPropertyChange(()=> AnswersText);
            }
        }
        public string NewAnswer
        {
            get { return _newAnswer; }
            set
            {
                _newAnswer = value;
                NotifyOfPropertyChange(()=> NewAnswer);
            }
        }
        public string Correct
        {
            get { return _correct; }
            set
            {
                _correct = value;
                NotifyOfPropertyChange(()=>Correct);
            }
        }
        public BindableCollection<int> CorrectOptions
        {
            get { return _correctOptions; }
            set
            {
                _correctOptions = value;
                NotifyOfPropertyChange(()=>CorrectOptions);
            }
        }
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                NotifyOfPropertyChange(()=> ImageSource);
            }
        }
        public string TopicsText
        {
            get { return _topicsText; }
            set
            {
                _topicsText = value;
                NotifyOfPropertyChange(()=> TopicsText);
            }
        }
        public BindableCollection<TopicModel> Topics
        {
            get { return _topics; }
            set
            {
                _topics = value;
                NotifyOfPropertyChange(() => Topics);
            }
        }
        public TopicModel SelectedTopic
        {
            get { return _selectedTopic; }
            set
            {
                _selectedTopic = value;
                NotifyOfPropertyChange(()=> SelectedTopic);

                AddSelectedTopic(value);


            }
        }
        public string NewTopic
        {
            get { return _newTopic; }
            set
            {
                _newTopic = value;
                NotifyOfPropertyChange(()=> NewTopic);
            }
        }
        public BindableCollection<TopicModel> SelectedTopics
        {
            get { return _selectedTopics; }
            set
            {
                _selectedTopics = value;
                NotifyOfPropertyChange(() => SelectedTopics);
            }
        }


        // Functions
        public void SelectImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (dialog.ShowDialog() == true)
            {
                ImageSource = dialog.FileName;
            }
        }

        public void AddSelectedTopic(TopicModel value)
        {
            //Insert selected topic
            if (value != null)   //Check if its not null
            {
                int controller = 1;
                foreach (var topic in SelectedTopics)   //Go through the selected one
                    if (value.Name == topic.Name)     //Check if its not the same
                        controller = 0;

                if (controller == 1)
                {
                    //Add it to the selected topics
                    SelectedTopics.Add(value);
                    TopicsText = "";

                    foreach (var topic2 in SelectedTopics) //Add it to the textbox
                    {
                        TopicsText = TopicsText + $"{topic2.Name}\n";
                    }
                }
            }
        }
        //Function for adding an Answer
        public void AddAnswer()
        {
            if (NewAnswer != null)
            {
                //Delete the default text if needed
                if (AnswersText == "No Answers")
                    AnswersText = "";

                //Add answers to the answer list
                Answers.Add(NewAnswer);

                //Add the number to the correct answer otpions
                int num = CorrectOptions.Count + 1;
                CorrectOptions.Add(num);

                //Display the new answer
                AnswersText = AnswersText + num.ToString() + ") " + NewAnswer + "\n";

                NewAnswer = "";


            }
            else
            {
                MessageBox.Show("No text for answer");
            }
        }

        public void AddAnswerEnter(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;

            if (keyArgs != null && keyArgs.Key == Key.Enter)
            {
                AddAnswer();
            }
        }

        //Function to clean selected topics
        public void ClearTopics()
        {
            SelectedTopics = new BindableCollection<TopicModel>();
            TopicsText = "";
        }
        //FUnction to add a new topic
        public void AddTopic()
        {
            if (NewTopic != null && NewTopic != "")
            {
                SqliteDataAccess.SaveTopic(NewTopic);
                Topics = SqliteDataAccess.LoadTopics();
                NewTopic = "";
            }
            else
            {
                MessageBox.Show("No name for new topic");
            }
        }
        //Function for creating the question object and submiting it to the database
        public void Submit()
        {

            if (CorrectOptions.Count==0 || (Correct==null || Correct=="") ||
                (QuestionText==null || QuestionText=="") || SelectedTopics.Count == 0) 
            {
                MessageBox.Show("Missing Data");
            }
            else
            {

                //We create  question with the given data

                QuestionModel question = new QuestionModel(QuestionText, Int32.Parse(Correct), Answers, ImageSource);

                SqliteDataAccess.SaveQuestion(question, SelectedTopics);
                
                MessageBox.Show("New Question Created");
                Clear();
            }
            
        }
        //Function to clear everythning
        public void Clear()
        {
            QuestionText = "";
            AnswersText = "No Answers";
            NewAnswer = "";
            Correct = "";
            Answers = new BindableCollection<string>();
            CorrectOptions = new BindableCollection<int>();
            ImageSource = "";
            TopicsText = "";
            SelectedTopics = new BindableCollection<TopicModel>();
            SelectedTopic = null;
        }

}
}
