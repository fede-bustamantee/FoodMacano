namespace FoodMacanoDesktop.Views.Informaciones
{
    partial class InformacionesView
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
            lblNombre = new Label();
            picImagen = new PictureBox();
            txtDescripcion = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)picImagen).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(522, 66);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "lblNombre";
            // 
            // picImagen
            // 
            picImagen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            picImagen.Location = new Point(22, 66);
            picImagen.Name = "picImagen";
            picImagen.Size = new Size(308, 311);
            picImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            picImagen.TabIndex = 2;
            picImagen.TabStop = false;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtDescripcion.Location = new Point(375, 120);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(394, 291);
            txtDescripcion.TabIndex = 4;
            txtDescripcion.Text = "";
            // 
            // InformacionesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDescripcion);
            Controls.Add(picImagen);
            Controls.Add(lblNombre);
            Name = "InformacionesView";
            Text = "InformacionesView";
            ((System.ComponentModel.ISupportInitialize)picImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private PictureBox picImagen;
        private RichTextBox txtDescripcion;
    }
}