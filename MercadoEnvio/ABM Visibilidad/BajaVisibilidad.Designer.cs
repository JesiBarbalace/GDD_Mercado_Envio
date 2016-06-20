namespace MercadoEnvio.ABM_Visibilidad
{
    partial class BajaVisibilidad
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
            this.label9 = new System.Windows.Forms.Label();
            this.Gradotxt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Enviotxt = new System.Windows.Forms.Label();
            this.Costotxt = new System.Windows.Forms.Label();
            this.Visitxt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboVisi = new System.Windows.Forms.ComboBox();
            this.borrarVisi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.Gradotxt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Enviotxt);
            this.groupBox1.Controls.Add(this.Costotxt);
            this.groupBox1.Controls.Add(this.Visitxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(49, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 309);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Visibilidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Grado";
            // 
            // Gradotxt
            // 
            this.Gradotxt.AutoSize = true;
            this.Gradotxt.Location = new System.Drawing.Point(131, 96);
            this.Gradotxt.Name = "Gradotxt";
            this.Gradotxt.Size = new System.Drawing.Size(0, 13);
            this.Gradotxt.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Envio";
            // 
            // Enviotxt
            // 
            this.Enviotxt.AutoSize = true;
            this.Enviotxt.Location = new System.Drawing.Point(131, 135);
            this.Enviotxt.Name = "Enviotxt";
            this.Enviotxt.Size = new System.Drawing.Size(0, 13);
            this.Enviotxt.TabIndex = 6;
            // 
            // Costotxt
            // 
            this.Costotxt.AutoSize = true;
            this.Costotxt.Location = new System.Drawing.Point(131, 65);
            this.Costotxt.Name = "Costotxt";
            this.Costotxt.Size = new System.Drawing.Size(0, 13);
            this.Costotxt.TabIndex = 4;
            // 
            // Visitxt
            // 
            this.Visitxt.AutoSize = true;
            this.Visitxt.Location = new System.Drawing.Point(131, 33);
            this.Visitxt.Name = "Visitxt";
            this.Visitxt.Size = new System.Drawing.Size(0, 13);
            this.Visitxt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Costo Fijo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre de la Visibilidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Listado de Visibilidad";
            // 
            // comboVisi
            // 
            this.comboVisi.FormattingEnabled = true;
            this.comboVisi.Location = new System.Drawing.Point(49, 29);
            this.comboVisi.Name = "comboVisi";
            this.comboVisi.Size = new System.Drawing.Size(174, 21);
            this.comboVisi.TabIndex = 4;
            this.comboVisi.Text = "Seleccionar Visibilidad";
            this.comboVisi.SelectedIndexChanged += new System.EventHandler(this.comboVisi_SelectedIndexChanged);
            // 
            // borrarVisi
            // 
            this.borrarVisi.Location = new System.Drawing.Point(375, 400);
            this.borrarVisi.Name = "borrarVisi";
            this.borrarVisi.Size = new System.Drawing.Size(128, 44);
            this.borrarVisi.TabIndex = 7;
            this.borrarVisi.Text = "Eliminar Visibilidad";
            this.borrarVisi.UseVisualStyleBackColor = true;
            this.borrarVisi.Click += new System.EventHandler(this.borrarVisi_Click);
            // 
            // BajaVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 457);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboVisi);
            this.Controls.Add(this.borrarVisi);
            this.Name = "BajaVisibilidad";
            this.Text = "Seleccionar Visibilidad";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboVisi;
        private System.Windows.Forms.Button borrarVisi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Gradotxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Enviotxt;
        private System.Windows.Forms.Label Costotxt;
        private System.Windows.Forms.Label Visitxt;
    }
}