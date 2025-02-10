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
            cboMesas = new ComboBox();
            dgvEncargues = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEncargues).BeginInit();
            SuspendLayout();
            // 
            // cboMesas
            // 
            cboMesas.Anchor = AnchorStyles.Top;
            cboMesas.Location = new Point(368, 12);
            cboMesas.Name = "cboMesas";
            cboMesas.Size = new Size(210, 23);
            cboMesas.TabIndex = 0;
            // 
            // dgvEncargues
            // 
            dgvEncargues.AllowUserToAddRows = false;
            dgvEncargues.AllowUserToDeleteRows = false;
            dgvEncargues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEncargues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEncargues.Location = new Point(26, 56);
            dgvEncargues.Name = "dgvEncargues";
            dgvEncargues.ReadOnly = true;
            dgvEncargues.Size = new Size(894, 388);
            dgvEncargues.TabIndex = 3;
            // 
            // EncarguesView
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvEncargues);
            Controls.Add(cboMesas);
            Name = "EncarguesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Encargues - Food Macano";
            ((System.ComponentModel.ISupportInitialize)dgvEncargues).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridView dgvEncargues;
    }
}