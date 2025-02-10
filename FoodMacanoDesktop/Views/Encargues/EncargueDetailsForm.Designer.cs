namespace FoodMacanoDesktop.Views.Encargues
{
    partial class EncargueDetailsForm
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
                this.panel1 = new System.Windows.Forms.Panel();
                this.labelId = new System.Windows.Forms.Label();
                this.panelInfo = new System.Windows.Forms.Panel();
                this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.label1 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.labelFecha = new System.Windows.Forms.Label();
                this.labelUsuario = new System.Windows.Forms.Label();
                this.labelEstado = new System.Windows.Forms.Label();
                this.labelTotal = new System.Windows.Forms.Label();
                this.dataGridViewDetalles = new System.Windows.Forms.DataGridView();
                this.btnCerrar = new System.Windows.Forms.Button();

                // panel1
                this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
                this.panel1.Controls.Add(this.labelId);
                this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
                this.panel1.Height = 60;

                // labelId
                this.labelId.AutoSize = true;
                this.labelId.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
                this.labelId.ForeColor = System.Drawing.Color.White;
                this.labelId.Location = new System.Drawing.Point(12, 15);
                this.labelId.Text = "Encargue #0";

                // panelInfo
                this.panelInfo.Controls.Add(this.tableLayoutPanel1);
                this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
                this.panelInfo.Location = new System.Drawing.Point(0, 60);
                this.panelInfo.Height = 100;

                // tableLayoutPanel1
                this.tableLayoutPanel1.ColumnCount = 4;
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
                this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
                this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
                this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
                this.tableLayoutPanel1.Controls.Add(this.labelFecha, 0, 1);
                this.tableLayoutPanel1.Controls.Add(this.labelUsuario, 1, 1);
                this.tableLayoutPanel1.Controls.Add(this.labelEstado, 2, 1);
                this.tableLayoutPanel1.Controls.Add(this.labelTotal, 3, 1);
                this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);

                // Labels
                this.label1.Text = "Fecha:";
                this.label2.Text = "Usuario:";
                this.label3.Text = "Estado:";
                this.label4.Text = "Total:";

                // dataGridViewDetalles
                this.dataGridViewDetalles.AllowUserToAddRows = false;
                this.dataGridViewDetalles.AllowUserToDeleteRows = false;
                this.dataGridViewDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                this.dataGridViewDetalles.BackgroundColor = System.Drawing.Color.White;
                this.dataGridViewDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.dataGridViewDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridViewDetalles.Location = new System.Drawing.Point(12, 172);
                this.dataGridViewDetalles.ReadOnly = true;
                this.dataGridViewDetalles.RowHeadersVisible = false;
                this.dataGridViewDetalles.Size = new System.Drawing.Size(576, 227);

                // btnCerrar
                this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.btnCerrar.Location = new System.Drawing.Point(488, 413);
                this.btnCerrar.Size = new System.Drawing.Size(100, 25);
                this.btnCerrar.Text = "Cerrar";
                this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;

                // Form
                this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(600, 450);
                this.Controls.Add(this.dataGridViewDetalles);
                this.Controls.Add(this.panelInfo);
                this.Controls.Add(this.panel1);
                this.Controls.Add(this.btnCerrar);
                this.MinimumSize = new System.Drawing.Size(616, 489);
                this.Name = "EncargueDetailsForm";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "Detalles del Encargue";

                ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalles)).EndInit();
                this.ResumeLayout(false);
            }

            #endregion

            private System.Windows.Forms.Panel panel1;
            private System.Windows.Forms.Label labelId;
            private System.Windows.Forms.Panel panelInfo;
            private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.Label labelFecha;
            private System.Windows.Forms.Label labelUsuario;
            private System.Windows.Forms.Label labelEstado;
            private System.Windows.Forms.Label labelTotal;
            private System.Windows.Forms.DataGridView dataGridViewDetalles;
            private System.Windows.Forms.Button btnCerrar;
        }
    }