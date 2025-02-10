namespace FoodMacanoDesktop.Views.Encargues
{
    partial class EncargueDetallesForm
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

            // Labels
            this.lblEncargueId = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();

            // DataGridView
            this.dataGridViewDetalles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).BeginInit();

            // 
            // Labels
            // 
            this.lblEncargueId.AutoSize = true;
            this.lblEncargueId.Location = new System.Drawing.Point(12, 20);
            this.lblEncargueId.Name = "lblEncargueId";

            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 50);
            this.lblFecha.Name = "lblFecha";

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(12, 80);
            this.lblEstado.Name = "lblEstado";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 110);
            this.lblTotal.Name = "lblTotal";

            // 
            // dataGridViewDetalles
            // 
            this.dataGridViewDetalles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewDetalles.Location = new System.Drawing.Point(0, 150);
            this.dataGridViewDetalles.Name = "dataGridViewDetalles";
            this.dataGridViewDetalles.RowHeadersWidth = 51;
            this.dataGridViewDetalles.RowTemplate.Height = 29;
            this.dataGridViewDetalles.Size = new System.Drawing.Size(800, 300);
            this.dataGridViewDetalles.TabIndex = 0;

            // 
            // EncargueDetallesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEncargueId);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dataGridViewDetalles);
            this.Name = "EncargueDetallesForm";
            this.Text = "Detalles del Encargue";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblEncargueId;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dataGridViewDetalles;
    }
}