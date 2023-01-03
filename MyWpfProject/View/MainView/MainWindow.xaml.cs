using MyWpfProject.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Input;
using MyWpfProject.View.MainView.MyFinanceView;
using MyWpfProject.View.MainView.ProfileEditorView;
using MyWpfProject.View.MainView.ProfileView;
using MyWpfProject.View.MainView.ToDoListView;
using MyWpfProject.View.MainView.Sidebar;

namespace MyWpfProject
{
    public partial class MainWindow : Window
    {
        private User user;
        private List<MyTask> myTasks = new List<MyTask>();
        private List<Purpose> purposes = new List<Purpose>();
        private bool isSidebarOpen = false;
        public static MainWindow MainWin { get; set; }
        public MainWindow(User user)
        {
            AddFromDBExistingEntries();
            AddFromDBExisttingPurposes();

            InitializeComponent();

            MainWin = this;
            this.user = user;
            mainContetnControll.Content = new ProfileControl(user, myTasks);
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
        }

        private void AddFromDBExisttingPurposes()
        {
            int numberRecordsInList = purposes.Count;

            if (numberRecordsInList == 0)
            {
                DB dataBase = new DB();
                dataBase.OpenConnection();

                DataTable purposesTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Purposes", dataBase.Connection);
                adapter.Fill(purposesTable);

                int numberOfRecordsInDB = purposesTable.Rows.Count;

                if (numberOfRecordsInDB != 0)
                    GoReaderPurposes(dataBase);
            }
        }

        private void GoReaderPurposes(DB dataBase)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand selectCommand = new SqlCommand("SELECT * FROM Purposes", dataBase.Connection);
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Purpose purpose = new Purpose();

                    if (reader.GetName(0) == "id")
                        purpose.ID = reader.GetInt32(0);
                    if (reader.GetName(1) == "title")
                        purpose.Title = reader.GetString(1);
                    if (reader.GetName(2) == "_discription")
                        purpose.Discription = reader.GetString(2);
                    if (reader.GetName(3) == "finalAmountMony")
                        purpose.FinalAmountMony = reader.GetInt32(3);
                    if (reader.GetName(4) == "collectedAmountMony")
                        purpose.CollectedAmountMony = reader.GetInt32(4);

                    purposes.Add(purpose);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
        private void AddFromDBExistingEntries()
        {
            int numberRecordsInList = myTasks.Count;

            if (numberRecordsInList == 0)
            {
                DB dataBase = new DB();
                dataBase.OpenConnection();

                DataTable myTasksTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM MyTasks", dataBase.Connection);
                adapter.Fill(myTasksTable);
                
                int numberOfRecordsInDB = myTasksTable.Rows.Count;

                if (numberOfRecordsInDB != 0)
                    GoReaderMyTasks(dataBase);
            }
        }
        private void GoReaderMyTasks(DB dataBase)
        {
            SqlDataReader reader = null;

            try
            {
                SqlCommand command = new SqlCommand($" SELECT * FROM MyTasks", dataBase.Connection);
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
        private void ShowProfileContentControll(object sender, RoutedEventArgs e) => mainContetnControll.Content = new ProfileControl(user, myTasks);
        private void ShowToDoListControll(object sender, RoutedEventArgs e) => mainContetnControll.Content = new ToDoListControl(myTasks);
        private void SettingsProfileWindowShow(object sender, RoutedEventArgs e)
        {
            if (!SettingsProfileWindow.WindowOpen)
            {
                SettingsProfileWindow settingsProfileWindow = new SettingsProfileWindow(user);

                SettingsProfileWindow.WindowOpen = true;
                settingsProfileWindow.Show();

                settingsProfileWindow.Closed += (s, a) =>
                {
                    SettingsProfileWindow.WindowOpen = false;
                    mainContetnControll.Content = new ProfileControl(user, myTasks);
                };
            }
        }
        private void ShowMyFinanceControll(object sender, RoutedEventArgs e)=> mainContetnControll.Content = new MyFinanceControl(purposes);
        private void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
        private void CollapseWindow(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                WindowState = WindowState.Minimized;
            else if (WindowState == WindowState.Minimized)
                WindowState = WindowState.Maximized;
        }
        private void ResizeMainWindow(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;              
            }                    
            else         
                WindowState = WindowState.Maximized;
            
        }
        private void OpenSidebar(object sender, RoutedEventArgs e)
        {
            if (isSidebarOpen)
                sidebarContentControl.Content = null;
            else
            {
                sidebarContentControl.Content = new SidebarControl();
                isSidebarOpen = true;
            }

        }
        private void CloseSidebar(object sender, MouseButtonEventArgs e)
        {
            if (isSidebarOpen) 
            {
                sidebarContentControl.Content = null;
                isSidebarOpen= false;
            }
        }
        private void Drag(object sender, RoutedEventArgs e)
        {
           if (Mouse.LeftButton == MouseButtonState.Pressed)
               MainWin.DragMove();
        }
    }
}

