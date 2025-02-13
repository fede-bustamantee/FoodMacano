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
            txtCategoria = new TextBox();
            label2 = new Label();
            txtProducto = new TextBox();
            label1 = new Label();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            txtImagen = new TextBox();
            label3 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            txtCalorias = new TextBox();
            label5 = new Label();
            txtCalidad = new TextBox();
            label6 = new Label();
            txtDescripcionCorta = new TextBox();
            label7 = new Label();
            txtDescripcionLarga = new TextBox();
            label8 = new Label();
            cboCategorias = new ComboBox();
            SuspendLayout();
            // 
            // txtCategoria
            // 
            txtCategoria.Enabled = false;
            txtCategoria.Font = new Font("Segoe UI", 11F);
            txtCategoria.Location = new Point(329, 28);
            txtCategoria.Margin = new Padding(1);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(225, 27);
            txtCategoria.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(243, 32);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 23;
            label2.Text = "Categoria:";
            // 
            // txtProducto
            // 
            txtProducto.Font = new Font("Segoe UI", 11F);
            txtProducto.Location = new Point(329, 74);
            txtProducto.Margin = new Padding(1);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(225, 27);
            txtProducto.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(243, 77);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 21;
            label1.Text = "Producto:";
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnCancelar.IconSize = 30;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(424, 379);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 30);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnGuardar.IconSize = 30;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(283, 379);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(111, 30);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtImagen
            // 
            txtImagen.Font = new Font("Segoe UI", 11F);
            txtImagen.Location = new Point(329, 114);
            txtImagen.Margin = new Padding(1);
            txtImagen.Name = "txtImagen";
            txtImagen.Size = new Size(225, 27);
            txtImagen.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(243, 117);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 25;
            label3.Text = "Imagen:";
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Segoe UI", 11F);
            txtPrecio.Location = new Point(329, 152);
            txtPrecio.Margin = new Padding(1);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(225, 27);
            txtPrecio.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(243, 155);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 27;
            label4.Text = "Precio:";
            // 
            // txtCalorias
            // 
            txtCalorias.Font = new Font("Segoe UI", 11F);
            txtCalorias.Location = new Point(331, 231);
            txtCalorias.Margin = new Padding(1);
            txtCalorias.Name = "txtCalorias";
            txtCalorias.Size = new Size(225, 27);
            txtCalorias.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(245, 234);
            label5.Margin = new Padding(1, 0, 1, 0);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 31;
            label5.Text = "Calorias:";
            // 
            // txtCalidad
            // 
            txtCalidad.Font = new Font("Segoe UI", 11F);
            txtCalidad.Location = new Point(331, 193);
            txtCalidad.Margin = new Padding(1);
            txtCalidad.Name = "txtCalidad";
            txtCalidad.Size = new Size(225, 27);
            txtCalidad.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(245, 196);
            label6.Margin = new Padding(1, 0, 1, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 20);
            label6.TabIndex = 29;
            label6.Text = "Calidad:";
            // 
            // txtDescripcionCorta
            // 
            txtDescripcionCorta.Font = new Font("Segoe UI", 11F);
            txtDescripcionCorta.Location = new Point(331, 272);
            txtDescripcionCorta.Margin = new Padding(1);
            txtDescripcionCorta.Name = "txtDescripcionCorta";
            txtDescripcionCorta.Size = new Size(225, 27);
            txtDescripcionCorta.TabIndex = 34;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(190, 275);
            label7.Margin = new Padding(1, 0, 1, 0);
            label7.Name = "label7";
            label7.Size = new Size(130, 20);
            label7.TabIndex = 33;
            label7.Text = "Descripcion Corta:";
            // 
            // txtDescripcionLarga
            // 
            txtDescripcionLarga.Font = new Font("Segoe UI", 11F);
            txtDescripcionLarga.Location = new Point(331, 321);
            txtDescripcionLarga.Margin = new Padding(1);
            txtDescripcionLarga.Name = "txtDescripcionLarga";
            txtDescripcionLarga.Size = new Size(225, 27);
            txtDescripcionLarga.TabIndex = 36;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F);
            label8.Location = new Point(184, 321);
            label8.Margin = new Padding(1, 0, 1, 0);
            label8.Name = "label8";
            label8.Size = new Size(131, 20);
            label8.TabIndex = 35;
            label8.Text = "Descripcion Larga:";
            // 
            // cboCategorias
            // 
            cboCategorias.FormattingEnabled = true;
            cboCategorias.Location = new Point(329, 29);
            cboCategorias.Name = "cboCategorias";
            cboCategorias.Size = new Size(225, 23);
            cboCategorias.TabIndex = 37;
            cboCategorias.SelectedIndexChanged += cboCategorias_SelectedIndexChanged;
            // 
            // AgregarEditarProductoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboCategorias);
            Controls.Add(txtDescripcionLarga);
            Controls.Add(label8);
            Controls.Add(txtDescripcionCorta);
            Controls.Add(label7);
            Controls.Add(txtCalorias);
            Controls.Add(label5);
            Controls.Add(txtCalidad);
            Controls.Add(label6);
            Controls.Add(txtPrecio);
            Controls.Add(label4);
            Controls.Add(txtImagen);
            Controls.Add(label3);
            Controls.Add(txtCategoria);
            Controls.Add(label2);
            Controls.Add(txtProducto);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Name = "AgregarEditarProductoView";
            Text = "AgregarEditarProductoView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCategoria;
        private Label label2;
        private TextBox txtProducto;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox txtImagen;
        private Label label3;
        private TextBox txtPrecio;
        private Label label4;
        private TextBox txtCalorias;
        private Label label5;
        private TextBox txtCalidad;
        private Label label6;
        private TextBox txtDescripcionCorta;
        private Label label7;
        private TextBox txtDescripcionLarga;
        private Label label8;
        private ComboBox cboCategorias;
    }
}