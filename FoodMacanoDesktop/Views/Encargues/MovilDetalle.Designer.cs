namespace FoodMacanoDesktop.Views.Encargues
{
    partial class MovilDetalle
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            labelId = new Label();
            btnCerrar = new Button();
            dataGridViewDetalles = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalles).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelId);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(600, 60);
            panel1.TabIndex = 2;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            labelId.Location = new Point(12, 15);
            labelId.Name = "labelId";
            labelId.Size = new Size(133, 30);
            labelId.TabIndex = 0;
            labelId.Text = "Encargue #0";
            // 
            // btnCerrar
            // 
            btnCerrar.DialogResult = DialogResult.OK;
            btnCerrar.Location = new Point(488, 413);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 25);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            // 
            // dataGridViewDetalles
            // 
            dataGridViewDetalles.AllowUserToAddRows = false;
            dataGridViewDetalles.AllowUserToDeleteRows = false;
            dataGridViewDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetalles.Location = new Point(12, 66);
            dataGridViewDetalles.Name = "dataGridViewDetalles";
            dataGridViewDetalles.ReadOnly = true;
            dataGridViewDetalles.Size = new Size(567, 346);
            dataGridViewDetalles.TabIndex = 4;
            // 
            // EncargueDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(dataGridViewDetalles);
            Controls.Add(panel1);
            Controls.Add(btnCerrar);
            Name = "EncargueDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalles del Encargue";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalles).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridViewDetalles;
    }
}