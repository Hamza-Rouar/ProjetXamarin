using System;
using System.Collections.Generic;
using System.Text;
using TD.Api.Dtos;
using System.Threading.Tasks;
namespace ProjetXamarin.ServiceRest
{
    interface IRestService
    {
        Task<List<PlaceItemSummary>> RefreshDataAsync();
        Task<LoginResult> Connexion(LoginRequest login);
        Task<LoginResult> Inscription(RegisterRequest register);
    }
}
