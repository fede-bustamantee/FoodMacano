namespace FoodMacanoDesktop.Views.Encargues
{
    partial class MovilView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvEncargues;

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
            this.dgvEncargues = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncargues)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEncargues
            // 
            this.dgvEncargues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEncargues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEncargues.Location = new System.Drawing.Point(0, 0);
            this.dgvEncargues.Name = "dgvEncargues";
            this.dgvEncargues.Size = new System.Drawing.Size(800, 450);
            this.dgvEncargues.TabIndex = 0;
            this.dgvEncargues.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEncargues_CellDoubleClick);
            // 
            // MovilView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEncargues);
            this.Name = "MovilView";
            this.Text = "Encargues Móviles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncargues)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}