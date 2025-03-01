namespace FoodMacanoDesktop.Views.Configuracion
{
    partial class AgregarEditarProductoView
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
            txtProducto = new TextBox();
            txtImagen = new TextBox();
            txtDescripcionLarga = new TextBox();
            txtDescripcionCorta = new TextBox();
            txtCalorias = new TextBox();
            txtCalidad = new TextBox();
            txtPrecio = new TextBox();
            txtCategoria = new TextBox();
            cboCategorias = new ComboBox();
            label17 = new Label();
            label16 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
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
            btnVolver.TabIndex = 54;
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = Color.Silver;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(txtProducto);
            panel1.Controls.Add(txtImagen);
            panel1.Controls.Add(txtDescripcionLarga);
            panel1.Controls.Add(txtDescripcionCorta);
            panel1.Controls.Add(txtCalorias);
            panel1.Controls.Add(txtCalidad);
            panel1.Controls.Add(txtPrecio);
            panel1.Controls.Add(txtCategoria);
            panel1.Controls.Add(cboCategorias);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(213, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(419, 465);
            panel1.TabIndex = 57;
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
            btnGuardar.Location = new Point(163, 409);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 37);
            btnGuardar.TabIndex = 74;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtProducto
            // 
            txtProducto.Anchor = AnchorStyles.Top;
            txtProducto.BackColor = Color.FromArgb(64, 64, 64);
            txtProducto.Font = new Font("Segoe UI", 11F);
            txtProducto.ForeColor = Color.White;
            txtProducto.Location = new Point(163, 84);
            txtProducto.Margin = new Padding(1);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(212, 27);
            txtProducto.TabIndex = 73;
            // 
            // txtImagen
            // 
            txtImagen.Anchor = AnchorStyles.Top;
            txtImagen.BackColor = Color.FromArgb(64, 64, 64);
            txtImagen.Font = new Font("Segoe UI", 11F);
            txtImagen.ForeColor = Color.White;
            txtImagen.Location = new Point(163, 124);
            txtImagen.Margin = new Padding(1);
            txtImagen.Name = "txtImagen";
            txtImagen.Size = new Size(212, 27);
            txtImagen.TabIndex = 72;
            // 
            // txtDescripcionLarga
            // 
            txtDescripcionLarga.Anchor = AnchorStyles.Top;
            txtDescripcionLarga.BackColor = Color.FromArgb(64, 64, 64);
            txtDescripcionLarga.Font = new Font("Segoe UI", 11F);
            txtDescripcionLarga.ForeColor = Color.White;
            txtDescripcionLarga.Location = new Point(163, 335);
            txtDescripcionLarga.Margin = new Padding(1);
            txtDescripcionLarga.Name = "txtDescripcionLarga";
            txtDescripcionLarga.Size = new Size(212, 27);
            txtDescripcionLarga.TabIndex = 71;
            // 
            // txtDescripcionCorta
            // 
            txtDescripcionCorta.Anchor = AnchorStyles.Top;
            txtDescripcionCorta.BackColor = Color.FromArgb(64, 64, 64);
            txtDescripcionCorta.Font = new Font("Segoe UI", 11F);
            txtDescripcionCorta.ForeColor = Color.White;
            txtDescripcionCorta.Location = new Point(163, 286);
            txtDescripcionCorta.Margin = new Padding(1);
            txtDescripcionCorta.Name = "txtDescripcionCorta";
            txtDescripcionCorta.Size = new Size(212, 27);
            txtDescripcionCorta.TabIndex = 70;
            // 
            // txtCalorias
            // 
            txtCalorias.Anchor = AnchorStyles.Top;
            txtCalorias.BackColor = Color.FromArgb(64, 64, 64);
            txtCalorias.Font = new Font("Segoe UI", 11F);
            txtCalorias.ForeColor = Color.White;
            txtCalorias.Location = new Point(163, 245);
            txtCalorias.Margin = new Padding(1);
            txtCalorias.Name = "txtCalorias";
            txtCalorias.Size = new Size(212, 27);
            txtCalorias.TabIndex = 69;
            // 
            // txtCalidad
            // 
            txtCalidad.Anchor = AnchorStyles.Top;
            txtCalidad.BackColor = Color.FromArgb(64, 64, 64);
            txtCalidad.Font = new Font("Segoe UI", 11F);
            txtCalidad.ForeColor = Color.White;
            txtCalidad.Location = new Point(163, 203);
            txtCalidad.Margin = new Padding(1);
            txtCalidad.Name = "txtCalidad";
            txtCalidad.Size = new Size(212, 27);
            txtCalidad.TabIndex = 68;
            // 
            // txtPrecio
            // 
            txtPrecio.Anchor = AnchorStyles.Top;
            txtPrecio.BackColor = Color.FromArgb(64, 64, 64);
            txtPrecio.Font = new Font("Segoe UI", 11F);
            txtPrecio.ForeColor = Color.White;
            txtPrecio.Location = new Point(163, 166);
            txtPrecio.Margin = new Padding(1);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(212, 27);
            txtPrecio.TabIndex = 67;
            // 
            // txtCategoria
            // 
            txtCategoria.Anchor = AnchorStyles.Top;
            txtCategoria.BackColor = Color.FromArgb(64, 64, 64);
            txtCategoria.Font = new Font("Segoe UI", 11F);
            txtCategoria.ForeColor = Color.White;
            txtCategoria.Location = new Point(163, 42);
            txtCategoria.Margin = new Padding(1);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(212, 27);
            txtCategoria.TabIndex = 66;
            // 
            // cboCategorias
            // 
            cboCategorias.Anchor = AnchorStyles.Top;
            cboCategorias.BackColor = Color.FromArgb(64, 64, 64);
            cboCategorias.FlatStyle = FlatStyle.Flat;
            cboCategorias.ForeColor = Color.White;
            cboCategorias.FormattingEnabled = true;
            cboCategorias.Location = new Point(163, 46);
            cboCategorias.Name = "cboCategorias";
            cboCategorias.Size = new Size(212, 23);
            cboCategorias.TabIndex = 65;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top;
            label17.AutoSize = true;
            label17.BackColor = Color.Maroon;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.White;
            label17.Location = new Point(25, 288);
            label17.Name = "label17";
            label17.Size = new Size(133, 21);
            label17.TabIndex = 64;
            label17.Text = "Descripcion Corta";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top;
            label16.AutoSize = true;
            label16.BackColor = Color.Maroon;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.Location = new Point(25, 337);
            label16.Name = "label16";
            label16.Size = new Size(134, 21);
            label16.TabIndex = 63;
            label16.Text = "Descripcion Larga";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.BackColor = Color.Maroon;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(25, 247);
            label14.Name = "label14";
            label14.Size = new Size(66, 21);
            label14.TabIndex = 61;
            label14.Text = "Calorias";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top;
            label13.AutoSize = true;
            label13.BackColor = Color.Maroon;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(25, 209);
            label13.Name = "label13";
            label13.Size = new Size(62, 21);
            label13.TabIndex = 60;
            label13.Text = "Calidad";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.BackColor = Color.Maroon;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(25, 168);
            label12.Name = "label12";
            label12.Size = new Size(53, 21);
            label12.TabIndex = 59;
            label12.Text = "Precio";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.BackColor = Color.Maroon;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(25, 84);
            label11.Name = "label11";
            label11.Size = new Size(73, 21);
            label11.TabIndex = 58;
            label11.Text = "Producto";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.BackColor = Color.Maroon;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(25, 124);
            label10.Name = "label10";
            label10.Size = new Size(62, 21);
            label10.TabIndex = 57;
            label10.Text = "Imagen";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.BackColor = Color.Maroon;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(25, 42);
            label9.Name = "label9";
            label9.Size = new Size(77, 21);
            label9.TabIndex = 56;
            label9.Text = "Categoría";
            // 
            // AgregarEditarProductoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(831, 713);
            Controls.Add(panel1);
            Controls.Add(btnVolver);
            Name = "AgregarEditarProductoView";
            Text = "AgregarEditarProductoView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconButton btnVolver;
        private Panel panel1;
        private Label label17;
        private Label label16;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private ComboBox cboCategorias;
        private TextBox txtCategoria;
        private TextBox txtImagen;
        private TextBox txtDescripcionLarga;
        private TextBox txtDescripcionCorta;
        private TextBox txtCalorias;
        private TextBox txtCalidad;
        private TextBox txtPrecio;
        private TextBox txtProducto;
        private FontAwesome.Sharp.IconButton btnGuardar;
    }
}