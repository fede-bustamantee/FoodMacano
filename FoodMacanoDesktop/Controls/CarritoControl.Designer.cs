namespace FoodMacanoDesktop.Controls
{
    partial class CarritoControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel2 = new Panel();
            textBox1 = new TextBox();
            lblTotalTitle = new Label();
            label1 = new Label();
            btnEncargar = new FontAwesome.Sharp.IconButton();
            txtTotal = new Label();
            flowLayoutPanelCarrito = new FlowLayoutPanel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 0, 0);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(lblTotalTitle);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnEncargar);
            panel2.Controls.Add(txtTotal);
            panel2.Controls.Add(flowLayoutPanelCarrito);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 604);
            panel2.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(20, 465);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = " Número de Mesa";
            textBox1.Size = new Size(120, 25);
            textBox1.TabIndex = 11;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.BackColor = Color.Transparent;
            lblTotalTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.White;
            lblTotalTitle.Location = new Point(20, 500);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(48, 20);
            lblTotalTitle.TabIndex = 12;
            lblTotalTitle.Text = "Total:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.Orange;
            label1.Location = new Point(90, 24);
            label1.Name = "label1";
            label1.Size = new Size(219, 30);
            label1.TabIndex = 10;
            label1.Text = "CARRITO COMPRAS";
            // 
            // btnEncargar
            // 
            btnEncargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEncargar.BackColor = Color.FromArgb(255, 128, 0);
            btnEncargar.Cursor = Cursors.Hand;
            btnEncargar.FlatAppearance.BorderSize = 0;
            btnEncargar.FlatStyle = FlatStyle.Flat;
            btnEncargar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEncargar.ForeColor = Color.White;
            btnEncargar.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            btnEncargar.IconColor = Color.White;
            btnEncargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEncargar.IconSize = 24;
            btnEncargar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEncargar.Location = new Point(206, 501);
            btnEncargar.Name = "btnEncargar";
            btnEncargar.Padding = new Padding(10, 0, 15, 0);
            btnEncargar.Size = new Size(176, 44);
            btnEncargar.TabIndex = 9;
            btnEncargar.Text = "CONFIRMAR";
            btnEncargar.UseVisualStyleBackColor = false;
            btnEncargar.Click += btnEncargar_Click;
            // 
            // txtTotal
            // 
            txtTotal.AutoSize = true;
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.ForeColor = Color.FromArgb(255, 128, 0);
            txtTotal.Location = new Point(75, 499);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(50, 21);
            txtTotal.TabIndex = 5;
            txtTotal.Text = "$0.00";
            // 
            // flowLayoutPanelCarrito
            // 
            flowLayoutPanelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelCarrito.AutoScroll = true;
            flowLayoutPanelCarrito.BackColor = Color.WhiteSmoke;
            flowLayoutPanelCarrito.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelCarrito.Location = new Point(20, 72);
            flowLayoutPanelCarrito.Name = "flowLayoutPanelCarrito";
            flowLayoutPanelCarrito.Size = new Size(362, 351);
            flowLayoutPanelCarrito.TabIndex = 4;
            Dock = DockStyle.Right;
            // 
            // CarritoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "CarritoControl";
            Size = new Size(400, 604);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnEncargar;
        private Label txtTotal;
        private FlowLayoutPanel flowLayoutPanelCarrito;
        private Label label1;
        private TextBox textBox1;
        private Label lblTotalTitle;
    }
}