using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstApp.Models;
using FirstApp.DataAccess;

namespace FirstApp.ViewModels
{
    public class EditQuestionsViewModel : Screen
    {
        public BindableCollection<QuestionModel> Questions = SqliteDataAccess.LoadQuestions();
        public string sth = "sf";

        public void Edit()
        {
        }
    }
}
