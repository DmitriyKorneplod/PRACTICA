using Microsoft.EntityFrameworkCore;
using PR_TransportCompany.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace PR_TransportCompany.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Route> _products;
        public ObservableCollection<Route> Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
        public User user { get; set; }
        public MainWindowViewModel()
        {
            TransportCompanyContext dbContext = new TransportCompanyContext();
            dbContext.Users.Load();
            dbContext.Routes.Load();
            Products = dbContext.Routes.Local.ToObservableCollection();
        }
        public MainWindowViewModel(User user) : this()
        {
            this.user = user;
        }
    }
}