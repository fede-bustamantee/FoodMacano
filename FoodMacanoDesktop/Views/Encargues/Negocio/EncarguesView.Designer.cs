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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvEncargues = new DataGridView();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            dtpFecha = new DateTimePicker();
            cboMesas = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvEncargues).BeginInit();
            SuspendLayout();
            // 
            // dgvEncargues
            // 
            dgvEncargues.AllowUserToAddRows = false;
            dgvEncargues.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvEncargues.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEncargues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEncargues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEncargues.BackgroundColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Orange;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEncargues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEncargues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.Maroon;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvEncargues.DefaultCellStyle = dataGridViewCellStyle3;
            dgvEncargues.GridColor = Color.Gray;
            dgvEncargues.Location = new Point(57, 80);
            dgvEncargues.Name = "dgvEncargues";
            dgvEncargues.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvEncargues.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvEncargues.RowHeadersVisible = false;
            dgvEncargues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEncargues.Size = new Size(894, 388);
            dgvEncargues.TabIndex = 3;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.BackColor = Color.Orange;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 255, 192);
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.IconChar = FontAwesome.Sharp.IconChar.Pen;
            btnEditar.IconColor = Color.Maroon;
            btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditar.IconSize = 30;
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(783, 490);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(74, 38);
            btnEditar.TabIndex = 14;
            btnEditar.Text = "Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleRight;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminar.BackColor = Color.Orange;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 255, 192);
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 255, 192);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnEliminar.IconColor = Color.Maroon;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 30;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(863, 490);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 38);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextAlign = ContentAlignment.MiddleRight;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(57, 28);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(241, 23);
            dtpFecha.TabIndex = 16;
            // 
            // cboMesas
            // 
            cboMesas.BackColor = Color.Maroon;
            cboMesas.FlatStyle = FlatStyle.Flat;
            cboMesas.ForeColor = Color.White;
            cboMesas.FormattingEnabled = true;
            cboMesas.Location = new Point(316, 28);
            cboMesas.Name = "cboMesas";
            cboMesas.Size = new Size(121, 23);
            cboMesas.TabIndex = 17;
            // 
            // EncarguesView
            // 
            BackColor = Color.Gray;
            ClientSize = new Size(1000, 600);
            Controls.Add(cboMesas);
            Controls.Add(dtpFecha);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvEncargues);
            Name = "EncarguesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Encargues - Food Macano";
            ((System.ComponentModel.ISupportInitialize)dgvEncargues).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridView dgvEncargues;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private DateTimePicker dtpFecha;
        private ComboBox cboMesas;
    }
}