namespace FoodMacanoDesktop.Views.Encargues
{
    partial class WebView
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
            dataGridViewEncargues = new DataGridView();
            cboFecha = new ComboBox();
            labelTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEncargues).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewEncargues
            // 
            dataGridViewEncargues.AllowUserToAddRows = false;
            dataGridViewEncargues.AllowUserToDeleteRows = false;
            dataGridViewEncargues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEncargues.Location = new Point(31, 48);
            dataGridViewEncargues.Name = "dataGridViewEncargues";
            dataGridViewEncargues.ReadOnly = true;
            dataGridViewEncargues.Size = new Size(710, 320);
            dataGridViewEncargues.TabIndex = 0;
            // 
            // cboFecha
            // 
            cboFecha.FormattingEnabled = true;
            cboFecha.Location = new Point(330, 12);
            cboFecha.Name = "cboFecha";
            cboFecha.Size = new Size(121, 23);
            cboFecha.TabIndex = 1;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(60, 402);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(38, 15);
            labelTotal.TabIndex = 2;
            labelTotal.Text = "label1";
            // 
            // WebView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelTotal);
            Controls.Add(cboFecha);
            Controls.Add(dataGridViewEncargues);
            Name = "WebView";
            Text = "WebView";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEncargues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewEncargues;
        private ComboBox cboFecha;
        private Label labelTotal;
    }
}