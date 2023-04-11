using Microsoft.Win32;
using MyWpfProject.core.model;
using System.Windows;
using System.Windows.Controls;


namespace MyWpfProject.View.MainView.ProfileView
{
    public partial class ButtonAddPhotoControl : UserControl
    {
        User user;
        public ButtonAddPhotoControl(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void AddPhotoButton(object sender, RoutedEventArgs e)
        {
            if (user.ProfilePhotoFilePath != null)
                addPhoto.Content = new UserPhotoControl(user.ProfilePhotoFilePath);
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*GIF;*.IMG)|*.BMP;*.JPG;*GIF;*.IMG|All files(*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                    TryCatchAddPhoto(openFileDialog);
            }
        }
        private void TryCatchAddPhoto(OpenFileDialog openFileDialog)
        {
            border = null;
            try
            {
                user.ProfilePhotoFilePath = openFileDialog.FileName;
                addPhoto.Content = new UserPhotoControl(user.ProfilePhotoFilePath);
            }
            catch
            {
                MessageBox.Show("невозможно открыть выбраныый файл", "ошибка");
            }
        }
    }
}
