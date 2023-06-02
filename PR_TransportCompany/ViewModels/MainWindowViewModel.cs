using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PR_TransportCompany.Models;
using PR_TransportCompany.Views;
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
            dbContext = new TransportCompanyContext();
            dbContext.Users.Load();
            dbContext.Routes.Load();
            Products = dbContext.Routes.Local.ToObservableCollection();
        }
        public MainWindowViewModel(User user) : this()
        {
            this.user = user;
        }
        public void Save ()
        {
            dbContext.SaveChanges();
        }
        public void Change ()
        {

        }
        public void Update ()
        {

        }
        public void Delete ()
        {
            Products.Remove(SelectedProduct);
        }
        public Product SelectedProduct { get; set; }
        private TransportCompanyContext dbContext;
        public void Create()
        {
            Product newProduct = new Product();
            MainEditWindow editProducts = new MainEditWindow();
            Products.Add(newProduct);
            editProducts.DataContext = new MainEditWindowViewModel(newProduct, editProducts);
            editProducts.ShowDialog(Owner);
            editProducts.Closed += (sender, args) =>
            {
                ReloadWindow();
            };
        }
        public void ReloadWindow ()
        {
            var old = Products;
            Products = null;
            Products = old;
        }
        }

        
        
    }
}