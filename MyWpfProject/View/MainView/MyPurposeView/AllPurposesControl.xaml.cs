using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyWpfProject.View.MainView.MyFinanceView
{
    public partial class MyFinanceControl : UserControl
    {
        private List<Purpose> purposes;
        private Purpose removePurpose;
        private Button removeButton;

        public MyFinanceControl(List<Purpose> purposes)
        {
            InitializeComponent();

            this.purposes = purposes;

            foreach (Purpose purpose in purposes)
                AddPurposeShowInfoButton(purpose);          
        }
        private void AddPurposeShowInfoButton(Purpose purpose)
        {
            Button btt = new Button();
            btt.Content = purpose.Title;
            btt.Margin = new Thickness(5);
            btt.Click += (s, e) =>
            { 
                mainContentControl.Content = new PurposeInfoControl(purpose, mainContentControl);
                removeButton = btt;
                removePurpose = purpose;
            };

            mainStackPanel.Children.Add(btt);
        }

        private void AddPurpose(object sender, RoutedEventArgs e)
        {
            if (AddPurposeWindow.IsOpenWindow == false)
            {
                int countPurpose = purposes.Count;

                AddPurposeWindow addPurposeWindow = new AddPurposeWindow(purposes);
                addPurposeWindow.Show();

                addPurposeWindow.Closed += (s, a) => 
                {
                    if (countPurpose != purposes.Count)
                        AddPurposeShowInfoButton(purposes.Last());
                };
            }
        }

        private void RemovePurposeButton(object sender, RoutedEventArgs e)
        {
            if (mainContentControl.Content != null)
            {
                MessageBoxResult result = MessageBox.Show("удалить цель", "information", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (result == MessageBoxResult.Yes)
                {
                    purposes.Remove(removePurpose);
                    mainStackPanel.Children.Remove(removeButton);
                    mainContentControl.Content = null;

                    RemovePurposeFromDB(removePurpose);
                }
            }
        }

        private void RemovePurposeFromDB(Purpose removePurpose)
        {
            DB dataBase = new DB();
            dataBase.OpenConnection();

            SqlCommand removeСommand = new SqlCommand($"DELETE FROM Purposes WHERE id=N'{removePurpose.ID}'", dataBase.Connection);
            removeСommand.ExecuteNonQuery();

            dataBase.CloseConnection();
        }
    }
}
