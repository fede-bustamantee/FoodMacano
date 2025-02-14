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
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // cboProductos
            // 
            cboProductos.FormattingEnabled = true;
            cboProductos.Location = new Point(294, 91);
            cboProductos.Name = "cboProductos";
            cboProductos.Size = new Size(210, 23);
            cboProductos.TabIndex = 0;
            // 
            // txtMesa
            // 
            txtMesa.Font = new Font("Segoe UI", 11F);
            txtMesa.Location = new Point(292, 132);
            txtMesa.Margin = new Padding(1);
            txtMesa.Name = "txtMesa";
            txtMesa.Size = new Size(212, 27);
            txtMesa.TabIndex = 38;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(294, 173);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(210, 23);
            nudCantidad.TabIndex = 51;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.Location = new Point(361, 235);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 52;
            btnGuardar.Text = "iconButton1";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // AgregarEditarEncargueView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(nudCantidad);
            Controls.Add(txtMesa);
            Controls.Add(cboProductos);
            Name = "AgregarEditarEncargueView";
            Text = "AgregarEditarEncargueView";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboProductos;
        private TextBox txtMesa;
        private NumericUpDown nudCantidad;
        private FontAwesome.Sharp.IconButton btnGuardar;
    }
}