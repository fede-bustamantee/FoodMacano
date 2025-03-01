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
            dtpFecha = new DateTimePicker();
            panelDetalles = new FlowLayoutPanel();
            DetalleEncargue = new ComboBox();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            label2 = new Label();
            txtTotal = new TextBox();
            txtCliente = new TextBox();
            btnVolver = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            txtDireccion = new TextBox();
            panelDetalles.SuspendLayout();
            SuspendLayout();
            // 
            // dtpFecha
            // 
            dtpFecha.Anchor = AnchorStyles.Top;
            dtpFecha.Location = new Point(281, 188);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(241, 23);
            dtpFecha.TabIndex = 17;
            // 
            // panelDetalles
            // 
            panelDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDetalles.Controls.Add(DetalleEncargue);
            panelDetalles.Location = new Point(46, 232);
            panelDetalles.Name = "panelDetalles";
            panelDetalles.Size = new Size(708, 354);
            panelDetalles.TabIndex = 20;
            // 
            // DetalleEncargue
            // 
            DetalleEncargue.FormattingEnabled = true;
            DetalleEncargue.Location = new Point(3, 3);
            DetalleEncargue.Name = "DetalleEncargue";
            DetalleEncargue.Size = new Size(121, 23);
            DetalleEncargue.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top;
            btnGuardar.BackColor = Color.Orange;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 255, 192);
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Maroon;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 30;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(369, 609);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(88, 38);
            btnGuardar.TabIndex = 21;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Maroon;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(281, 55);
            label1.Name = "label1";
            label1.Size = new Size(61, 21);
            label1.TabIndex = 56;
            label1.Text = "Cliente:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Maroon;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(281, 146);
            label2.Name = "label2";
            label2.Size = new Size(45, 21);
            label2.TabIndex = 57;
            label2.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top;
            txtTotal.BackColor = Color.FromArgb(64, 64, 64);
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Font = new Font("Segoe UI", 11F);
            txtTotal.ForeColor = Color.White;
            txtTotal.Location = new Point(364, 140);
            txtTotal.Margin = new Padding(1);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(158, 27);
            txtTotal.TabIndex = 59;
            // 
            // txtCliente
            // 
            txtCliente.Anchor = AnchorStyles.Top;
            txtCliente.BackColor = Color.FromArgb(64, 64, 64);
            txtCliente.BorderStyle = BorderStyle.FixedSingle;
            txtCliente.Font = new Font("Segoe UI", 11F);
            txtCliente.ForeColor = Color.White;
            txtCliente.Location = new Point(364, 55);
            txtCliente.Margin = new Padding(1);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(158, 27);
            txtCliente.TabIndex = 61;
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
            btnVolver.Location = new Point(46, 33);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(35, 33);
            btnVolver.TabIndex = 62;
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.Maroon;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(281, 101);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 58;
            label3.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.Top;
            txtDireccion.BackColor = Color.FromArgb(64, 64, 64);
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Font = new Font("Segoe UI", 11F);
            txtDireccion.ForeColor = Color.White;
            txtDireccion.Location = new Point(364, 95);
            txtDireccion.Margin = new Padding(1);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(158, 27);
            txtDireccion.TabIndex = 60;
            // 
            // EditarMovilView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 688);
            Controls.Add(btnVolver);
            Controls.Add(txtCliente);
            Controls.Add(txtDireccion);
            Controls.Add(txtTotal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(panelDetalles);
            Controls.Add(dtpFecha);
            Name = "EditarMovilView";
            Text = "EditarMovilView";
            panelDetalles.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtpFecha;
        private FlowLayoutPanel panelDetalles;
        private ComboBox DetalleEncargue;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private Label label1;
        private Label label2;
        private TextBox txtTotal;
        private TextBox txtCliente;
        private FontAwesome.Sharp.IconButton btnVolver;
        private Label label3;
        private TextBox txtDireccion;
    }
}