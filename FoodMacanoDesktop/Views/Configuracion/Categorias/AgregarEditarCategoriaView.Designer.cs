namespace FoodMacanoDesktop.Views.Configuracion.Categorias
{
    partial class AgregarEditarCategoriaView
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
            label3 = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            txtIconUrl = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(242, 171);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 41;
            label3.Text = "logo:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.Location = new Point(328, 128);
            txtNombre.Margin = new Padding(1);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(225, 27);
            txtNombre.TabIndex = 40;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(242, 131);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 39;
            label1.Text = "Nombre:";
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnGuardar.IconSize = 30;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(367, 264);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(111, 30);
            btnGuardar.TabIndex = 37;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtIconUrl
            // 
            txtIconUrl.Font = new Font("Segoe UI", 11F);
            txtIconUrl.Location = new Point(328, 168);
            txtIconUrl.Margin = new Padding(1);
            txtIconUrl.Name = "txtIconUrl";
            txtIconUrl.Size = new Size(225, 27);
            txtIconUrl.TabIndex = 42;
            // 
            // AgregarEditarCategoriaView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtIconUrl);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Name = "AgregarEditarCategoriaView";
            Text = "AgregarEditarCategoriaView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrecio;
        private Label label4;
        private TextBox txtImagen;
        private Label label3;
        private TextBox txtNombre;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox txtIconUrl;
    }
}