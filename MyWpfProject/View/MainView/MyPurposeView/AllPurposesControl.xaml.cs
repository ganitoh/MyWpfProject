using MyWpfProject.core.model;
using MyWpfProject.core.abstraction;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MyWpfProject.core.DataBaseWorkers;
using System.Windows.Documents;

namespace MyWpfProject.View.MainView.MyFinanceView
{
    public partial class MyFinanceControl : UserControl
    {
        private List<Purpose> purposes;
        private Purpose removePurpose;
        private Button removeButton;

        public MyFinanceControl(List<Purpose> purposes)
        {
            this.purposes = purposes ?? new List<Purpose>();

            InitializeComponent();
            
            foreach (Purpose purpose in this.purposes)
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
                    RemovePurposeFromDBAndFromApp();
            }
        }

        private void RemovePurposeFromDBAndFromApp()
        {
            IDeleteSqlRequest<int> deleteSqlRequest = new PurposeWorkerDB();

            if (deleteSqlRequest.DeleteRequest(removePurpose.ID))
            {
                purposes.Remove(removePurpose);
                mainStackPanel.Children.Remove(removeButton);
                mainContentControl.Content = null;
            }
        }
    }
}
