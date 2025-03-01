namespace FoodMacanoDesktop.Views.Productos
{
    partial class PorCategoriaView
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
            cboCategorias = new ComboBox();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(1, 103);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(525, 439);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // cboCategorias
            // 
            cboCategorias.BackColor = Color.FromArgb(64, 64, 64);
            cboCategorias.FlatStyle = FlatStyle.Flat;
            cboCategorias.ForeColor = Color.White;
            cboCategorias.FormattingEnabled = true;
            cboCategorias.Location = new Point(280, 43);
            cboCategorias.Name = "cboCategorias";
            cboCategorias.Size = new Size(140, 23);
            cboCategorias.TabIndex = 4;
            // 
            // PorCategoriaView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(930, 540);
            Controls.Add(cboCategorias);
            Controls.Add(flowLayoutPanel1);
            Cursor = Cursors.Hand;
            ForeColor = Color.White;
            Name = "PorCategoriaView";
            Text = "PrimerCategoriaView";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox cboCategorias;
    }
}