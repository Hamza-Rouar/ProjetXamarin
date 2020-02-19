using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using ProjetXamarin.ServiceRest;
using Storm.Mvvm;
using TD.Api.Dtos;
using Xamarin.Forms;

namespace ProjetXamarin
{
    class LieuViewModel:ViewModelBase
    {
        public bool IsRefreshing { get; set; }
        public bool Refresh { get; set; }
        public ObservableCollection<PlaceItemSummary> Items { get; set; }
        public Command LoadCommand { get; set; }
        public RestService rest;
        public LieuViewModel()
        {
            rest = new RestService();
            Items = new ObservableCollection<PlaceItemSummary>();
            LoadCommand = new Command(async () => await ExecuteCommand());
        }
        public async Task<bool> ExecuteCommand()
        {
            Items.Clear();
            var items = await rest.RefreshDataAsync();
            foreach (var item in items)
            {
                string image_url = "https://td-api.julienmialon.com/images/"+ item.ImageId;
                item.ImageUrl = image_url;
                Items.Add(item);
            }
            return true;
        }
    }
}
