using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.IO;
using SimpleJSON;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using TelegramBot.Connect;

namespace TelegramBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebClient webClient = new WebClient();
        //DateTime StartSession;
        string Token = "848538853:AAFQhNMlVxE24MWVmTCcQgsxPh4JKOyRJwc";
        int LastUpdateID = 0;
        string response;
        int ID;

        public void SendMessage(string Message)
        {
            webClient.DownloadString("https://api.telegram.org/bot" + Token + "/sendMessage?chat_id=" + ID + "&text=" + Message);
        }

        //https://api.telegram.org/bot848538853:AAFQhNMlVxE24MWVmTCcQgsxPh4JKOyRJwc/getUpdates 349870760  418714401

        private void Form1_Load(object sender, EventArgs e)
        {
            //SendMessage("zhopa");

            response = webClient.DownloadString("https://api.telegram.org/bot" + Token + "/getUpdates?offset=" + (LastUpdateID));
            if (response.Length > 23)
            {
                var N = JSON.Parse(response);
                foreach (JSONNode r in N["result"].AsArray)
                {
                    LastUpdateID = r["update_id"].AsInt + 1;
                    string UserMess = r["message"]["text"];
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //SendMessage("Юра, Юра, вредный хуй");

            //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=birthday;Integrated Security=True";
            //string sqlExpression = $"INSERT INTO Users (Uname, DateOfBirth) VALUES ('{Text}', '{("yyyy-MM-dd")}')";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand(sqlExpression, connection);
            //    int number = command.ExecuteNonQuery();
            //    Console.WriteLine("Добавлено объектов: {0}", number);
            //}
            //Console.Read();

                response = webClient.DownloadString("https://api.telegram.org/bot" + Token + "/getUpdates?offset=" + (LastUpdateID));
            if (response.Length > 23)
            {
                var N = JSON.Parse(response);
                foreach (JSONNode r in N["result"].AsArray)
                {
                    LastUpdateID = r["update_id"].AsInt + 1;
                    string UserMess = r["message"]["text"];
                    ID = r["message"]["from"]["id"].AsInt;

                    //SendMessage(ID.ToString());

                    if (UserMess == "1")
                    {
                        //SendMessage("Юра, Юра, вредный хуй");
                        using (Connect.Model1 db = new Connect.Model1())
                        {
                            //Connect.Users users = db.Users.Find(1);
                            var str = db.Users.Select(c => c.Uname).FirstOrDefault();
                            SendMessage(str.ToString());
                        }
                    }
                    else if (UserMess == "2")
                    {
                        SendMessage("Юра, Юра, хрен моржовый. Юра, Юра, вредный хуй");

                        Model1 context = new Model1();
                        DateTime date1 = new DateTime(2015, 7, 20);

                        Users customer = new Users
                        {
                            Uname = "Иван",
                            Upassword = "Иванов",
                            DateOfBirth = date1
                        };

                        // Добавить в DbSet
                        context.Users.Add(customer);

                        // Сохранить изменения в базе данных
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
