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
            btnVolver = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            txtIconUrl = new TextBox();
            txtNombre = new TextBox();
            label11 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Gray;
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 192);
            btnVolver.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            btnVolver.IconColor = Color.Maroon;
            btnVolver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVolver.IconSize = 35;
            btnVolver.Location = new Point(63, 43);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(35, 33);
            btnVolver.TabIndex = 55;
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = Color.Silver;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(txtIconUrl);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(269, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 280);
            panel1.TabIndex = 58;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top;
            btnGuardar.BackColor = Color.Orange;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.Location = new Point(155, 184);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 37);
            btnGuardar.TabIndex = 74;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // txtIconUrl
            // 
            txtIconUrl.Anchor = AnchorStyles.Top;
            txtIconUrl.BackColor = Color.FromArgb(64, 64, 64);
            txtIconUrl.Font = new Font("Segoe UI", 11F);
            txtIconUrl.ForeColor = Color.White;
            txtIconUrl.Location = new Point(155, 107);
            txtIconUrl.Margin = new Padding(1);
            txtIconUrl.Name = "txtIconUrl";
            txtIconUrl.Size = new Size(212, 27);
            txtIconUrl.TabIndex = 73;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top;
            txtNombre.BackColor = Color.FromArgb(64, 64, 64);
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.ForeColor = Color.White;
            txtNombre.Location = new Point(155, 63);
            txtNombre.Margin = new Padding(1);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(212, 27);
            txtNombre.TabIndex = 66;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.BackColor = Color.Maroon;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(51, 113);
            label11.Name = "label11";
            label11.Size = new Size(48, 21);
            label11.TabIndex = 58;
            label11.Text = "Icono";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.BackColor = Color.Maroon;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(16, 65);
            label9.Name = "label9";
            label9.Size = new Size(133, 21);
            label9.TabIndex = 56;
            label9.Text = "Nombe Categoría";
            // 
            // AgregarEditarCategoriaView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(831, 713);
            Controls.Add(panel1);
            Controls.Add(btnVolver);
            Name = "AgregarEditarCategoriaView";
            Text = "AgregarEditarCategoriaView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label4;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnVolver;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox txtIconUrl;
        private TextBox txtNombre;
        private Label label11;
        private Label label9;
    }
}