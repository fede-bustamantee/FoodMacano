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
            label1 = new Label();
            btnEncargar = new FontAwesome.Sharp.IconButton();
            txtTotal = new Label();
            flowLayoutPanelCarrito = new FlowLayoutPanel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 128, 0);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnEncargar);
            panel2.Controls.Add(txtTotal);
            panel2.Controls.Add(flowLayoutPanelCarrito);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 579);
            panel2.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 432);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Numero de Mesa";
            textBox1.Size = new Size(119, 23);
            textBox1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 31);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 10;
            label1.Text = "Carrito Compras";
            // 
            // btnEncargar
            // 
            btnEncargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEncargar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEncargar.IconColor = Color.Black;
            btnEncargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEncargar.Location = new Point(252, 503);
            btnEncargar.Name = "btnEncargar";
            btnEncargar.Size = new Size(122, 34);
            btnEncargar.TabIndex = 9;
            btnEncargar.Text = "Encargar";
            btnEncargar.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            txtTotal.AutoSize = true;
            txtTotal.Location = new Point(20, 467);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(34, 15);
            txtTotal.TabIndex = 5;
            txtTotal.Text = "$0.00";
            // 
            // flowLayoutPanelCarrito
            // 
            flowLayoutPanelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelCarrito.Location = new Point(20, 72);
            flowLayoutPanelCarrito.Name = "flowLayoutPanelCarrito";
            flowLayoutPanelCarrito.Size = new Size(362, 351);
            flowLayoutPanelCarrito.TabIndex = 4;
            // 
            // CarritoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "CarritoControl";
            Size = new Size(400, 579);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            Dock = DockStyle.Right; 

        }

        #endregion

        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnEncargar;
        private Label txtTotal;
        private FlowLayoutPanel flowLayoutPanelCarrito;
        private Label label1;
        private TextBox textBox1;
    }
}