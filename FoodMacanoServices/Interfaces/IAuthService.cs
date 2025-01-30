using FoodMacanoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoServices.Interfaces
{
    public interface IAuthService
    {
        Task<FirebaseSignInResponse> GetCurrentUser();
        Task SetCurrentUser(FirebaseSignInResponse user, string authMethod = "email");
        bool IsAuthenticated();
        string GetCurrentUserId();
        Task<string> GetCurrentUserToken();
        void Logout();
    }
}
