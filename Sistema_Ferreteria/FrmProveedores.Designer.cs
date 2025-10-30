namespace Sistema_Ferreteria
{
    partial class FrmProveedores
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
            this.gboAvz = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFiltroAvz = new System.Windows.Forms.TextBox();
            this.rbIdProveedor = new System.Windows.Forms.RadioButton();
            this.rbCuil = new System.Windows.Forms.RadioButton();
            this.rbRazonSocial = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFiltroAvanzada = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInactivos = new System.Windows.Forms.Button();
            this.btnACtivos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.txtFiltroSimple = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.gboAvz.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // gboAvz
            // 
            this.gboAvz.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.gboAvz.Controls.Add(this.btnBuscar);
            this.gboAvz.Controls.Add(this.txtFiltroAvz);
            this.gboAvz.Controls.Add(this.rbIdProveedor);
            this.gboAvz.Controls.Add(this.rbCuil);
            this.gboAvz.Controls.Add(this.rbRazonSocial);
            this.gboAvz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboAvz.Location = new System.Drawing.Point(13, 368);
            this.gboAvz.Name = "gboAvz";
            this.gboAvz.Size = new System.Drawing.Size(681, 100);
            this.gboAvz.TabIndex = 33;
            this.gboAvz.TabStop = false;
            this.gboAvz.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(421, 52);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(116, 31);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFiltroAvz
            // 
            this.txtFiltroAvz.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroAvz.Location = new System.Drawing.Point(6, 52);
            this.txtFiltroAvz.Name = "txtFiltroAvz";
            this.txtFiltroAvz.Size = new System.Drawing.Size(359, 31);
            this.txtFiltroAvz.TabIndex = 22;
            // 
            // rbIdProveedor
            // 
            this.rbIdProveedor.AutoSize = true;
            this.rbIdProveedor.Location = new System.Drawing.Point(189, 19);
            this.rbIdProveedor.Name = "rbIdProveedor";
            this.rbIdProveedor.Size = new System.Drawing.Size(106, 20);
            this.rbIdProveedor.TabIndex = 2;
            this.rbIdProveedor.TabStop = true;
            this.rbIdProveedor.Text = "Id Proveedor ";
            this.rbIdProveedor.UseVisualStyleBackColor = true;
            // 
            // rbCuil
            // 
            this.rbCuil.AutoSize = true;
            this.rbCuil.Location = new System.Drawing.Point(119, 19);
            this.rbCuil.Name = "rbCuil";
            this.rbCuil.Size = new System.Drawing.Size(47, 20);
            this.rbCuil.TabIndex = 1;
            this.rbCuil.TabStop = true;
            this.rbCuil.Text = "Cuit";
            this.rbCuil.UseVisualStyleBackColor = true;
            // 
            // rbRazonSocial
            // 
            this.rbRazonSocial.AutoSize = true;
            this.rbRazonSocial.Location = new System.Drawing.Point(6, 19);
            this.rbRazonSocial.Name = "rbRazonSocial";
            this.rbRazonSocial.Size = new System.Drawing.Size(105, 20);
            this.rbRazonSocial.TabIndex = 0;
            this.rbRazonSocial.TabStop = true;
            this.rbRazonSocial.Text = "Razon Social";
            this.rbRazonSocial.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox2.Controls.Add(this.chkFiltroAvanzada);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 42);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // chkFiltroAvanzada
            // 
            this.chkFiltroAvanzada.AutoSize = true;
            this.chkFiltroAvanzada.Location = new System.Drawing.Point(9, 20);
            this.chkFiltroAvanzada.Name = "chkFiltroAvanzada";
            this.chkFiltroAvanzada.Size = new System.Drawing.Size(134, 20);
            this.chkFiltroAvanzada.TabIndex = 1;
            this.chkFiltroAvanzada.Text = "Filtro Avanzado";
            this.chkFiltroAvanzada.UseVisualStyleBackColor = true;
            this.chkFiltroAvanzada.CheckedChanged += new System.EventHandler(this.chkFiltroAvanzada_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox3.Controls.Add(this.btnInactivos);
            this.groupBox3.Controls.Add(this.btnACtivos);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnReiniciar);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboLocalidad);
            this.groupBox3.Controls.Add(this.txtFiltroSimple);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 172);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Busqueda";
            // 
            // btnInactivos
            // 
            this.btnInactivos.Location = new System.Drawing.Point(81, 21);
            this.btnInactivos.Name = "btnInactivos";
            this.btnInactivos.Size = new System.Drawing.Size(85, 22);
            this.btnInactivos.TabIndex = 13;
            this.btnInactivos.Text = "Inactivos";
            this.btnInactivos.UseVisualStyleBackColor = true;
            this.btnInactivos.Click += new System.EventHandler(this.btnInactivos_Click);
            // 
            // btnACtivos
            // 
            this.btnACtivos.Location = new System.Drawing.Point(5, 21);
            this.btnACtivos.Name = "btnACtivos";
            this.btnACtivos.Size = new System.Drawing.Size(70, 22);
            this.btnACtivos.TabIndex = 12;
            this.btnACtivos.Text = "Activos";
            this.btnACtivos.UseVisualStyleBackColor = true;
            this.btnACtivos.Click += new System.EventHandler(this.btnACtivos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Escribe al menos 3 letras de Nombre de Razon Social)";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(436, 140);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(98, 26);
            this.btnReiniciar.TabIndex = 10;
            this.btnReiniciar.Text = "Todos";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Localidad";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(152, 141);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(161, 25);
            this.cboLocalidad.TabIndex = 3;
            this.cboLocalidad.SelectedValueChanged += new System.EventHandler(this.cboLocalidad_SelectedValueChanged);
            // 
            // txtFiltroSimple
            // 
            this.txtFiltroSimple.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroSimple.Location = new System.Drawing.Point(5, 81);
            this.txtFiltroSimple.Name = "txtFiltroSimple";
            this.txtFiltroSimple.Size = new System.Drawing.Size(371, 31);
            this.txtFiltroSimple.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(606, 474);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 33);
            this.btnSalir.TabIndex = 30;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(13, 474);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(88, 33);
            this.btnNuevo.TabIndex = 29;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProveedores.Location = new System.Drawing.Point(13, 179);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(681, 125);
            this.dgvProveedores.TabIndex = 28;
            this.dgvProveedores.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellContentDoubleClick);
            // 
            // FrmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 509);
            this.Controls.Add(this.gboAvz);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvProveedores);
            this.MaximumSize = new System.Drawing.Size(721, 548);
            this.MinimumSize = new System.Drawing.Size(721, 548);
            this.Name = "FrmProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FrmProveedores_Load);
            this.gboAvz.ResumeLayout(false);
            this.gboAvz.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboAvz;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFiltroAvz;
        private System.Windows.Forms.RadioButton rbIdProveedor;
        private System.Windows.Forms.RadioButton rbCuil;
        private System.Windows.Forms.RadioButton rbRazonSocial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkFiltroAvanzada;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInactivos;
        private System.Windows.Forms.Button btnACtivos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.TextBox txtFiltroSimple;
    }
}