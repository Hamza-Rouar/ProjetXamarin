using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjetXamarin.ServiceRest;
using Storm.Mvvm;
using TD.Api.Dtos;

namespace ProjetXamarin
{
    class ConnexionViewModel: ViewModelBase
    {
        private string _errMsg;
        public LoginRequest Login { get; set; }
        private RestService rest;

        public string Error
        {
                get => _errMsg;;
            set => SetProperty(ref _errMsg;, value);
        }
        public ConnexionViewModel()
        {
            Login = new LoginRequest();
            rest = new RestService();

        }
      
        public  async Task<bool> Connexion(object sender, EventArgs e)
        {
            var loginResult = await rest.Connexion(Login);

            if (loginResult.ExpiresIn == 0)
            {
                Error = "Identifiant ou mot de passe erroné !";
                return await Task.FromResult(false);
            }
            App.Result = loginResult;
            return await Task.FromResult(true);
        }
       
    }

}
