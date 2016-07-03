namespace MercadoEnvio.ABM_Rol
{
    partial class BajaRol
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
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTotalFunc = new System.Windows.Forms.DataGridView();
            this.CheckFunc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FUNC_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FUNCIONALIDADES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGrabarRol = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(36, 30);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(174, 21);
            this.cmbRoles.TabIndex = 0;
            this.cmbRoles.Text = "Seleccionar Rol";
            this.cmbRoles.DropDown += new System.EventHandler(this.cmbRoles_DropDown);
            this.cmbRoles.SelectedIndexChanged += new System.EventHandler(this.cmbRoles_SelectedIndexChanged);
            this.cmbRoles.SelectedValueChanged += new System.EventHandler(this.cmbRoles_SelectedValueChanged);
            this.cmbRoles.Click += new System.EventHandler(this.cmbRoles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listado de Roles";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTotalFunc);
            this.groupBox1.Controls.Add(this.txtNombreRol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(36, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 309);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Rol";
            // 
            // dgvTotalFunc
            // 
            this.dgvTotalFunc.AllowUserToAddRows = false;
            this.dgvTotalFunc.AllowUserToDeleteRows = false;
            this.dgvTotalFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalFunc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckFunc,
            this.FUNC_ID,
            this.FUNCIONALIDADES});
            this.dgvTotalFunc.Location = new System.Drawing.Point(9, 65);
            this.dgvTotalFunc.Name = "dgvTotalFunc";
            this.dgvTotalFunc.Size = new System.Drawing.Size(424, 228);
            this.dgvTotalFunc.TabIndex = 2;
            // 
            // CheckFunc
            // 
            this.CheckFunc.HeaderText = "";
            this.CheckFunc.Name = "CheckFunc";
            this.CheckFunc.ReadOnly = true;
            // 
            // FUNC_ID
            // 
            this.FUNC_ID.HeaderText = "FUNC_ID";
            this.FUNC_ID.Name = "FUNC_ID";
            this.FUNC_ID.Visible = false;
            // 
            // FUNCIONALIDADES
            // 
            this.FUNCIONALIDADES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FUNCIONALIDADES.HeaderText = "FUNCIONALIDADES";
            this.FUNCIONALIDADES.Name = "FUNCIONALIDADES";
            this.FUNCIONALIDADES.ReadOnly = true;
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Enabled = false;
            this.txtNombreRol.Location = new System.Drawing.Point(108, 25);
            this.txtNombreRol.MaxLength = 50;
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(188, 20);
            this.txtNombreRol.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre del Rol";
            // 
            // btnGrabarRol
            // 
            this.btnGrabarRol.Location = new System.Drawing.Point(362, 401);
            this.btnGrabarRol.Name = "btnGrabarRol";
            this.btnGrabarRol.Size = new System.Drawing.Size(128, 44);
            this.btnGrabarRol.TabIndex = 3;
            this.btnGrabarRol.Text = "Eliminar Rol";
            this.btnGrabarRol.UseVisualStyleBackColor = true;
            this.btnGrabarRol.Click += new System.EventHandler(this.btnGrabarRol_Click_1);
            // 
            // BajaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 464);
            this.Controls.Add(this.btnGrabarRol);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRoles);
            this.Name = "BajaRol";
            this.Text = " Baja de rol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalFunc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTotalFunc;
        private System.Windows.Forms.Button btnGrabarRol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckFunc;
        private System.Windows.Forms.DataGridViewTextBoxColumn FUNC_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FUNCIONALIDADES;
    }
}