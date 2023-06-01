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
        private ObservableCollection<Route> _routes ;
        public ObservableCollection<Route> Routes
        {
            get => _routes;
            set => this.RaiseAndSetIfChanged(ref _routes, value);
        }
        public User user { get; set; }
        public RouteWindowViewModel()
        {
            dbContext = new TransportCompanyContext();
            dbContext.Routes.Load();
            dbContext.Users.Load();
            Routes = dbContext.Routes.Local.ToObservableCollection();
        }
        public RouteWindowViewModel(User user) : this()
        {
            this.user = user;
        }
        public void Save()
        {

        }
        public void Change()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        private TransportCompanyContext dbContext;
    }
}
