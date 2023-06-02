using Microsoft.EntityFrameworkCore;
using PR_TransportCompany.Models;
using PR_TransportCompany.Views;
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

        public RouteWindow Owner;
        public RouteWindowViewModel(User user, RouteWindow owner) : this(user)
        {
            this.Owner = owner;
        }

        public RouteWindowViewModel(User user) : this()
        {
            this.user = user;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public void Change()
        {
            RouteEditWindow editRoutes = new RouteEditWindow();
            editRoutes.DataContext = new RouteEditWindowViewModel(editRoutes, SelectedRoute);
            editRoutes.ShowDialog(Owner);
            editRoutes.Closed += (sender, args) =>
            {
                ReloadWindow();
            };
        }
        public void Update()
        {
            var old = Routes;
            Routes = null!;
            Routes = old;
        }
        public void Delete()
        {
            Routes.Remove(SelectedRoute);
        }
        public Route SelectedRoute { get; set; }
        private TransportCompanyContext dbContext;
        public void Create()
        {
            RouteEditWindow editRoutes = new RouteEditWindow();
            editRoutes.DataContext = new RouteEditWindowViewModel(editRoutes, Routes);
            editRoutes.ShowDialog(Owner);
            editRoutes.Closed += (sender, args) =>
            {
                ReloadWindow();
            };
        }
        public void ReloadWindow()
        {
            var old = Routes;
            Routes = null!;
            Routes = old;
        }
        

        
    }
}
