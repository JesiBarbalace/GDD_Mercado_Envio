namespace MercadoEnvio.ABM_Usuario
{
    partial class AltaUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.cmbRolUsu = new System.Windows.Forms.ComboBox();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.dpNac = new System.Windows.Forms.DateTimePicker();
            this.cmbRubros = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.txtDocE3 = new System.Windows.Forms.TextBox();
            this.txtDocE2 = new System.Windows.Forms.TextBox();
            this.txtDocE1 = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtDoc1 = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbDireccion = new System.Windows.Forms.GroupBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNroCalle = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.gbDatosPersonales.SuspendLayout();
            this.gbDireccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rol";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(102, 13);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(160, 20);
            this.txtUser.TabIndex = 3;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(102, 46);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(160, 20);
            this.txtPass.TabIndex = 4;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // cmbRolUsu
            // 
            this.cmbRolUsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRolUsu.FormattingEnabled = true;
            this.cmbRolUsu.Items.AddRange(new object[] {
            "Cliente",
            "Empresa"});
            this.cmbRolUsu.Location = new System.Drawing.Point(102, 76);
            this.cmbRolUsu.Name = "cmbRolUsu";
            this.cmbRolUsu.Size = new System.Drawing.Size(160, 21);
            this.cmbRolUsu.TabIndex = 5;
            this.cmbRolUsu.SelectedIndexChanged += new System.EventHandler(this.cmbRolUsu_SelectedIndexChanged);
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.dpNac);
            this.gbDatosPersonales.Controls.Add(this.cmbRubros);
            this.gbDatosPersonales.Controls.Add(this.label14);
            this.gbDatosPersonales.Controls.Add(this.label13);
            this.gbDatosPersonales.Controls.Add(this.txtContacto);
            this.gbDatosPersonales.Controls.Add(this.txtDocE3);
            this.gbDatosPersonales.Controls.Add(this.txtDocE2);
            this.gbDatosPersonales.Controls.Add(this.txtDocE1);
            this.gbDatosPersonales.Controls.Add(this.txtRazonSocial);
            this.gbDatosPersonales.Controls.Add(this.txtDoc1);
            this.gbDatosPersonales.Controls.Add(this.txtNombre);
            this.gbDatosPersonales.Controls.Add(this.txtApellido);
            this.gbDatosPersonales.Controls.Add(this.label12);
            this.gbDatosPersonales.Controls.Add(this.label9);
            this.gbDatosPersonales.Controls.Add(this.label8);
            this.gbDatosPersonales.Controls.Add(this.label7);
            this.gbDatosPersonales.Controls.Add(this.label5);
            this.gbDatosPersonales.Controls.Add(this.label4);
            this.gbDatosPersonales.Location = new System.Drawing.Point(31, 123);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(1002, 209);
            this.gbDatosPersonales.TabIndex = 6;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Datos Personales del Usuario";
            // 
            // dpNac
            // 
            this.dpNac.Location = new System.Drawing.Point(143, 159);
            this.dpNac.Name = "dpNac";
            this.dpNac.Size = new System.Drawing.Size(200, 20);
            this.dpNac.TabIndex = 25;
            // 
            // cmbRubros
            // 
            this.cmbRubros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmbRubros.FormattingEnabled = true;
            this.cmbRubros.Location = new System.Drawing.Point(613, 152);
            this.cmbRubros.Name = "cmbRubros";
            this.cmbRubros.Size = new System.Drawing.Size(220, 21);
            this.cmbRubros.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(507, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Rubro";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(501, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Número CUIT";
            // 
            // txtContacto
            // 
            this.txtContacto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtContacto.Enabled = false;
            this.txtContacto.Location = new System.Drawing.Point(613, 113);
            this.txtContacto.MaxLength = 255;
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(160, 20);
            this.txtContacto.TabIndex = 19;
            // 
            // txtDocE3
            // 
            this.txtDocE3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDocE3.Enabled = false;
            this.txtDocE3.Location = new System.Drawing.Point(764, 69);
            this.txtDocE3.MaxLength = 2;
            this.txtDocE3.Name = "txtDocE3";
            this.txtDocE3.Size = new System.Drawing.Size(30, 20);
            this.txtDocE3.TabIndex = 18;
            this.txtDocE3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocE3_KeyPress_1);
            this.txtDocE3.Leave += new System.EventHandler(this.txtDocE3_Leave);
            // 
            // txtDocE2
            // 
            this.txtDocE2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDocE2.Enabled = false;
            this.txtDocE2.Location = new System.Drawing.Point(656, 69);
            this.txtDocE2.MaxLength = 8;
            this.txtDocE2.Name = "txtDocE2";
            this.txtDocE2.Size = new System.Drawing.Size(101, 20);
            this.txtDocE2.TabIndex = 17;
            this.txtDocE2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocE2_KeyPress_1);
            // 
            // txtDocE1
            // 
            this.txtDocE1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDocE1.Enabled = false;
            this.txtDocE1.Location = new System.Drawing.Point(615, 69);
            this.txtDocE1.MaxLength = 2;
            this.txtDocE1.Name = "txtDocE1";
            this.txtDocE1.Size = new System.Drawing.Size(33, 20);
            this.txtDocE1.TabIndex = 16;
            this.txtDocE1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocE1_KeyPress_1);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Location = new System.Drawing.Point(613, 32);
            this.txtRazonSocial.MaxLength = 255;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(366, 20);
            this.txtRazonSocial.TabIndex = 15;
            // 
            // txtDoc1
            // 
            this.txtDoc1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDoc1.Enabled = false;
            this.txtDoc1.Location = new System.Drawing.Point(143, 110);
            this.txtDoc1.MaxLength = 18;
            this.txtDoc1.Name = "txtDoc1";
            this.txtDoc1.Size = new System.Drawing.Size(167, 20);
            this.txtDoc1.TabIndex = 11;
            this.txtDoc1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoc1_KeyPress_1);
            this.txtDoc1.Leave += new System.EventHandler(this.txtDoc1_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(143, 70);
            this.txtNombre.MaxLength = 255;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(307, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(143, 32);
            this.txtApellido.MaxLength = 255;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(307, 20);
            this.txtApellido.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(504, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Contacto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Razón Social";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Fecha de Nacimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Número DNI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Apellido";
            // 
            // gbDireccion
            // 
            this.gbDireccion.Controls.Add(this.txtCiudad);
            this.gbDireccion.Controls.Add(this.label23);
            this.gbDireccion.Controls.Add(this.txtCP);
            this.gbDireccion.Controls.Add(this.label22);
            this.gbDireccion.Controls.Add(this.txtLocalidad);
            this.gbDireccion.Controls.Add(this.label21);
            this.gbDireccion.Controls.Add(this.txtDepto);
            this.gbDireccion.Controls.Add(this.txtPiso);
            this.gbDireccion.Controls.Add(this.label20);
            this.gbDireccion.Controls.Add(this.label19);
            this.gbDireccion.Controls.Add(this.label18);
            this.gbDireccion.Controls.Add(this.txtMail);
            this.gbDireccion.Controls.Add(this.txtTelefono);
            this.gbDireccion.Controls.Add(this.label17);
            this.gbDireccion.Controls.Add(this.label16);
            this.gbDireccion.Controls.Add(this.txtNroCalle);
            this.gbDireccion.Controls.Add(this.txtCalle);
            this.gbDireccion.Controls.Add(this.label15);
            this.gbDireccion.Location = new System.Drawing.Point(31, 357);
            this.gbDireccion.Name = "gbDireccion";
            this.gbDireccion.Size = new System.Drawing.Size(1002, 190);
            this.gbDireccion.TabIndex = 7;
            this.gbDireccion.TabStop = false;
            this.gbDireccion.Text = "Datos de la Dirección";
            // 
            // txtCiudad
            // 
            this.txtCiudad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCiudad.Enabled = false;
            this.txtCiudad.Location = new System.Drawing.Point(664, 88);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(141, 20);
            this.txtCiudad.TabIndex = 17;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(597, 95);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 13);
            this.label23.TabIndex = 16;
            this.label23.Text = "Ciudad";
            // 
            // txtCP
            // 
            this.txtCP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCP.Enabled = false;
            this.txtCP.Location = new System.Drawing.Point(396, 88);
            this.txtCP.MaxLength = 50;
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(100, 20);
            this.txtCP.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(358, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 13);
            this.label22.TabIndex = 14;
            this.label22.Text = "CP";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtLocalidad.Enabled = false;
            this.txtLocalidad.Location = new System.Drawing.Point(100, 88);
            this.txtLocalidad.MaxLength = 255;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(177, 20);
            this.txtLocalidad.TabIndex = 13;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 95);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Localidad";
            // 
            // txtDepto
            // 
            this.txtDepto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDepto.Enabled = false;
            this.txtDepto.Location = new System.Drawing.Point(846, 36);
            this.txtDepto.MaxLength = 50;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(43, 20);
            this.txtDepto.TabIndex = 11;
            // 
            // txtPiso
            // 
            this.txtPiso.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtPiso.Enabled = false;
            this.txtPiso.Location = new System.Drawing.Point(664, 36);
            this.txtPiso.MaxLength = 18;
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(43, 20);
            this.txtPiso.TabIndex = 10;
            this.txtPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPiso_KeyPress_1);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(797, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Depto";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(621, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 13);
            this.label19.TabIndex = 8;
            this.label19.Text = "Piso";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(357, 150);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Mail";
            // 
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMail.Enabled = false;
            this.txtMail.Location = new System.Drawing.Point(396, 143);
            this.txtMail.MaxLength = 255;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(276, 20);
            this.txtMail.TabIndex = 6;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(100, 147);
            this.txtTelefono.MaxLength = 18;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(149, 20);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 150);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Teléfono";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(425, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Nro";
            // 
            // txtNroCalle
            // 
            this.txtNroCalle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNroCalle.Enabled = false;
            this.txtNroCalle.Location = new System.Drawing.Point(465, 36);
            this.txtNroCalle.MaxLength = 18;
            this.txtNroCalle.Name = "txtNroCalle";
            this.txtNroCalle.Size = new System.Drawing.Size(100, 20);
            this.txtNroCalle.TabIndex = 2;
            this.txtNroCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroCalle_KeyPress_1);
            // 
            // txtCalle
            // 
            this.txtCalle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCalle.Enabled = false;
            this.txtCalle.Location = new System.Drawing.Point(71, 36);
            this.txtCalle.MaxLength = 255;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(307, 20);
            this.txtCalle.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Calle";
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(927, 568);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(106, 42);
            this.btnAlta.TabIndex = 8;
            this.btnAlta.Text = "Grabar";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // AltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 622);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.gbDireccion);
            this.Controls.Add(this.gbDatosPersonales);
            this.Controls.Add(this.cmbRolUsu);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaUsuario";
            this.Text = "Alta de Usuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AltaUsuario_Load_1);
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.gbDireccion.ResumeLayout(false);
            this.gbDireccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.ComboBox cmbRolUsu;
        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private System.Windows.Forms.ComboBox cmbRubros;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.TextBox txtDocE3;
        private System.Windows.Forms.TextBox txtDocE2;
        private System.Windows.Forms.TextBox txtDocE1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtDoc1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbDireccion;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNroCalle;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.DateTimePicker dpNac;
    }
}