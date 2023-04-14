using MyWpfProject.core.abstraction;
using MyWpfProject.core.model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MyWpfProject.View.MainView.MyFinanceView;
using MyWpfProject.View.MainView.ProfileEditorView;
using MyWpfProject.View.MainView.ProfileView;
using MyWpfProject.View.MainView.ToDoListView;
using MyWpfProject.View.MainView.Sidebar;
using MyWpfProject.View.AuthorizationView;
using MyWpfProject.View.MainView.ParserView;
using MyWpfProject.core.DataBaseWorkers;
using MyWpfProject.logger;
using System.Runtime.CompilerServices;

namespace MyWpfProject
{
    public partial class MainWindow : Window
    {
        private User user;
        private List<MyTask> myTasks;
        private List<Purpose> purposes;
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
            if (purposes is null)
            {
                ISelectSqlRequest<List<Purpose>> selectRequest = new PurposeWorkerDB(user.ID);
                purposes = selectRequest.SelectRequest();
            }
        }
        private void AddFromDBExistingEntries()
        {
            if (myTasks is null)
            {
                ISelectSqlRequest<List<MyTask>> selectedRequest = new MyTaskWorkerDB(user.ID);
                myTasks = selectedRequest.SelectRequest();
            }
        }
        private void ShowProfileContentControll(object sender, RoutedEventArgs e) => mainContetnControll.Content = new ProfileControl(user, myTasks);
        private void ShowToDoListControll(object sender, RoutedEventArgs e) => mainContetnControll.Content = new ToDoListControl(myTasks);
        private void ShowMyFinanceControll(object sender, RoutedEventArgs e)=> mainContetnControll.Content = new MyFinanceControl(purposes);
        private void ShowMyParserControll(object sender, RoutedEventArgs e) => mainContetnControll.Content = new ParserControl();
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

