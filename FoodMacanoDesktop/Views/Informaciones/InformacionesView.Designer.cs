namespace FoodMacanoDesktop.Views.Informaciones
{
    partial class InformacionesView
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
            lblNombre = new Label();
            picImagen = new PictureBox();
            txtDescripcion = new RichTextBox();
            panelPrincipal = new Panel();
            lblFecha = new Label();
            btnRegresar = new Button();
            panelSeparador = new Panel();
            lblTituloDescripcion = new Label();
            panelImagen = new Panel();
            ((System.ComponentModel.ISupportInitialize)picImagen).BeginInit();
            panelPrincipal.SuspendLayout();
            panelImagen.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblNombre.ForeColor = Color.Orange;
            lblNombre.Location = new Point(375, 23);
            lblNombre.MaximumSize = new Size(350, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(236, 32);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Título del Producto";
            // 
            // picImagen
            // 
            picImagen.Dock = DockStyle.Fill;
            picImagen.Location = new Point(12, 12);
            picImagen.Name = "picImagen";
            picImagen.Size = new Size(306, 306);
            picImagen.SizeMode = PictureBoxSizeMode.Zoom;
            picImagen.TabIndex = 0;
            picImagen.TabStop = false;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDescripcion.BackColor = Color.FromArgb(248, 249, 250);
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Font = new Font("Segoe UI", 11F);
            txtDescripcion.ForeColor = Color.Orange;
            txtDescripcion.Location = new Point(375, 160);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(394, 250);
            txtDescripcion.TabIndex = 4;
            txtDescripcion.Text = "";
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.Gray;
            panelPrincipal.Controls.Add(lblFecha);
            panelPrincipal.Controls.Add(btnRegresar);
            panelPrincipal.Controls.Add(panelSeparador);
            panelPrincipal.Controls.Add(lblTituloDescripcion);
            panelPrincipal.Controls.Add(panelImagen);
            panelPrincipal.Controls.Add(txtDescripcion);
            panelPrincipal.Controls.Add(lblNombre);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Padding = new Padding(20);
            panelPrincipal.Size = new Size(800, 450);
            panelPrincipal.TabIndex = 5;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Maroon;
            lblFecha.Font = new Font("Segoe UI", 9F);
            lblFecha.ForeColor = Color.White;
            lblFecha.Location = new Point(375, 80);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(97, 15);
            lblFecha.TabIndex = 10;
            lblFecha.Text = "Actualizado: Hoy";
            // 
            // btnRegresar
            // 
            btnRegresar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegresar.BackColor = Color.FromArgb(240, 240, 240);
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.Font = new Font("Segoe UI", 9F);
            btnRegresar.ForeColor = Color.FromArgb(70, 70, 70);
            btnRegresar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegresar.Location = new Point(715, 23);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(54, 32);
            btnRegresar.TabIndex = 8;
            btnRegresar.Text = "Volver";
            btnRegresar.UseVisualStyleBackColor = false;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // panelSeparador
            // 
            panelSeparador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSeparador.BackColor = Color.Black;
            panelSeparador.Location = new Point(375, 110);
            panelSeparador.Name = "panelSeparador";
            panelSeparador.Size = new Size(394, 2);
            panelSeparador.TabIndex = 7;
            // 
            // lblTituloDescripcion
            // 
            lblTituloDescripcion.AutoSize = true;
            lblTituloDescripcion.BackColor = Color.Maroon;
            lblTituloDescripcion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTituloDescripcion.ForeColor = Color.White;
            lblTituloDescripcion.Location = new Point(375, 128);
            lblTituloDescripcion.Name = "lblTituloDescripcion";
            lblTituloDescripcion.Size = new Size(96, 21);
            lblTituloDescripcion.TabIndex = 6;
            lblTituloDescripcion.Text = "Descripción";
            // 
            // panelImagen
            // 
            panelImagen.Anchor = AnchorStyles.Left;
            panelImagen.BackColor = Color.FromArgb(245, 245, 245);
            panelImagen.Controls.Add(picImagen);
            panelImagen.Location = new Point(30, 35);
            panelImagen.Name = "panelImagen";
            panelImagen.Padding = new Padding(12);
            panelImagen.Size = new Size(330, 330);
            panelImagen.TabIndex = 5;
            // 
            // InformacionesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelPrincipal);
            MinimumSize = new Size(816, 489);
            Name = "InformacionesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle del Producto";
            ((System.ComponentModel.ISupportInitialize)picImagen).EndInit();
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            panelImagen.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
        private Label lblNombre;
        private PictureBox picImagen;
        private RichTextBox txtDescripcion;
        private Panel panelPrincipal;
        private Panel panelImagen;
        private Label lblTituloDescripcion;
        private Panel panelSeparador;
        private Button btnRegresar;
        private Label lblFecha;
    }
}