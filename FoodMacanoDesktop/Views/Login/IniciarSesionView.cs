using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;

namespace FoodMacanoDesktop.Views.Login
{
    public partial class IniciarSesionView : Form
    {
        FirebaseAuthClient firebaseAuthClient;
        public bool loginSuccessfull { get; set; } = false;
        public IniciarSesionView()
        {
            InitializeComponent();
            ConfiguracionFirebase();
        }
        private void ConfiguracionFirebase()
        {


            // Configure...
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyDpXHQyD5bFCjGkuPklXEASuX0B7a-peTE",
                AuthDomain = "foodmacano.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    // Add and configure individual providers
                    new EmailProvider()
                    // ...
                },

            };

            // ...and create your FirebaseAuthClient
            firebaseAuthClient = new FirebaseAuthClient(config);
        }
        private async void btnIngresar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var result = await firebaseAuthClient.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);
                loginSuccessfull = true;
                this.Close();  // Close the login form if login is successful
            }
            catch
            {
                MessageBox.Show("Email o password incorrecto, intentelo nuevamente");
            }
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkVerContraseña_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkVerContraseña.Checked ? '\0' : '*';
        }
    }
}
