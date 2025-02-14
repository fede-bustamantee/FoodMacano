namespace FoodMacanoDesktop.Views.Encargues
{
    partial class MovilView
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
            panel2 = new Panel();
            btnRefresh = new Button();
            labelTotal = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            dataGridViewEncargues = new DataGridView();
            cboFecha = new ComboBox();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEncargues).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(labelTotal);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 388);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 40);
            panel2.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Location = new Point(1288, -52);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 25);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Actualizar";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(12, 13);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(117, 15);
            labelTotal.TabIndex = 1;
            labelTotal.Text = "Total de encargues: 0";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // dataGridViewEncargues
            // 
            dataGridViewEncargues.AllowUserToAddRows = false;
            dataGridViewEncargues.AllowUserToDeleteRows = false;
            dataGridViewEncargues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEncargues.Location = new Point(31, 66);
            dataGridViewEncargues.Name = "dataGridViewEncargues";
            dataGridViewEncargues.ReadOnly = true;
            dataGridViewEncargues.Size = new Size(668, 308);
            dataGridViewEncargues.TabIndex = 4;
            // 
            // cboFecha
            // 
            cboFecha.FormattingEnabled = true;
            cboFecha.Location = new Point(265, 23);
            cboFecha.Name = "cboFecha";
            cboFecha.Size = new Size(121, 23);
            cboFecha.TabIndex = 5;
            cboFecha.SelectedIndexChanged += cboFecha_SelectedIndexChanged;
            // 
            // MovilView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboFecha);
            Controls.Add(dataGridViewEncargues);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            MinimumSize = new Size(816, 489);
            Name = "MovilView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualizador de Encargues Móviles";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEncargues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridView dataGridViewEncargues;
        private ComboBox cboFecha;
    }
}