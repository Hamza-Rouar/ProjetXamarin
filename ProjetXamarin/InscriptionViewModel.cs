using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjetXamarin.ServiceRest;
using Storm.Mvvm;
using TD.Api.Dtos;

namespace ProjetXamarin
{
    class InscriptionViewModel:ViewModelBase
    {
        private string _erreur;
        public RestService rest;
        public RegisterRequest RequestRegister { get; set; }

        public string LabelErreur
        {
            get => _erreur;
            set => SetProperty(ref _erreur, value);
        }

        public InscriptionViewModel()
        {
            rest = new RestService();
            RequestRegister = new RegisterRequest();

        }
        public async Task<bool> InscriptionAction(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RequestRegister.FirstName) || string.IsNullOrEmpty(RequestRegister.LastName) || string.IsNullOrEmpty(RequestRegister.Email)  || string.IsNullOrEmpty(RequestRegister.Password))
            {
                LabelErreur = "Un ou plusieurs champs manquants!";
                return await Task.FromResult(false);
            }
            LoginResult result = await rest.Inscription(RequestRegister);
            App.Result = result;
            return await Task.FromResult(true);
        }
    }
}
