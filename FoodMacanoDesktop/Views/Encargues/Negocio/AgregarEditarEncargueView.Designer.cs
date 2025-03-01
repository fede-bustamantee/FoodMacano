namespace FoodMacanoDesktop.Views.Encargues.Negocio
{
    partial class AgregarEditarEncargueView
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
            cboProductos = new ComboBox();
            txtMesa = new TextBox();
            nudCantidad = new NumericUpDown();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            btnVolver = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cboProductos
            // 
            cboProductos.Anchor = AnchorStyles.Top;
            cboProductos.BackColor = Color.FromArgb(64, 64, 64);
            cboProductos.FlatStyle = FlatStyle.Flat;
            cboProductos.ForeColor = Color.White;
            cboProductos.FormattingEnabled = true;
            cboProductos.Location = new Point(98, 89);
            cboProductos.Name = "cboProductos";
            cboProductos.Size = new Size(212, 23);
            cboProductos.TabIndex = 0;
            // 
            // txtMesa
            // 
            txtMesa.Anchor = AnchorStyles.Top;
            txtMesa.BackColor = Color.FromArgb(64, 64, 64);
            txtMesa.Font = new Font("Segoe UI", 11F);
            txtMesa.ForeColor = Color.White;
            txtMesa.Location = new Point(201, 147);
            txtMesa.Margin = new Padding(1);
            txtMesa.Name = "txtMesa";
            txtMesa.Size = new Size(109, 27);
            txtMesa.TabIndex = 38;
            // 
            // nudCantidad
            // 
            nudCantidad.Anchor = AnchorStyles.Top;
            nudCantidad.BackColor = Color.FromArgb(64, 64, 64);
            nudCantidad.ForeColor = Color.White;
            nudCantidad.Location = new Point(201, 221);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(109, 23);
            nudCantidad.TabIndex = 51;
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
            btnGuardar.Location = new Point(169, 270);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 37);
            btnGuardar.TabIndex = 52;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
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
            btnVolver.TabIndex = 53;
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Maroon;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(100, 221);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 54;
            label1.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Maroon;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(98, 149);
            label2.Name = "label2";
            label2.Size = new Size(93, 21);
            label2.TabIndex = 55;
            label2.Text = "N° de Mesa:";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = Color.Silver;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cboProductos);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtMesa);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nudCantidad);
            panel1.Controls.Add(btnGuardar);
            panel1.Location = new Point(208, 161);
            panel1.Name = "panel1";
            panel1.Size = new Size(419, 374);
            panel1.TabIndex = 56;
            // 
            // AgregarEditarEncargueView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(831, 565);
            Controls.Add(panel1);
            Controls.Add(btnVolver);
            Name = "AgregarEditarEncargueView";
            Text = "AgregarEditarEncargueView";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboProductos;
        private TextBox txtMesa;
        private NumericUpDown nudCantidad;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnVolver;
        private Label label1;
        private Label label2;
        private Panel panel1;
    }
}