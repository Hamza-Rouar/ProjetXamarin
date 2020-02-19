using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Api.Dtos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace ProjetXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lieu : ContentPage
    {
        LieuViewModel lieuVM;

        public Lieu()
        {
            InitializeComponent();
            BindingContext = this.lieuVM = new LieuViewModel();
        }

      
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (lieuVM.Items.Count == 0)
                lieuVM.LoadCommand.Execute(null);
        }
       /* async void Déconnecter(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        */
    }
}