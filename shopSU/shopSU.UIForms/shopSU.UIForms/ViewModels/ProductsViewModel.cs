namespace shopSU.UIForms.ViewModels
{
    using shopSU.Common.Models;
    using shopSU.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private ObservableCollection<Product> products;
        
        private ApiService apiService;
        public ObservableCollection<Product> Products
        {
            get => this.products; 
            set => this.SetValue(ref this.products, value);
        }
        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        private async void LoadProducts()
        {
            this.IsRefreshing = true;
            var response = await this.apiService.GetListAsync<Product>(
                "https://shopsuweb.azurewebsites.net",
                "/api",
                "/Products");
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }
            var myProducts = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(myProducts);


        }
    }
}
