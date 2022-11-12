using System.Windows.Controls;
using System.Windows.Media;

namespace MyWpfProject.View.MainView.ProfileView
{
    public partial class UserPhotoControl : UserControl
    {
        public UserPhotoControl(string imgFile)
        {
            InitializeComponent();

            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            photo.ImageSource = (ImageSource)imageSourceConverter.ConvertFromString(imgFile);
        }
    }
}
