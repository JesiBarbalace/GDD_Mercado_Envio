namespace MercadoEnvio.ABM_Rol
{
    partial class AltaRol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTotalFunc = new System.Windows.Forms.DataGridView();
            this.CheckFunc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FUNC_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FUNC_DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrabarRol = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTotalFunc);
            this.groupBox1.Controls.Add(this.txtNombreRol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 316);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Nuevo Rol";
            // 
            // dgvTotalFunc
            // 
            this.dgvTotalFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalFunc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckFunc,
            this.FUNC_ID,
            this.FUNC_DESCRIPCION});
            this.dgvTotalFunc.Location = new System.Drawing.Point(12, 70);
            this.dgvTotalFunc.Name = "dgvTotalFunc";
            this.dgvTotalFunc.Size = new System.Drawing.Size(404, 150);
            this.dgvTotalFunc.TabIndex = 2;
            // 
            // CheckFunc
            // 
            this.CheckFunc.Frozen = true;
            this.CheckFunc.HeaderText = "";
            this.CheckFunc.Name = "CheckFunc";
            this.CheckFunc.Width = 50;
            // 
            // FUNC_ID
            // 
            this.FUNC_ID.HeaderText = "FUNC_ID";
            this.FUNC_ID.Name = "FUNC_ID";
            this.FUNC_ID.ReadOnly = true;
            this.FUNC_ID.Visible = false;
            // 
            // FUNC_DESCRIPCION
            // 
            this.FUNC_DESCRIPCION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FUNC_DESCRIPCION.HeaderText = "Funcionalidades";
            this.FUNC_DESCRIPCION.Name = "FUNC_DESCRIPCION";
            this.FUNC_DESCRIPCION.ReadOnly = true;
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(120, 28);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(199, 20);
            this.txtNombreRol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Rol";
            // 
            // btnGrabarRol
            // 
            this.btnGrabarRol.Location = new System.Drawing.Point(332, 364);
            this.btnGrabarRol.Name = "btnGrabarRol";
            this.btnGrabarRol.Size = new System.Drawing.Size(117, 47);
            this.btnGrabarRol.TabIndex = 1;
            this.btnGrabarRol.Text = "Grabar Nuevo Rol";
            this.btnGrabarRol.UseVisualStyleBackColor = true;
            this.btnGrabarRol.Click += new System.EventHandler(this.btnGrabarRol_Click_1);
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 433);
            this.Controls.Add(this.btnGrabarRol);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaRol";
            this.Text = "Alta de Rol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalFunc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTotalFunc;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrabarRol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckFunc;
        private System.Windows.Forms.DataGridViewTextBoxColumn FUNC_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FUNC_DESCRIPCION;
    }
}