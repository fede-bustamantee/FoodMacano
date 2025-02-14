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
            dgvEncargues = new DataGridView();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            dtpFecha = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvEncargues).BeginInit();
            SuspendLayout();
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
            // btnEditar
            // 
            btnEditar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEditar.IconColor = Color.Black;
            btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditar.Location = new Point(433, 464);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 14;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.Location = new Point(544, 464);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.None;
            btnAgregar.IconColor = Color.Black;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.Location = new Point(336, 464);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(336, 12);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(241, 23);
            dtpFecha.TabIndex = 16;
            // 
            // EncarguesView
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(dtpFecha);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
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
        private FontAwesome.Sharp.IconButton btnAgregar;
        private DateTimePicker dtpFecha;
    }
}