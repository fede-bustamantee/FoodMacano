namespace FoodMacanoDesktop.Views.Encargues.Movil
{
    partial class EditarMovilView
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
            txtCliente = new TextBox();
            txtTotal = new TextBox();
            txtDireccion = new TextBox();
            dtpFecha = new DateTimePicker();
            dataGridViewDetalles = new DataGridView();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalles).BeginInit();
            SuspendLayout();
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(332, 39);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(158, 23);
            txtCliente.TabIndex = 0;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(332, 97);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(158, 23);
            txtTotal.TabIndex = 3;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(332, 68);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(158, 23);
            txtDireccion.TabIndex = 4;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(291, 126);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(241, 23);
            dtpFecha.TabIndex = 17;
            // 
            // dataGridViewDetalles
            // 
            dataGridViewDetalles.AllowUserToAddRows = false;
            dataGridViewDetalles.AllowUserToDeleteRows = false;
            dataGridViewDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetalles.Location = new Point(47, 167);
            dataGridViewDetalles.Name = "dataGridViewDetalles";
            dataGridViewDetalles.ReadOnly = true;
            dataGridViewDetalles.Size = new Size(700, 211);
            dataGridViewDetalles.TabIndex = 18;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.Location = new Point(356, 404);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "iconButton1";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // EditarMovilView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(dataGridViewDetalles);
            Controls.Add(dtpFecha);
            Controls.Add(txtDireccion);
            Controls.Add(txtTotal);
            Controls.Add(txtCliente);
            Name = "EditarMovilView";
            Text = "EditarMovilView";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCliente;
        private TextBox txtTotal;
        private TextBox txtDireccion;
        private DateTimePicker dtpFecha;
        private DataGridView dataGridViewDetalles;
        private FontAwesome.Sharp.IconButton btnGuardar;
    }
}