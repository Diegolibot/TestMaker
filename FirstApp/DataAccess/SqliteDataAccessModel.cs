using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Dapper;
using FirstApp.Models;

namespace FirstApp.DataAccess
{
    public class SqliteDataAccess
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static void UpdateNumberOfQuestions(int id)
        {
            int num = 0;

            //Connection to the database
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //Query
                var output = cnn.Query<QuestionModel>($"SELECT IdQ FROM TopicQuestion LEFT JOIN Topic ON TopicQuestion.Topic = Topic.IdT JOIN Question ON TopicQuestion.Question = Question.IdQ WHERE Topic.idT = {id}", new DynamicParameters());

                List<QuestionModel> outlist = output.ToList();
                foreach (var q in outlist)
                {
                    num++;
                }
                cnn.Execute($"UPDATE Topic SET NumberOfQuestions={num} Where idT={id}");
            }
        }

        public static BindableCollection<QuestionModel> LoadQuestions()
        {
            BindableCollection<QuestionModel> Questions = new BindableCollection<QuestionModel>();

            //Connection to the database
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //Query
                var output = cnn.Query<QuestionModel>($"SELECT * FROM TopicQuestion LEFT JOIN Topic ON TopicQuestion.Topic = Topic.IdT JOIN Question ON TopicQuestion.Question = Question.IdQ", new DynamicParameters());

                List<QuestionModel> outlist = output.ToList();
                for (int i = 0; i < outlist.Count; i++)
                {
                    if (outlist[i].ImageSource != null)
                    {
                        outlist[i].Image = ImageModel.ByteToBitmapImage(outlist[i].ImageSource);
                    }
                    Questions.Add(outlist[i]);

                }

                //Return the people as a lsit
                return Questions;
            }

        }

        public static void SaveQuestion(QuestionModel question, BindableCollection<TopicModel> topics)
        {
            //Connection to the database
            using (var cnn = new SQLiteConnection(LoadConnectionString()))
            {
                byte[] imagen;
                if (question.Image != null)
                    imagen = ImageModel.BitmapToByte(question.Image);
                else
                    imagen = null;

                //Save question data
                cnn.Open();
                SQLiteCommand command = new SQLiteCommand(cnn);
                command.CommandText = "Insert into Question(QuestionText, Answer) values(@param1,@param2)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SQLiteParameter("@param1",question.QuestionText));
                command.Parameters.Add(new SQLiteParameter("@param2", question.Answer));
                command.ExecuteNonQuery();
                cnn.Close();



                //Get the last question ID
                var num = cnn.Query("SELECT IdQ FROM Question ORDER BY IdQ DESC LIMIT 1").First().IdQ;

                //Save image
                SQLiteConnection con = new SQLiteConnection(LoadConnectionString());
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = String.Format($"UPDATE Question SET ImageSource = @0 WHERE IdQ={num}");
                SQLiteParameter param = new SQLiteParameter("@0", System.Data.DbType.Binary);
                param.Value = imagen;
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                //Save answers loop
                int i = 1;
                foreach (var ans in question.Answers)
                {
                    //Save answer
                    cnn.Open();
                    command = new SQLiteCommand(cnn);
                    command.CommandText = "Insert into Answer (AnswerText, Num, Question) values (@param1,@param2,@param3)";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SQLiteParameter("@param1", ans));
                    command.Parameters.Add(new SQLiteParameter("@param2", i));
                    command.Parameters.Add(new SQLiteParameter("@param3", num));
                    command.ExecuteNonQuery();
                    cnn.Close();

                    i++;

                }

                //Add to topic loop
                foreach (var topic in topics)
                {
                    int id = topic.IdT;
                    cnn.Execute($"Insert into TopicQuestion (Question,Topic) values ({num},{id})");
                    UpdateNumberOfQuestions(id);
                }

            }
        }

        public static BindableCollection<TopicModel> LoadTopics()
        {
            //Connection to the database
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //Query
                var output = cnn.Query<TopicModel>("select * from Topic", new DynamicParameters());

                //Convert to bindable collection
                List<TopicModel> outList = output.ToList();
                BindableCollection<TopicModel> outCollection = new BindableCollection<TopicModel>();
                foreach (var topic in output)
                {
                    outCollection.Add(topic);
                }

                //Return the output
                return outCollection;
            }
        }

        public static void SaveTopic(string topic)
        {
            //Connection to the database
            using (var cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                SQLiteCommand command = new SQLiteCommand(cnn);
                command.CommandText = "Insert into Topic (Name,NumberOfQuestions) values (@param1,0)";
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SQLiteParameter("@param1", topic));

                command.ExecuteNonQuery();
                cnn.Close();
            }
        }

        public static BindableCollection<QuestionModel> RandomQuestions(int num, int id)
        {
            BindableCollection<QuestionModel> Questions = new BindableCollection<QuestionModel>();

            //Connection to the database
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //Query
                var output = cnn.Query<QuestionModel>($"SELECT * FROM TopicQuestion LEFT JOIN Topic ON TopicQuestion.Topic = Topic.IdT JOIN Question ON TopicQuestion.Question = Question.IdQ WHERE Topic.idT = {id} ORDER BY random()", new DynamicParameters());

                List<QuestionModel> outlist = output.ToList();
                for (int i = 0; i < num; i++)
                {
                    var outAnswers = cnn.Query<string>($"SELECT AnswerText FROM Answer WHERE Question={outlist[i].IdQ}", new DynamicParameters());


                    List<string> listAns = outAnswers.ToList();
                    BindableCollection<string> bindans = new BindableCollection<string>();
                    outlist[i].Answers = bindans;
                    foreach (var ans in listAns)
                    {
                        outlist[i].Answers.Add(ans);
                    }


                    if (outlist[i].ImageSource != null)
                    {
                        outlist[i].Image = ImageModel.ByteToBitmapImage(outlist[i].ImageSource);
                    }
                    outlist[i].Number = i + 1;

                    Questions.Add(outlist[i]);

                }
                //Return the people as a lsit
                return Questions;
            }

        }

        public static void GetSQLFileQuestionBank(string query)
        {
            using (var cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                SQLiteCommand command = new SQLiteCommand(cnn);
                command.CommandText = query;
                command.ExecuteNonQuery();
                cnn.Close();
            }
        }
    }
}
