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
    public class RouteEditWindowViewModel : ViewModelBase
    {

        public RouteEditWindowViewModel()
            {

            }
            private Route _route = new Route();
            public Route route
        {
                get => _route;
                set => this.RaiseAndSetIfChanged(ref _route, value);
            }
            public RouteEditWindow Owner;
            public RouteEditWindowViewModel(RouteEditWindow owner)
            {
                Owner = owner;
            }
            public RouteEditWindowViewModel(RouteEditWindow owner, Route route) : this(owner)
            {
                this.route = route;
            }
            private ObservableCollection<Route> Routes;
            public RouteEditWindowViewModel(RouteEditWindow owner, ObservableCollection<Route> routes) : this(owner)
            {
                this.Routes = routes;
            }
            public void OK()
            {
                Owner.Close();
                if (Routes != null)
                {
                    Routes.Add(route);
                }
            }

        }
    }


