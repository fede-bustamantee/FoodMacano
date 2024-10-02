namespace FoodMacanoDesktop.Views.DatosDelNegocio
{
    partial class DatosView
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
            lblDireccion = new Label();
            lblTelefono = new Label();
            listViewHorarios = new ListView();
            lblWhatsapp = new Label();
            lblFacebook = new Label();
            lblInstagram = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(109, 62);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(38, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "label1";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(109, 105);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(38, 15);
            lblDireccion.TabIndex = 1;
            lblDireccion.Text = "label2";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(109, 146);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(38, 15);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "label3";
            // 
            // listViewHorarios
            // 
            listViewHorarios.Location = new Point(189, 202);
            listViewHorarios.Name = "listViewHorarios";
            listViewHorarios.Size = new Size(357, 213);
            listViewHorarios.TabIndex = 3;
            listViewHorarios.UseCompatibleStateImageBehavior = false;
            // 
            // lblWhatsapp
            // 
            lblWhatsapp.AutoSize = true;
            lblWhatsapp.Location = new Point(619, 146);
            lblWhatsapp.Name = "lblWhatsapp";
            lblWhatsapp.Size = new Size(38, 15);
            lblWhatsapp.TabIndex = 6;
            lblWhatsapp.Text = "label3";
            // 
            // lblFacebook
            // 
            lblFacebook.AutoSize = true;
            lblFacebook.Location = new Point(619, 105);
            lblFacebook.Name = "lblFacebook";
            lblFacebook.Size = new Size(38, 15);
            lblFacebook.TabIndex = 5;
            lblFacebook.Text = "label2";
            // 
            // lblInstagram
            // 
            lblInstagram.AutoSize = true;
            lblInstagram.Location = new Point(619, 62);
            lblInstagram.Name = "lblInstagram";
            lblInstagram.Size = new Size(38, 15);
            lblInstagram.TabIndex = 4;
            lblInstagram.Text = "label1";
            // 
            // DatosView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWhatsapp);
            Controls.Add(lblFacebook);
            Controls.Add(lblInstagram);
            Controls.Add(listViewHorarios);
            Controls.Add(lblTelefono);
            Controls.Add(lblDireccion);
            Controls.Add(lblNombre);
            Name = "DatosView";
            Text = "DatosView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblDireccion;
        private Label lblTelefono;
        private ListView listViewHorarios;
        private Label lblWhatsapp;
        private Label lblFacebook;
        private Label lblInstagram;
    }
}