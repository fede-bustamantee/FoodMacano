namespace FoodMacanoDesktop.Views.Productos
{
    partial class TodosLosProductos
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            txtBoxBuscar = new TextBox();
            txtTotal = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            btnEncargar = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Location = new Point(0, 99);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(605, 428);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(257, 218);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Right;
            pictureBox1.Location = new Point(123, 62);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(29, 128);
            label2.Name = "label2";
            label2.Size = new Size(47, 21);
            label2.TabIndex = 4;
            label2.Text = "$1.22";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(3, 21);
            label1.Name = "label1";
            label1.Size = new Size(127, 21);
            label1.TabIndex = 3;
            label1.Text = "HAMBUEGUESA";
            // 
            // txtBoxBuscar
            // 
            txtBoxBuscar.Location = new Point(3, 37);
            txtBoxBuscar.Name = "txtBoxBuscar";
            txtBoxBuscar.PlaceholderText = "Buscar";
            txtBoxBuscar.Size = new Size(496, 23);
            txtBoxBuscar.TabIndex = 3;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTotal.AutoSize = true;
            txtTotal.ForeColor = Color.Black;
            txtTotal.Location = new Point(15, 433);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(65, 15);
            txtTotal.TabIndex = 5;
            txtTotal.Text = "Cargando..";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Location = new Point(15, 57);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(325, 357);
            flowLayoutPanel2.TabIndex = 6;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(119, 18);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(122, 30);
            iconButton1.TabIndex = 7;
            iconButton1.Text = "Carrito Compras";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // btnEncargar
            // 
            btnEncargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEncargar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEncargar.IconColor = Color.Black;
            btnEncargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEncargar.Location = new Point(119, 452);
            btnEncargar.Name = "btnEncargar";
            btnEncargar.Size = new Size(122, 34);
            btnEncargar.TabIndex = 8;
            btnEncargar.Text = "Encargar";
            btnEncargar.UseVisualStyleBackColor = true;
            btnEncargar.Click += btnEncargar_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(255, 128, 0);
            panel2.Controls.Add(btnEncargar);
            panel2.Controls.Add(txtTotal);
            panel2.Controls.Add(iconButton1);
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Location = new Point(596, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(349, 503);
            panel2.TabIndex = 9;
            // 
            // TodosLosProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 527);
            Controls.Add(panel2);
            Controls.Add(txtBoxBuscar);
            Controls.Add(flowLayoutPanel1);
            Name = "TodosLosProductos";
            Text = "TodosLosProductos";
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel4;
        private PictureBox pictureBox2;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel5;
        private PictureBox pictureBox3;
        private Label label5;
        private Label label6;
        private Panel panel7;
        private PictureBox pictureBox5;
        private Label label8;
        private Label label9;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private TextBox txtBoxBuscar;
        private Label txtTotal;
        private FlowLayoutPanel flowLayoutPanel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnEncargar;
        private Panel panel2;
    }
}