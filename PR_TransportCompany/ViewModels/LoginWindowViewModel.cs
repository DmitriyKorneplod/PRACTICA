using PR_TransportCompany.Models;
using PR_TransportCompany.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace PR_TransportCompany.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        private string _message = string.Empty;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }
        public LoginWindow Owner { get; set; }
        public ReactiveCommand<Unit, Unit> AuthCommand { get; }
        public LoginWindowViewModel(LoginWindow _owner)
        {
            Owner = _owner;
            AuthCommand = ReactiveCommand.Create(Auth);
        }
        public void Auth()
        {
            TransportCompanyContext dbContext = new TransportCompanyContext();
            User? user = dbContext.Users.Where(u => u.Login == Login && u.Password == Password).FirstOrDefault();
            if (user !=null) 
            {
                if (user.Rank == "администратор")
                {
                    OpenProduct(user);
                }
                if (user.Rank == "пользователь")
                {
                    OpenRoute(user);
                }
                else
                {
                    Message = "Неправиильный логин или пароль!";
                }


            }
        }

        private void OpenProduct(User user) 
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(user, mainWindow);
            mainWindow.Show();
            Owner.Close();

        }

        private void OpenRoute(User user)
        {
            RouteWindow routeWindow = new RouteWindow();
            routeWindow.DataContext = new RouteWindowViewModel(user, routeWindow);
            routeWindow.Show();
            Owner.Close();
        }

    }
}
