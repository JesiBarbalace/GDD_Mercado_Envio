namespace MercadoEnvio.ABM_Visibilidad
{
    partial class AltaVisibilidad
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
            this.dgvTotalFunc = new System.Windows.Forms.DataGridView();
            this.VISIBILIDAD_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombreVisi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrabarVisibilidad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Enviotxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Porcentajetxt = new System.Windows.Forms.TextBox();
            this.Costotxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalFunc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTotalFunc
            // 
            this.dgvTotalFunc.AllowUserToAddRows = false;
            this.dgvTotalFunc.AllowUserToDeleteRows = false;
            this.dgvTotalFunc.AllowUserToResizeColumns = false;
            this.dgvTotalFunc.AllowUserToResizeRows = false;
            this.dgvTotalFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalFunc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VISIBILIDAD_DESC});
            this.dgvTotalFunc.Location = new System.Drawing.Point(12, 230);
            this.dgvTotalFunc.Name = "dgvTotalFunc";
            this.dgvTotalFunc.Size = new System.Drawing.Size(404, 115);
            this.dgvTotalFunc.TabIndex = 2;
            this.dgvTotalFunc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTotalFunc_CellContentClick);
            // 
            // VISIBILIDAD_DESC
            // 
            this.VISIBILIDAD_DESC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VISIBILIDAD_DESC.HeaderText = "Descripcion";
            this.VISIBILIDAD_DESC.Name = "VISIBILIDAD_DESC";
            this.VISIBILIDAD_DESC.ReadOnly = true;
            this.VISIBILIDAD_DESC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // txtNombreVisi
            // 
            this.txtNombreVisi.Location = new System.Drawing.Point(9, 42);
            this.txtNombreVisi.MaxLength = 255;
            this.txtNombreVisi.Name = "txtNombreVisi";
            this.txtNombreVisi.Size = new System.Drawing.Size(199, 20);
            this.txtNombreVisi.TabIndex = 1;
            this.txtNombreVisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreVisi_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // btnGrabarVisibilidad
            // 
            this.btnGrabarVisibilidad.Location = new System.Drawing.Point(320, 369);
            this.btnGrabarVisibilidad.Name = "btnGrabarVisibilidad";
            this.btnGrabarVisibilidad.Size = new System.Drawing.Size(134, 42);
            this.btnGrabarVisibilidad.TabIndex = 3;
            this.btnGrabarVisibilidad.Text = "Grabar Nueva Visibilidad";
            this.btnGrabarVisibilidad.UseVisualStyleBackColor = true;
            this.btnGrabarVisibilidad.Click += new System.EventHandler(this.btnGrabarVisibilidad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Enviotxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.Porcentajetxt);
            this.groupBox1.Controls.Add(this.Costotxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvTotalFunc);
            this.groupBox1.Controls.Add(this.txtNombreVisi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 351);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Nueva Visibilidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Visibilidades existentes";
            // 
            // Enviotxt
            // 
            this.Enviotxt.Location = new System.Drawing.Point(9, 184);
            this.Enviotxt.MaxLength = 16;
            this.Enviotxt.Name = "Enviotxt";
            this.Enviotxt.Size = new System.Drawing.Size(199, 20);
            this.Enviotxt.TabIndex = 9;
            this.Enviotxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Enviotxt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Costo de envío (%)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 148);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Posee envío ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Porcentajetxt
            // 
            this.Porcentajetxt.Location = new System.Drawing.Point(12, 122);
            this.Porcentajetxt.MaxLength = 16;
            this.Porcentajetxt.Name = "Porcentajetxt";
            this.Porcentajetxt.Size = new System.Drawing.Size(199, 20);
            this.Porcentajetxt.TabIndex = 6;
            this.Porcentajetxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Porcentajetxt_KeyPress);
            // 
            // Costotxt
            // 
            this.Costotxt.Location = new System.Drawing.Point(12, 81);
            this.Costotxt.MaxLength = 16;
            this.Costotxt.Name = "Costotxt";
            this.Costotxt.Size = new System.Drawing.Size(199, 20);
            this.Costotxt.TabIndex = 5;
            this.Costotxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Costotxt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Grado de visibilidad (%)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Costo por publicar ($)";
            // 
            // AltaVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 423);
            this.Controls.Add(this.btnGrabarVisibilidad);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaVisibilidad";
            this.Text = "AltaVisibilidad";
            this.Load += new System.EventHandler(this.AltaVisibilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalFunc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTotalFunc;
        private System.Windows.Forms.TextBox txtNombreVisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrabarVisibilidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Porcentajetxt;
        private System.Windows.Forms.TextBox Costotxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Enviotxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIBILIDAD_DESC;
        private System.Windows.Forms.Label label5;

    }
}