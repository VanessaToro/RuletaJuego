
namespace Autentication_FormsApp
{
    partial class Inicio
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
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.cbxUsuario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.lblIdRol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(22, 35);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblNombreUsuario.TabIndex = 0;
            // 
            // cbxUsuario
            // 
            this.cbxUsuario.FormattingEnabled = true;
            this.cbxUsuario.Location = new System.Drawing.Point(25, 112);
            this.cbxUsuario.Name = "cbxUsuario";
            this.cbxUsuario.Size = new System.Drawing.Size(215, 21);
            this.cbxUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(279, 110);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCrearUsuario.Location = new System.Drawing.Point(110, 210);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(194, 36);
            this.btnCrearUsuario.TabIndex = 5;
            this.btnCrearUsuario.Text = "Nuevo Usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = false;
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Location = new System.Drawing.Point(371, 45);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(0, 13);
            this.lblNombreRol.TabIndex = 6;
            // 
            // lblIdRol
            // 
            this.lblIdRol.AutoSize = true;
            this.lblIdRol.Location = new System.Drawing.Point(374, 76);
            this.lblIdRol.Name = "lblIdRol";
            this.lblIdRol.Size = new System.Drawing.Size(0, 13);
            this.lblIdRol.TabIndex = 7;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(409, 323);
            this.Controls.Add(this.lblIdRol);
            this.Controls.Add(this.lblNombreRol);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxUsuario);
            this.Controls.Add(this.lblNombreUsuario);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.ComboBox cbxUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.Label lblIdRol;
    }
}