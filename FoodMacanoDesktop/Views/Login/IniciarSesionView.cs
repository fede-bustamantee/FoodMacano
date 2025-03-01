using Firebase.Auth.Providers;
using Firebase.Auth;
using FoodMacanoDesktop.Views.ShowInActivity;

namespace FoodMacanoDesktop.Views.Login
{
    public partial class IniciarSesionView : Form
    {
        // Cliente de autenticación de Firebase
        FirebaseAuthClient firebaseAuthClient;

        // Propiedad para indicar si el inicio de sesión fue exitoso
        public bool loginSuccessfull { get; set; } = false;

        public IniciarSesionView()
        {
            InitializeComponent();
            ConfiguracionFirebase();
        }
        private void ConfiguracionFirebase()
        {
            // Configuración de Firebase con la API Key y el proveedor de autenticación
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyDpXHQyD5bFCjGkuPklXEASuX0B7a-peTE",
                AuthDomain = "foodmacano.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider() // Permite el inicio de sesión con email y contraseña
                },
            };

            // Se crea una instancia del cliente
            firebaseAuthClient = new FirebaseAuthClient(config);
        }
        private async void btnIngresar_Click_1(object sender, EventArgs e)
        {
            // Se muestra una pantalla de carga con un mensaje de "Verificando credenciales..."
            var loadingForm = new ActivityView();
            loadingForm.Message = "Verificando credenciales...";
            loadingForm.Show();

            try
            {
                // Intenta iniciar sesión con el email y la contraseña ingresados en los TextBox
                var result = await firebaseAuthClient.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);

                // Si el login es exitoso, se marca la variable loginSuccessfull como verdadera
                loginSuccessfull = true;
                loadingForm.Close();
                this.Close();
            }
            catch
            {
                loadingForm.Close();
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
