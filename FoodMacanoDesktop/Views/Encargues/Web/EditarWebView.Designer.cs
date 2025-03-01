namespace FoodMacanoDesktop.Views.Encargues.Web
{
    partial class EditarWebView
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
            txtCliente = new TextBox();
            label1 = new Label();
            dtpFecha = new DateTimePicker();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            txtTotal = new TextBox();
            label3 = new Label();
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
            btnVolver.Location = new Point(46, 33);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(35, 33);
            btnVolver.TabIndex = 70;
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
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
            txtCliente.TabIndex = 69;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Maroon;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(281, 56);
            label1.Name = "label1";
            label1.Size = new Size(61, 21);
            label1.TabIndex = 64;
            label1.Text = "Cliente:";
            // 
            // dtpFecha
            // 
            dtpFecha.Anchor = AnchorStyles.Top;
            dtpFecha.Location = new Point(281, 136);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(241, 23);
            dtpFecha.TabIndex = 63;
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
            btnGuardar.TabIndex = 71;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleRight;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top;
            txtTotal.BackColor = Color.FromArgb(64, 64, 64);
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Font = new Font("Segoe UI", 11F);
            txtTotal.ForeColor = Color.White;
            txtTotal.Location = new Point(364, 96);
            txtTotal.Margin = new Padding(1);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(158, 27);
            txtTotal.TabIndex = 73;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.Maroon;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(281, 102);
            label3.Name = "label3";
            label3.Size = new Size(45, 21);
            label3.TabIndex = 72;
            label3.Text = "Total:";
            // 
            // EditarWebView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 688);
            Controls.Add(txtTotal);
            Controls.Add(label3);
            Controls.Add(btnGuardar);
            Controls.Add(btnVolver);
            Controls.Add(txtCliente);
            Controls.Add(label1);
            Controls.Add(dtpFecha);
            Name = "EditarWebView";
            Text = "EditarWebMovil";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FontAwesome.Sharp.IconButton btnVolver;
        private TextBox txtCliente;
        private Label label1;
        private DateTimePicker dtpFecha;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox txtTotal;
        private Label label3;
    }
}