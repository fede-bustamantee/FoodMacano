namespace FoodMacanoDesktop.Views.Encargues
{
    partial class EncarguesView
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
            panelEncargue = new Panel();
            lblFecha = new Label();
            lblDatosEncargue = new Label();
            listBoxEncargues = new ListBox();
            btnCancelar = new FontAwesome.Sharp.IconButton();
            panelEncargue.SuspendLayout();
            SuspendLayout();
            // 
            // panelEncargue
            // 
            panelEncargue.Controls.Add(lblFecha);
            panelEncargue.Controls.Add(lblDatosEncargue);
            panelEncargue.Controls.Add(listBoxEncargues);
            panelEncargue.Controls.Add(btnCancelar);
            panelEncargue.Location = new Point(130, 31);
            panelEncargue.Name = "panelEncargue";
            panelEncargue.Size = new Size(566, 375);
            panelEncargue.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(101, 77);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "label2";
            // 
            // lblDatosEncargue
            // 
            lblDatosEncargue.AutoSize = true;
            lblDatosEncargue.ForeColor = Color.IndianRed;
            lblDatosEncargue.Location = new Point(101, 53);
            lblDatosEncargue.Name = "lblDatosEncargue";
            lblDatosEncargue.Size = new Size(38, 15);
            lblDatosEncargue.TabIndex = 4;
            lblDatosEncargue.Text = "label1";
            // 
            // listBoxEncargues
            // 
            listBoxEncargues.FormattingEnabled = true;
            listBoxEncargues.ItemHeight = 15;
            listBoxEncargues.Location = new Point(101, 35);
            listBoxEncargues.Name = "listBoxEncargues";
            listBoxEncargues.Size = new Size(361, 244);
            listBoxEncargues.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.Location = new Point(217, 299);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(134, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar Encargue";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EncarguesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelEncargue);
            Name = "EncarguesView";
            Text = "EncarguesView";
            panelEncargue.ResumeLayout(false);
            panelEncargue.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncargue;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private Label lblFecha;
        private Label lblDatosEncargue;
        private ListBox listBoxEncargues;
    }
}