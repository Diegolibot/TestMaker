using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Media.Imaging;
using System.Drawing;
using Caliburn.Micro;

namespace FirstApp.Models
{
    
    public class QuestionModel
    {
        public int IdQ;
        public string QuestionText;
        public int Answer;
        public BindableCollection<string> Answers;
        public BitmapImage Image;
        public byte[] ImageSource;
        public int Chosen;
        public int _number;

        //Constructors
        public QuestionModel(int IdQ, string qt, int ans, BindableCollection<string> anss)
        {
            QuestionText = qt;
            Answer = ans;
            Answers = anss;
        }
        public QuestionModel(string qt, int ans, BindableCollection<string> anss, string imgsrc)
        {
            QuestionText = qt;
            Answer = ans;
            Answers = anss;
            if (imgsrc != null && imgsrc != "")
            {
                Image = ImageModel.ImageFromSource((imgsrc));
            }
            else
                Image = null;
        }
        public QuestionModel(){}
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

    }
}
