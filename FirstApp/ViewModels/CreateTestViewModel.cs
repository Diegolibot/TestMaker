using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FirstApp.Models;
using FirstApp.DataAccess;

namespace FirstApp.ViewModels
{
    public class CreateTestViewModel : Screen
    {

        //Variables
        private BindableCollection<TopicModel> _topics;
        private int _selectedNumberOfQuestions;
        private List<int> _numberOfQuestions = new List<int> {1};
        private TopicModel _selectedTopic;
        private int _maxQuestions = 1;
        private string _selectedTime;
        private ShellViewModel controler;

        //Constructor
        public CreateTestViewModel(ShellViewModel shell)
        {
            controler = shell;
            Topics = SqliteDataAccess.LoadTopics();
        }

        //Funciones para setear variables
        public string SelectedTime
        {
            get
            {
                return _selectedTime;
            }
            set
            {
                if(value!=null)
                    _selectedTime = value.Substring(37, value.Length - 37);
                NotifyOfPropertyChange(() => SelectedTime);
            }
        }
        public int SelectedNumberOfQuestions
        {
            get
            {
                return _selectedNumberOfQuestions;
            }
            set
            {
                _selectedNumberOfQuestions = value;
                NotifyOfPropertyChange(() => SelectedNumberOfQuestions);
            }
        }
        public List<int> NumberOfQuestions
        {
            get
            {
                return _numberOfQuestions;
            }
            set
            {
                _numberOfQuestions = value;
                NotifyOfPropertyChange(() => NumberOfQuestions);
            }
        }
        public int MaxQuestions
        {
            get { return _maxQuestions; }
            set
            {
                _maxQuestions = value;
                NotifyOfPropertyChange(() => MaxQuestions);

                List<int> nums = new List<int>();
                for (int i = 1; i <= value; i++)
                {
                    nums.Add(i);
                }

                NumberOfQuestions = nums;

            }
        }
        public BindableCollection<TopicModel> Topics
        {
            get { return _topics; }
            set { _topics = value; }
        }
        public TopicModel SelectedTopic
        {
            get { return _selectedTopic; }
            set
            {
                _selectedTopic = value;
                if(value!=null)
                    MaxQuestions = SelectedTopic.NumberOfQuestions;
                NotifyOfPropertyChange(() => SelectedTopic);

            }
        }

        //Función para iniciar test, crea un objeto test con las especificaciones
        public void StartTest()
        {
            string message = "";
            if (SelectedNumberOfQuestions != 0 && SelectedTime != null && SelectedTopic != null)
            {
                TestModel currentTest = new TestModel();
                currentTest.NumberOfQuestions = SelectedNumberOfQuestions;
                currentTest.Time = Int32.Parse(SelectedTime);
                currentTest.Topic = SelectedTopic;
                currentTest.GetQuestions(currentTest.NumberOfQuestions);

                controler.StartTest(currentTest);
            }
            else
            {
                message = "There are unselected items";
                MessageBox.Show(message);
            }
            

        }

    }
}
