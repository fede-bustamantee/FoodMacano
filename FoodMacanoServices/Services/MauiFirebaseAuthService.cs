using Firebase.Auth;
using FoodMacanoServices.Interfaces;
using FoodMacanoServices.Models;

namespace FoodMacanoServices.Services
{
    public class MauiFirebaseAuthService : IAuthService
    {
        private readonly FirebaseAuthClient _firebaseAuth;
        private FirebaseSignInResponse _currentUser;

        public MauiFirebaseAuthService(FirebaseAuthClient firebaseAuth)
        {
            _firebaseAuth = firebaseAuth ?? throw new ArgumentNullException(nameof(firebaseAuth));
        }

        public async Task<FirebaseSignInResponse> GetCurrentUser()
        {
            if (_currentUser == null)
            {
                var currentUser = _firebaseAuth.User;
                if (currentUser != null)
                {
                    _currentUser = new FirebaseSignInResponse
                    {
                        LocalId = currentUser.Uid,
                        Email = currentUser.Info.Email,
                        DisplayName = currentUser.Info.DisplayName,
                        EmailVerified = currentUser.Info.IsEmailVerified
                    };
                }
            }
            return _currentUser;
        }

        public bool IsAuthenticated() => _currentUser != null;

        public string GetCurrentUserId() => _currentUser?.LocalId;

        public async Task<string> GetCurrentUserToken()
        {
            var currentUser = _firebaseAuth.User;
            if (currentUser == null)
                throw new InvalidOperationException("No hay usuario autenticado");

            return await currentUser.GetIdTokenAsync();
        }
    }
}