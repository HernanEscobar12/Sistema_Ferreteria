namespace Sistema_Ferreteria
{
    partial class FrmUsuarios
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
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.BtnUserNuevo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(12, 42);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(142, 59);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Listado Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // BtnUserNuevo
            // 
            this.BtnUserNuevo.Location = new System.Drawing.Point(244, 42);
            this.BtnUserNuevo.Name = "BtnUserNuevo";
            this.BtnUserNuevo.Size = new System.Drawing.Size(142, 59);
            this.BtnUserNuevo.TabIndex = 1;
            this.BtnUserNuevo.Text = "Usuario Nuevo";
            this.BtnUserNuevo.UseVisualStyleBackColor = true;
            this.BtnUserNuevo.Click += new System.EventHandler(this.BtnUserNuevo_Click);
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 153);
            this.Controls.Add(this.BtnUserNuevo);
            this.Controls.Add(this.btnUsuarios);
            this.MaximumSize = new System.Drawing.Size(438, 192);
            this.MinimumSize = new System.Drawing.Size(438, 192);
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuarios";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button BtnUserNuevo;
    }
}