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
            dgvDetalles = new DataGridView();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEncargues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
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
            dataGridViewEncargues.Size = new Size(710, 121);
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
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(31, 188);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.Size = new Size(710, 121);
            dgvDetalles.TabIndex = 3;
            // 
            // btnEditar
            // 
            btnEditar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEditar.IconColor = Color.Black;
            btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditar.Location = new Point(309, 357);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.Location = new Point(420, 357);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // WebView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvDetalles);
            Controls.Add(labelTotal);
            Controls.Add(cboFecha);
            Controls.Add(dataGridViewEncargues);
            Name = "WebView";
            Text = "WebView";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEncargues).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewEncargues;
        private ComboBox cboFecha;
        private Label labelTotal;
        private DataGridView dgvDetalles;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
    }
}