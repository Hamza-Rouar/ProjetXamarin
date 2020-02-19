using Storm.Mvvm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnexionClient : ContentPage
    {
        ConnexionViewModel connexionVM;
        public ConnexionClient()
        {
            InitializeComponent();
            BindingContext = this.connexionVM =  new ConnexionViewModel();
        }
        
        async void OnConnexion(object sender, EventArgs e)
        {
            var value = await this.connexionVM.Connexion(sender, e);
            if (value)
            {
                Navigation.InsertPageBefore(new Lieu(), this);
                await Navigation.PopAsync();
            }
        }

        async void OnInscription(object sender, EventArgs e)

        {
            await Navigation.PushAsync(new InscriptionClient());

        }
    }
}