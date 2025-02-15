namespace FoodMacanoDesktop.Views.Encargues.Web
{
    partial class EditarWebView
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblNumeroEncargue = new System.Windows.Forms.Label();
            this.txtNumeroEncargue = new System.Windows.Forms.TextBox();
            this.lblFechaEncargue = new System.Windows.Forms.Label();
            this.dtpFechaEncargue = new System.Windows.Forms.DateTimePicker();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cboProductos = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.Controls.Add(this.lblNumeroEncargue, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtNumeroEncargue, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblFechaEncargue, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.dtpFechaEncargue, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblCantidad, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.numCantidad, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblProducto, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.cboProductos, 1, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(460, 160);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblNumeroEncargue
            // 
            this.lblNumeroEncargue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNumeroEncargue.AutoSize = true;
            this.lblNumeroEncargue.Location = new System.Drawing.Point(3, 12);
            this.lblNumeroEncargue.Name = "lblNumeroEncargue";
            this.lblNumeroEncargue.Size = new System.Drawing.Size(52, 15);
            this.lblNumeroEncargue.TabIndex = 0;
            this.lblNumeroEncargue.Text = "Número:";
            // 
            // txtNumeroEncargue
            // 
            this.txtNumeroEncargue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroEncargue.Enabled = false;
            this.txtNumeroEncargue.Location = new System.Drawing.Point(141, 8);
            this.txtNumeroEncargue.Name = "txtNumeroEncargue";
            this.txtNumeroEncargue.Size = new System.Drawing.Size(316, 23);
            this.txtNumeroEncargue.TabIndex = 1;
            // 
            // lblFechaEncargue
            // 
            this.lblFechaEncargue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFechaEncargue.AutoSize = true;
            this.lblFechaEncargue.Location = new System.Drawing.Point(3, 52);
            this.lblFechaEncargue.Name = "lblFechaEncargue";
            this.lblFechaEncargue.Size = new System.Drawing.Size(41, 15);
            this.lblFechaEncargue.TabIndex = 2;
            this.lblFechaEncargue.Text = "Fecha:";
            // 
            // dtpFechaEncargue
            // 
            this.dtpFechaEncargue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaEncargue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEncargue.Location = new System.Drawing.Point(141, 48);
            this.dtpFechaEncargue.Name = "dtpFechaEncargue";
            this.dtpFechaEncargue.Size = new System.Drawing.Size(316, 23);
            this.dtpFechaEncargue.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(3, 92);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(58, 15);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            this.numCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numCantidad.Location = new System.Drawing.Point(141, 88);
            this.numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(316, 23);
            this.numCantidad.TabIndex = 5;
            this.numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblProducto
            // 
            this.lblProducto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(3, 132);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(59, 15);
            this.lblProducto.TabIndex = 6;
            this.lblProducto.Text = "Producto:";
            // 
            // cboProductos
            // 
            this.cboProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductos.FormattingEnabled = true;
            this.cboProductos.Location = new System.Drawing.Point(141, 128);
            this.cboProductos.Name = "cboProductos";
            this.cboProductos.Size = new System.Drawing.Size(316, 23);
            this.cboProductos.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnGuardar);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(282, 178);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 31);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(99, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 25);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(5, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 25);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // EditarWebView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 221);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarWebView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Encargue";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblNumeroEncargue;
        private System.Windows.Forms.TextBox txtNumeroEncargue;
        private System.Windows.Forms.Label lblFechaEncargue;
        private System.Windows.Forms.DateTimePicker dtpFechaEncargue;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cboProductos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}