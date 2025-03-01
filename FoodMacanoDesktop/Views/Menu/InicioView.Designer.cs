namespace FoodMacanoDesktop.Views.Menu
{
    partial class InicioView
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
            PanelFormulario = new Panel();
            pictureBox2 = new PictureBox();
            PanelFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // PanelFormulario
            // 
            PanelFormulario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelFormulario.BackColor = Color.Gray;
            PanelFormulario.Controls.Add(pictureBox2);
            PanelFormulario.Location = new Point(-128, -123);
            PanelFormulario.Name = "PanelFormulario";
            PanelFormulario.Size = new Size(1057, 696);
            PanelFormulario.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = Properties.Resources.MACANO1;
            pictureBox2.Location = new Point(378, 241);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(308, 189);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // InicioView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PanelFormulario);
            Name = "InicioView";
            Text = "InicioView";
            PanelFormulario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelFormulario;
        private PictureBox pictureBox2;
    }
}