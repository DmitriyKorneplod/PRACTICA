using Microsoft.EntityFrameworkCore;
using PR_TransportCompany.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace PR_TransportCompany.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
        public User user { get; set; }
        public MainWindowViewModel()
        {
            TransportCompanyContext dbContext = new TransportCompanyContext();
            dbContext.Users.Load();
            dbContext.Products.Load();
            Products = dbContext.Products.Local.ToObservableCollection();
        }
        public MainWindowViewModel(User user) : this()
        {
            this.user = user;
        }
    }
}