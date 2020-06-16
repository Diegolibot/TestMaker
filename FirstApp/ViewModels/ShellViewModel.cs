using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstApp.Models;

namespace FirstApp.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }


        public ShellViewModel()
        {
            ActivateItem(new MenuViewModel(this));
            Title="";
            
        }

        public void CreateTest()
        {
            ActivateItem(new CreateTestViewModel(this));
            Title = "Test Maker";
        }

        public void EditQuestions()
        {
            Title = "Test Maker";
            ActivateItem(new NewQuestionViewModel());
        }

        public void ReturnToMenu()
        {
            Title = "";
            ActivateItem(new MenuViewModel(this));
        }

        public void StartTest(TestModel test)
        {
            Title = "Test Maker";
            ActivateItem(new TestViewModel(test,this));
        }

        public void FinishTest(TestModel test)
        {
            Title = "Test Maker";
            ActivateItem(new FinishTestViewModel(test,this));
        }

    }
}
