using Microsoft.EntityFrameworkCore;
using PR_TransportCompany.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_TransportCompany.ViewModels
{
    public class RouteWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Route> _Routes ;
        public ObservableCollection<Route> Routes
        {
            get => _Routes;
            set => this.RaiseAndSetIfChanged(ref _Routes, value);
        }
        public User user { get; set; }
        public RouteWindowViewModel()
        {
            TransportCompanyContext dbContext = new TransportCompanyContext();
            dbContext.Routes.Load();
            dbContext.Users.Load();
            Routes = dbContext.Routes.Local.ToObservableCollection();
        }
        public RouteWindowViewModel(User user) : this()
        {
            this.user = user;
        }
    }
}
