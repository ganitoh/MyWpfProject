using System.Runtime.CompilerServices;

namespace MyWpfProject.model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User()
        {
            
        }
        public string ProfilePhotoFilePath { get; set; }
    }
}
