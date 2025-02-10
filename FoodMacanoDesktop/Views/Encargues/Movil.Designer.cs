namespace FoodMacanoDesktop.Views.Encargues
{
    partial class Movil
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // DataGridView
            this.dataGridViewEncargues = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEncargues)).BeginInit();

            // 
            // dataGridViewEncargues
            // 
            this.dataGridViewEncargues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEncargues.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEncargues.Name = "dataGridViewEncargues";
            this.dataGridViewEncargues.RowHeadersWidth = 51;
            this.dataGridViewEncargues.RowTemplate.Height = 29;
            this.dataGridViewEncargues.Size = new System.Drawing.Size(800, 450);
            this.dataGridViewEncargues.TabIndex = 0;
            this.dataGridViewEncargues.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEncargues_CellDoubleClick);

            // 
            // Movil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewEncargues);
            this.Name = "Movil";
            this.Text = "Encargues";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEncargues)).EndInit();

            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEncargues;
    }
}