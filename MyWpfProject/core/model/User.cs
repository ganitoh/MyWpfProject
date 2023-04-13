using System.Runtime.CompilerServices;

namespace MyWpfProject.core.model
{
    public class User
    {
        public int ID { get;  set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get;  set; }
        public string Login { get;  set; }
        public string Password { get; set; }
        public string ProfilePhotoFilePath { get; set; }

        public User(string name, string surname, int age, string email, string login,string password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Login = login;
            Password = password;
        }
        public User()
        {
            
        }

        public void UpdateInfoToUser(User updateData)
        {
            ID = updateData.ID;
            Name = updateData.Name;
            Surname = updateData.Surname;
            Age = updateData.Age;
            Email = updateData.Email;
            Login = updateData.Login;
            Password = updateData.Password;
        }
    }
}
