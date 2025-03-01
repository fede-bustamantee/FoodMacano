namespace FoodMacanoDesktop.Views.ShowInActivity
{
    public partial class ActivityView : Form
    {
        public string Message
        {
            set
            {
                lblMessage.Text = value; // Asigna el valor al Label que muestra el mensaje
            }
        }
        public ActivityView()
        {
            InitializeComponent();

            this.TopMost = true; // Hace que la ventana esté siempre visible por encima de las demás
        }
    }
}