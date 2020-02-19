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
    public partial class InscriptionClient : ContentPage
    {
        InscriptionViewModel inscriptionVM;
        public InscriptionClient()
        {
            InitializeComponent();
            BindingContext = this.inscriptionVM = new InscriptionViewModel();
        }

        async void SubmitInscription(Object sender, EventArgs e)
        {
            bool value = await this.inscriptionVM.InscriptionAction(sender, e);
            if (value)
            {
               await Navigation.PopAsync();   
            }
        }
    }
}