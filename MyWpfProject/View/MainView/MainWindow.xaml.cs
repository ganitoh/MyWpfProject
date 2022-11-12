﻿using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using MyWpfProject.View.MainView.MyFinanceView;
using MyWpfProject.View.MainView.ProfileEditorView;
using MyWpfProject.View.MainView.ProfileView;
using MyWpfProject.View.MainView.ToDoListView;


namespace MyWpfProject
{
    public partial class MainWindow : Window
    {
        User user;
        private List<MyTask> myTasks = new List<MyTask>();

        public MainWindow(User user)
        {
            AddExistingEntries();

            InitializeComponent();

            this.user = user;
            mainContetnControll.Content = new ProfileControl(user, myTasks);
        }
        private void AddExistingEntries()
        {
            int numberRecordsInList = myTasks.Count;

            if (numberRecordsInList == 0)
            {
                DB dataBase = new DB();
                dataBase.OpenConnection();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM MyTasks", dataBase.Connection);
                adapter.Fill(table);
                int numberOfRecordsInDataBase = table.Rows.Count;

                if (numberOfRecordsInDataBase != 0)
                    GoReader(dataBase);
            }
        }
        async private void GoReader(DB dataBase)
        {
            SqlDataReader reader = null;

            try
            {
                await Task.Run(() =>
                {
                    SqlCommand command = new SqlCommand($"SELECT * FROM MyTasks", dataBase.Connection);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MyTask myTask = new MyTask();

                        if (reader.GetName(0) == "id")
                            myTask.ID = reader.GetInt32(0);
                        if (reader.GetName(1) == "title")
                            myTask.Title = reader.GetString(1);
                        if (reader.GetName(2) == "_description")
                            myTask.Description = reader.GetString(2);
                        if (reader.GetName(3) == "dateCreate")
                            myTask.DateCreate = reader.GetDateTime(3);
                        if (reader.GetName(4) == "deadline")
                            myTask.Deadline = reader.GetDateTime(4);

                        myTasks.Add(myTask);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                dataBase.CloseConnection();
            }
        }
        private void ShowProfileContentControll(object sender, RoutedEventArgs e)
        {
            mainContetnControll.Content = new ProfileControl(user, myTasks);
        }
        private void ShowToDoListControll(object sender, RoutedEventArgs e)
        {
            mainContetnControll.Content = new ToDoListControl(myTasks);
        }
        private void SettingsProfileWindowShow(object sender, RoutedEventArgs e)
        {
            SettingsProfileWindow settingsProfileWindow = new SettingsProfileWindow(user);
            settingsProfileWindow.Show();

            settingsProfileWindow.Closed += (s, a) => { mainContetnControll.Content = new ProfileControl(user, myTasks); };
        }

        private void ShowMyFinanceControll(object sender, RoutedEventArgs e)
        {
            mainContetnControll.Content = new MyFinanceControl();
        }
    }
}

