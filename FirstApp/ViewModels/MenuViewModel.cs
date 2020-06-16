using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FirstApp.DataAccess;
using FirstApp.ViewModels;
using Microsoft.Win32;

namespace FirstApp.ViewModels
{
    public class MenuViewModel : Screen
    {
        private ShellViewModel controler;

        public MenuViewModel(ShellViewModel shell)
        {
            controler = shell;
        }
        public void StartExam()
        {
            this.controler.CreateTest();
        }

        public void EditQuestions()
        {
            this.controler.EditQuestions();
        }

        public void UploadQuestionBank()
        {
            MessageBox.Show("Root topics with same topic names will be deleted");
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "SQL Files(*.sql)|*.sql";

            if (dialog.ShowDialog() == true)
            {
                if (dialog.FileName != null)
                {
                    string q = File.ReadAllText(dialog.FileName);
                    SqliteDataAccess.GetSQLFileQuestionBank(q);
                    MessageBox.Show("Question Bank Uploaded");
                }
            }
        }
    }
}
