namespace MercadoEnvio.ABM_Visibilidad
{
    partial class ModificacionVisibilidad
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
            this.comboVisi = new System.Windows.Forms.ComboBox();
            this.txtNombreVisi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGrabarVisi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textEnvioVisi = new System.Windows.Forms.TextBox();
            this.textGradoVisi = new System.Windows.Forms.TextBox();
            this.textCostoVisi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Listado de Visibilidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboVisi
            // 
            this.comboVisi.FormattingEnabled = true;
            this.comboVisi.Location = new System.Drawing.Point(12, 33);
            this.comboVisi.Name = "comboVisi";
            this.comboVisi.Size = new System.Drawing.Size(187, 21);
            this.comboVisi.TabIndex = 5;
            this.comboVisi.Text = "Seleccionar Visibilidad";
            this.comboVisi.SelectedIndexChanged += new System.EventHandler(this.comboVisi_SelectedIndexChanged);
            // 
            // txtNombreVisi
            // 
            this.txtNombreVisi.Location = new System.Drawing.Point(18, 33);
            this.txtNombreVisi.Name = "txtNombreVisi";
            this.txtNombreVisi.Size = new System.Drawing.Size(220, 20);
            this.txtNombreVisi.TabIndex = 1;
            this.txtNombreVisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreVisi_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre de la Visibilidad";
            // 
            // btnGrabarVisi
            // 
            this.btnGrabarVisi.Location = new System.Drawing.Point(394, 422);
            this.btnGrabarVisi.Name = "btnGrabarVisi";
            this.btnGrabarVisi.Size = new System.Drawing.Size(108, 39);
            this.btnGrabarVisi.TabIndex = 8;
            this.btnGrabarVisi.Text = "Modificar Visibilidad";
            this.btnGrabarVisi.UseVisualStyleBackColor = true;
            this.btnGrabarVisi.Click += new System.EventHandler(this.btnGrabarVisi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textEnvioVisi);
            this.groupBox1.Controls.Add(this.textGradoVisi);
            this.groupBox1.Controls.Add(this.textCostoVisi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombreVisi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 209);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de la Visibilidad";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textEnvioVisi
            // 
            this.textEnvioVisi.Location = new System.Drawing.Point(18, 148);
            this.textEnvioVisi.Name = "textEnvioVisi";
            this.textEnvioVisi.Size = new System.Drawing.Size(220, 20);
            this.textEnvioVisi.TabIndex = 9;
            this.textEnvioVisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEnvioVisi_KeyPress);
            // 
            // textGradoVisi
            // 
            this.textGradoVisi.Location = new System.Drawing.Point(18, 109);
            this.textGradoVisi.Name = "textGradoVisi";
            this.textGradoVisi.Size = new System.Drawing.Size(220, 20);
            this.textGradoVisi.TabIndex = 8;
            this.textGradoVisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textGradoVisi_KeyPress);
            // 
            // textCostoVisi
            // 
            this.textCostoVisi.Location = new System.Drawing.Point(18, 70);
            this.textCostoVisi.Name = "textCostoVisi";
            this.textCostoVisi.Size = new System.Drawing.Size(220, 20);
            this.textCostoVisi.TabIndex = 7;
            this.textCostoVisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCostoVisi_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Costo de envío ($)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Grado de Visibilidad (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Costo Fijo ($)";
            // 
            // ModificacionVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboVisi);
            this.Controls.Add(this.btnGrabarVisi);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificacionVisibilidad";
            this.Text = "ModificacionVisibilidad";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboVisi;
        private System.Windows.Forms.TextBox txtNombreVisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGrabarVisi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEnvioVisi;
        private System.Windows.Forms.TextBox textGradoVisi;
        private System.Windows.Forms.TextBox textCostoVisi;
        private System.Windows.Forms.Label label5;
    }
}