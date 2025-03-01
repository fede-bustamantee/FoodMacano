namespace FoodMacanoDesktop.Views.Login
{
    partial class IniciarSesionView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IniciarSesionView));
            panel1 = new Panel();
            lblBienvenido = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            lblTitulo = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            chkVerContraseña = new CheckBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnIngresar = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Orange;
            panel1.Controls.Add(lblBienvenido);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 464);
            panel1.TabIndex = 22;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.BackColor = Color.Transparent;
            lblBienvenido.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.Maroon;
            lblBienvenido.Location = new Point(99, 324);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(158, 32);
            lblBienvenido.TabIndex = 1;
            lblBienvenido.Text = "¡Bienvenido!";
            lblBienvenido.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoo1;
            pictureBox1.Location = new Point(75, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Brown;
            panel2.Controls.Add(lblTitulo);
            panel2.Controls.Add(lblEmail);
            panel2.Controls.Add(lblPassword);
            panel2.Controls.Add(chkVerContraseña);
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(btnIngresar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(350, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(478, 464);
            panel2.TabIndex = 23;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(145, 81);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(187, 37);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Iniciar Sesión";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(114, 135);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(113, 15);
            lblEmail.TabIndex = 25;
            lblEmail.Text = "Correo Electrónico:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(114, 188);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(72, 15);
            lblPassword.TabIndex = 24;
            lblPassword.Text = "Contraseña:";
            // 
            // chkVerContraseña
            // 
            chkVerContraseña.AutoSize = true;
            chkVerContraseña.Font = new Font("Segoe UI", 9F);
            chkVerContraseña.ForeColor = Color.White;
            chkVerContraseña.Location = new Point(114, 239);
            chkVerContraseña.Margin = new Padding(2);
            chkVerContraseña.Name = "chkVerContraseña";
            chkVerContraseña.Size = new Size(103, 19);
            chkVerContraseña.TabIndex = 21;
            chkVerContraseña.Text = "Ver contraseña";
            chkVerContraseña.UseVisualStyleBackColor = true;
            chkVerContraseña.CheckedChanged += chkVerContraseña_CheckedChanged_1;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(114, 210);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "123456";
            txtPassword.Size = new Size(250, 25);
            txtPassword.TabIndex = 20;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(114, 161);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "admin@gmail.com";
            txtEmail.Size = new Size(250, 25);
            txtEmail.TabIndex = 18;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(224, 224, 224);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.Black;
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.IconSize = 20;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(248, 276);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 36);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Orange;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.Black;
            btnIngresar.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            btnIngresar.IconColor = Color.Black;
            btnIngresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIngresar.IconSize = 20;
            btnIngresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnIngresar.Location = new Point(145, 276);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(85, 36);
            btnIngresar.TabIndex = 15;
            btnIngresar.Text = "Ingresar";
            btnIngresar.TextAlign = ContentAlignment.MiddleRight;
            btnIngresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click_1;
            // 
            // IniciarSesionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 464);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "IniciarSesionView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FoodMacano - Inicio Sesión";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox chkVerContraseña;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnIngresar;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label lblBienvenido;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblTitulo;
    }
}