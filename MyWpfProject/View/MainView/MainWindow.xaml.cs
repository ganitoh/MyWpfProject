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
using MyWpfProject.View.AuthorizationView;

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
            this.user = user;
            MainWin = this;

            AddFromDBExistingEntries();
            AddFromDBExisttingPurposes();

            InitializeComponent();

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
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Purposes where userId={user.ID}", dataBase.Connection);
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
                SqlCommand selectCommand = new SqlCommand($"SELECT * FROM Purposes where userId={user.ID}", dataBase.Connection);
                reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Purpose purpose = new Purpose();

                    purpose.ID = reader.GetInt32(0);
                    purpose.UserId = reader.GetInt32(1);
                    purpose.Title = reader.GetString(2);
                    purpose.Discription = reader.GetString(3);
                    purpose.FinalAmountMony = reader.GetInt32(4);
                    purpose.CollectedAmountMony = reader.GetInt32(5);

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
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM MyTasks where userId={user.ID}", dataBase.Connection);
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
                SqlCommand command = new SqlCommand($" SELECT * FROM MyTasks where userId={user.ID} ", dataBase.Connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MyTask myTask = new MyTask();

                    
                    myTask.ID = reader.GetInt32(0);
                    myTask.UserId = reader.GetInt32(1);
                    myTask.Title = reader.GetString(2);
                    myTask.Description = reader.GetString(3);
                    myTask.DateCreate = reader.GetDateTime(4);
                    myTask.Deadline = reader.GetDateTime(5);

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
        private void ExitFromApplication(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.authorization = false;
            Properties.Settings.Default.Save();

            AuthorizationWindow authorization = new AuthorizationWindow();
            authorization.Show();
            this.Close();
        }
    }
}

