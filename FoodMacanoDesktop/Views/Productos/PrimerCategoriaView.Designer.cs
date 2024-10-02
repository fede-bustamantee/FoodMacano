namespace FoodMacanoDesktop.Views.Productos
{
    partial class PrimerCategoriaView
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
            flowLayoutPanelCarrito = new FlowLayoutPanel();
            txtTotal = new Label();
            btnEncargar = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(1, 43);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(580, 499);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // flowLayoutPanelCarrito
            // 
            flowLayoutPanelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanelCarrito.Location = new Point(12, 53);
            flowLayoutPanelCarrito.Name = "flowLayoutPanelCarrito";
            flowLayoutPanelCarrito.Size = new Size(323, 391);
            flowLayoutPanelCarrito.TabIndex = 4;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Right;
            txtTotal.AutoSize = true;
            txtTotal.Location = new Point(41, 459);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(65, 15);
            txtTotal.TabIndex = 5;
            txtTotal.Text = "Cargando..";
            // 
            // btnEncargar
            // 
            btnEncargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEncargar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEncargar.IconColor = Color.Black;
            btnEncargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEncargar.Location = new Point(108, 476);
            btnEncargar.Name = "btnEncargar";
            btnEncargar.Size = new Size(122, 34);
            btnEncargar.TabIndex = 9;
            btnEncargar.Text = "Encargar";
            btnEncargar.UseVisualStyleBackColor = true;
            btnEncargar.Click += btnEncargar_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(255, 128, 0);
            panel2.Controls.Add(iconButton1);
            panel2.Controls.Add(btnEncargar);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtTotal);
            panel2.Controls.Add(flowLayoutPanelCarrito);
            panel2.Location = new Point(587, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(349, 530);
            panel2.TabIndex = 10;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(268, 882);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(122, 34);
            iconButton1.TabIndex = 8;
            iconButton1.Text = "Encargar";
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(164, 863);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 5;
            label1.Text = "Cargando..";
            // 
            // PrimerCategoriaView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 540);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            Name = "PrimerCategoriaView";
            Text = "PrimerCategoriaView";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanelCarrito;
        private Label txtTotal;
        private FontAwesome.Sharp.IconButton btnEncargar;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label1;
    }
}