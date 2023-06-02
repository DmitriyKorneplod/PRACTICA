using Microsoft.CodeAnalysis;
using PR_TransportCompany.Models;
using PR_TransportCompany.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_TransportCompany.ViewModels
{
    public class MainEditWindowViewModel : ViewModelBase
    {
        public MainEditWindowViewModel()
        {

        }
        private Product _product = new Product () ;
        public Product product 
        {
            get => _product;
            set => this.RaiseAndSetIfChanged(ref _product, value);
        }
        public MainEditWindow Owner ;
        public MainEditWindowViewModel( MainEditWindow owner )
        {
            Owner = owner ;
        }
        public MainEditWindowViewModel( MainEditWindow owner, Product product ) : this(owner)
        {
            this.product = product ;
        }
        public void OK()
        {
            Owner.Close();

        }

    }
}
