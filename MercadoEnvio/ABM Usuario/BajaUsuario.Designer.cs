namespace MercadoEnvio.ABM_Usuario
{
    partial class BajaUsuario
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
            this.txtMailE = new System.Windows.Forms.TextBox();
            this.txtDocE = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.dgvBusqEmp = new System.Windows.Forms.DataGridView();
            this.SELECCIONADOE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RAZONS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HABILITADOE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBusqCli = new System.Windows.Forms.DataGridView();
            this.SELECCIONADO = new System.Windows.Forms.DataGridViewButtonColumn();
            this.APELLIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HABILITADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAMECLI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqCli)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMailE);
            this.groupBox1.Controls.Add(this.txtDocE);
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMail);
            this.groupBox1.Controls.Add(this.txtDoc);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbRoles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 189);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscador";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtMailE
            // 
            this.txtMailE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMailE.Enabled = false;
            this.txtMailE.Location = new System.Drawing.Point(661, 97);
            this.txtMailE.Name = "txtMailE";
            this.txtMailE.Size = new System.Drawing.Size(247, 20);
            this.txtMailE.TabIndex = 15;
            // 
            // txtDocE
            // 
            this.txtDocE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDocE.Enabled = false;
            this.txtDocE.Location = new System.Drawing.Point(661, 67);
            this.txtDocE.Name = "txtDocE";
            this.txtDocE.Size = new System.Drawing.Size(170, 20);
            this.txtDocE.TabIndex = 14;
            this.txtDocE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocE_KeyPress);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Location = new System.Drawing.Point(661, 39);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(247, 20);
            this.txtRazonSocial.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(577, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Mail";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(884, 135);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 45);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(577, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "CUIT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(574, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Razón Social";
            // 
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMail.Enabled = false;
            this.txtMail.Location = new System.Drawing.Point(108, 127);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(269, 20);
            this.txtMail.TabIndex = 9;
            // 
            // txtDoc
            // 
            this.txtDoc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDoc.Enabled = false;
            this.txtDoc.Location = new System.Drawing.Point(108, 97);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(174, 20);
            this.txtDoc.TabIndex = 8;
            this.txtDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoc_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(108, 68);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(269, 20);
            this.txtApellido.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(108, 39);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(269, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rol";
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Items.AddRange(new object[] {
            "Cliente",
            "Empresa"});
            this.cmbRoles.Location = new System.Drawing.Point(423, 15);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(150, 21);
            this.cmbRoles.TabIndex = 0;
            this.cmbRoles.SelectedValueChanged += new System.EventHandler(this.cmbRoles_SelectedValueChanged);
            // 
            // dgvBusqEmp
            // 
            this.dgvBusqEmp.AllowUserToAddRows = false;
            this.dgvBusqEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqEmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SELECCIONADOE,
            this.RAZONS,
            this.DOC,
            this.HABILITADOE,
            this.USERNAME});
            this.dgvBusqEmp.Location = new System.Drawing.Point(11, 207);
            this.dgvBusqEmp.Name = "dgvBusqEmp";
            this.dgvBusqEmp.Size = new System.Drawing.Size(1001, 216);
            this.dgvBusqEmp.TabIndex = 14;
            this.dgvBusqEmp.Visible = false;
            this.dgvBusqEmp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqEmp_CellContentClick);
            // 
            // SELECCIONADOE
            // 
            this.SELECCIONADOE.HeaderText = "";
            this.SELECCIONADOE.Name = "SELECCIONADOE";
            this.SELECCIONADOE.Text = "Eliminar";
            this.SELECCIONADOE.UseColumnTextForButtonValue = true;
            // 
            // RAZONS
            // 
            this.RAZONS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RAZONS.HeaderText = "RAZON SOCIAL";
            this.RAZONS.Name = "RAZONS";
            this.RAZONS.ReadOnly = true;
            // 
            // DOC
            // 
            this.DOC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DOC.HeaderText = "DOCUMENTO";
            this.DOC.Name = "DOC";
            this.DOC.ReadOnly = true;
            // 
            // HABILITADOE
            // 
            this.HABILITADOE.HeaderText = "HABILITADOE";
            this.HABILITADOE.Name = "HABILITADOE";
            this.HABILITADOE.Visible = false;
            // 
            // USERNAME
            // 
            this.USERNAME.HeaderText = "USERNAME";
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Visible = false;
            // 
            // dgvBusqCli
            // 
            this.dgvBusqCli.AllowUserToAddRows = false;
            this.dgvBusqCli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqCli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SELECCIONADO,
            this.APELLIDO,
            this.NOMBRE,
            this.DNI,
            this.HABILITADO,
            this.USERNAMECLI});
            this.dgvBusqCli.Location = new System.Drawing.Point(12, 224);
            this.dgvBusqCli.Name = "dgvBusqCli";
            this.dgvBusqCli.Size = new System.Drawing.Size(1001, 216);
            this.dgvBusqCli.TabIndex = 15;
            this.dgvBusqCli.Visible = false;
            this.dgvBusqCli.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusqCli_CellContentClick);
            // 
            // SELECCIONADO
            // 
            this.SELECCIONADO.HeaderText = "";
            this.SELECCIONADO.Name = "SELECCIONADO";
            this.SELECCIONADO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SELECCIONADO.Text = "Eliminar";
            this.SELECCIONADO.UseColumnTextForButtonValue = true;
            // 
            // APELLIDO
            // 
            this.APELLIDO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.APELLIDO.HeaderText = "Apellido";
            this.APELLIDO.Name = "APELLIDO";
            this.APELLIDO.ReadOnly = true;
            // 
            // NOMBRE
            // 
            this.NOMBRE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NOMBRE.HeaderText = "Nombre";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // HABILITADO
            // 
            this.HABILITADO.HeaderText = "";
            this.HABILITADO.Name = "HABILITADO";
            this.HABILITADO.Visible = false;
            // 
            // USERNAMECLI
            // 
            this.USERNAMECLI.HeaderText = "USERNAMECLI";
            this.USERNAMECLI.Name = "USERNAMECLI";
            this.USERNAMECLI.Visible = false;
            // 
            // BajaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 468);
            this.Controls.Add(this.dgvBusqCli);
            this.Controls.Add(this.dgvBusqEmp);
            this.Controls.Add(this.groupBox1);
            this.Name = "BajaUsuario";
            this.Text = "Baja Usuario";
            this.Load += new System.EventHandler(this.BajaUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqCli)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMailE;
        private System.Windows.Forms.TextBox txtDocE;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.DataGridView dgvBusqEmp;
        private System.Windows.Forms.DataGridView dgvBusqCli;
        private System.Windows.Forms.DataGridViewButtonColumn SELECCIONADOE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAZONS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn HABILITADOE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewButtonColumn SELECCIONADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn APELLIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn HABILITADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAMECLI;
    }
}