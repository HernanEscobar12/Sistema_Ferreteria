namespace Sistema_Ferreteria
{
    partial class FrmListadoUsuarios
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCargo = new System.Windows.Forms.ComboBox();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.txtFiltroSimple = new System.Windows.Forms.TextBox();
            this.gboAvz = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFiltroAvz = new System.Windows.Forms.TextBox();
            this.rbIdEmpleado = new System.Windows.Forms.RadioButton();
            this.rbCuil = new System.Windows.Forms.RadioButton();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFiltroAvanzada = new System.Windows.Forms.CheckBox();
            this.btnACtivos = new System.Windows.Forms.Button();
            this.btnInactivos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gboAvz.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(605, 475);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 33);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 475);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(88, 33);
            this.btnNuevo.TabIndex = 17;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 180);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(681, 125);
            this.dgvUsuarios.TabIndex = 16;
            this.dgvUsuarios.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox3.Controls.Add(this.btnInactivos);
            this.groupBox3.Controls.Add(this.btnACtivos);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnReiniciar);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cboRol);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboCargo);
            this.groupBox3.Controls.Add(this.cboSucursal);
            this.groupBox3.Controls.Add(this.txtFiltroSimple);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(9, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 172);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Busqueda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(496, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Escribe al menos 3 letras ( Nombre de usuario / Nombre de empleado)";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(566, 139);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(98, 26);
            this.btnReiniciar.TabIndex = 10;
            this.btnReiniciar.Text = "Todos";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rol";
            // 
            // cboRol
            // 
            this.cboRol.Font = new System.Drawing.Font("Book Antiqua", 9.75F);
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(374, 139);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(161, 25);
            this.cboRol.TabIndex = 8;
            this.cboRol.SelectedValueChanged += new System.EventHandler(this.cboRol_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cargo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sucursal";
            // 
            // cboCargo
            // 
            this.cboCargo.Font = new System.Drawing.Font("Book Antiqua", 9.75F);
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(181, 140);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(161, 25);
            this.cboCargo.TabIndex = 4;
            this.cboCargo.SelectedValueChanged += new System.EventHandler(this.cboCargo_SelectedValueChanged);
            // 
            // cboSucursal
            // 
            this.cboSucursal.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(5, 140);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(161, 25);
            this.cboSucursal.TabIndex = 3;
            this.cboSucursal.SelectedValueChanged += new System.EventHandler(this.cboSucursal_SelectedValueChanged);
            // 
            // txtFiltroSimple
            // 
            this.txtFiltroSimple.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroSimple.Location = new System.Drawing.Point(5, 81);
            this.txtFiltroSimple.Name = "txtFiltroSimple";
            this.txtFiltroSimple.Size = new System.Drawing.Size(371, 31);
            this.txtFiltroSimple.TabIndex = 2;
            this.txtFiltroSimple.TextChanged += new System.EventHandler(this.txtFiltroSimple_TextChanged);
            // 
            // gboAvz
            // 
            this.gboAvz.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.gboAvz.Controls.Add(this.btnBuscar);
            this.gboAvz.Controls.Add(this.txtFiltroAvz);
            this.gboAvz.Controls.Add(this.rbIdEmpleado);
            this.gboAvz.Controls.Add(this.rbCuil);
            this.gboAvz.Controls.Add(this.rbNombre);
            this.gboAvz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboAvz.Location = new System.Drawing.Point(12, 369);
            this.gboAvz.Name = "gboAvz";
            this.gboAvz.Size = new System.Drawing.Size(681, 100);
            this.gboAvz.TabIndex = 27;
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
            // rbIdEmpleado
            // 
            this.rbIdEmpleado.AutoSize = true;
            this.rbIdEmpleado.Location = new System.Drawing.Point(189, 19);
            this.rbIdEmpleado.Name = "rbIdEmpleado";
            this.rbIdEmpleado.Size = new System.Drawing.Size(99, 20);
            this.rbIdEmpleado.TabIndex = 2;
            this.rbIdEmpleado.TabStop = true;
            this.rbIdEmpleado.Text = "IdEmpleado";
            this.rbIdEmpleado.UseVisualStyleBackColor = true;
            // 
            // rbCuil
            // 
            this.rbCuil.AutoSize = true;
            this.rbCuil.Location = new System.Drawing.Point(136, 19);
            this.rbCuil.Name = "rbCuil";
            this.rbCuil.Size = new System.Drawing.Size(47, 20);
            this.rbCuil.TabIndex = 1;
            this.rbCuil.TabStop = true;
            this.rbCuil.Text = "Cuil";
            this.rbCuil.UseVisualStyleBackColor = true;
            // 
            // rbNombre
            // 
            this.rbNombre.AutoSize = true;
            this.rbNombre.Location = new System.Drawing.Point(6, 19);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(124, 20);
            this.rbNombre.TabIndex = 0;
            this.rbNombre.TabStop = true;
            this.rbNombre.Text = "Nombre Usuario";
            this.rbNombre.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox2.Controls.Add(this.chkFiltroAvanzada);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 42);
            this.groupBox2.TabIndex = 26;
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
            // FrmListadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(705, 509);
            this.Controls.Add(this.gboAvz);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "FrmListadoUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados de usuarios";
            this.Load += new System.EventHandler(this.FrmListadoUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboAvz.ResumeLayout(false);
            this.gboAvz.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gboAvz;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFiltroAvz;
        private System.Windows.Forms.RadioButton rbIdEmpleado;
        private System.Windows.Forms.RadioButton rbCuil;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkFiltroAvanzada;
        private System.Windows.Forms.TextBox txtFiltroSimple;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCargo;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInactivos;
        private System.Windows.Forms.Button btnACtivos;
    }
}