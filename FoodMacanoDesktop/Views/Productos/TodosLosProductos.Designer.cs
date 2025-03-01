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
            txtBoxBuscar = new TextBox();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(0, 99);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(499, 428);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // txtBoxBuscar
            // 
            txtBoxBuscar.Location = new Point(278, 36);
            txtBoxBuscar.Multiline = true;
            txtBoxBuscar.Name = "txtBoxBuscar";
            txtBoxBuscar.PlaceholderText = " Buscar";
            txtBoxBuscar.Size = new Size(118, 29);
            txtBoxBuscar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.DimGray;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 20;
            btnBuscar.Location = new Point(393, 36);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(34, 29);
            btnBuscar.TabIndex = 4;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // TodosLosProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(948, 527);
            Controls.Add(btnBuscar);
            Controls.Add(txtBoxBuscar);
            Controls.Add(flowLayoutPanel1);
            Name = "TodosLosProductos";
            Text = "TodosLosProductos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel4;
        private PictureBox pictureBox2;
        private Label label4;
        private Panel panel5;
        private PictureBox pictureBox3;
        private Label label5;
        private Label label6;
        private Panel panel7;
        private PictureBox pictureBox5;
        private Label label8;
        private Label label9;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox txtBoxBuscar;
        private FontAwesome.Sharp.IconButton btnBuscar;
    }
}