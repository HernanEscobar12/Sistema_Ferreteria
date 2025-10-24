namespace Sistema_Ferreteria
{
    partial class FrmListadoEmpleados
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
            this.btnActivos = new System.Windows.Forms.Button();
            this.btnInactivos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnFiltroAvanzado = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCargo = new System.Windows.Forms.ComboBox();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.pnlFiltroSimple = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltroSimple = new System.Windows.Forms.TextBox();
            this.rbFiltroSimple = new System.Windows.Forms.RadioButton();
            this.rbFiltroAvanzado = new System.Windows.Forms.RadioButton();
            this.btnReiniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnFiltroAvanzado.SuspendLayout();
            this.pnlFiltroSimple.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActivos
            // 
            this.btnActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivos.Location = new System.Drawing.Point(24, 399);
            this.btnActivos.Name = "btnActivos";
            this.btnActivos.Size = new System.Drawing.Size(88, 33);
            this.btnActivos.TabIndex = 15;
            this.btnActivos.Text = "Activos";
            this.btnActivos.UseVisualStyleBackColor = true;
            this.btnActivos.Click += new System.EventHandler(this.btnActivos_Click);
            // 
            // btnInactivos
            // 
            this.btnInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactivos.Location = new System.Drawing.Point(118, 399);
            this.btnInactivos.Name = "btnInactivos";
            this.btnInactivos.Size = new System.Drawing.Size(88, 33);
            this.btnInactivos.TabIndex = 14;
            this.btnInactivos.Text = "Inactivos";
            this.btnInactivos.UseVisualStyleBackColor = true;
            this.btnInactivos.Click += new System.EventHandler(this.btnInactivos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(785, 463);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 33);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(24, 463);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(88, 33);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEmpleados.Location = new System.Drawing.Point(24, 225);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.Size = new System.Drawing.Size(849, 168);
            this.dgvEmpleados.TabIndex = 11;
            this.dgvEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.pnFiltroAvanzado);
            this.groupBox1.Controls.Add(this.pnlFiltroSimple);
            this.groupBox1.Controls.Add(this.rbFiltroSimple);
            this.groupBox1.Controls.Add(this.rbFiltroAvanzado);
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 206);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // pnFiltroAvanzado
            // 
            this.pnFiltroAvanzado.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnFiltroAvanzado.Controls.Add(this.btnReiniciar);
            this.pnFiltroAvanzado.Controls.Add(this.label4);
            this.pnFiltroAvanzado.Controls.Add(this.label3);
            this.pnFiltroAvanzado.Controls.Add(this.label2);
            this.pnFiltroAvanzado.Controls.Add(this.cboCargo);
            this.pnFiltroAvanzado.Controls.Add(this.cboSucursal);
            this.pnFiltroAvanzado.Controls.Add(this.cboLocalidad);
            this.pnFiltroAvanzado.Location = new System.Drawing.Point(7, 119);
            this.pnFiltroAvanzado.Name = "pnFiltroAvanzado";
            this.pnFiltroAvanzado.Size = new System.Drawing.Size(836, 66);
            this.pnFiltroAvanzado.TabIndex = 18;
            this.pnFiltroAvanzado.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(460, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cargo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(267, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sucursal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Localidad";
            // 
            // cboCargo
            // 
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(418, 35);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(145, 21);
            this.cboCargo.TabIndex = 2;
            this.cboCargo.SelectedValueChanged += new System.EventHandler(this.cboCargo_SelectedValueChanged);
            // 
            // cboSucursal
            // 
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(233, 35);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(145, 21);
            this.cboSucursal.TabIndex = 1;
            this.cboSucursal.SelectedValueChanged += new System.EventHandler(this.cboSucursal_SelectedValueChanged);
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(56, 35);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(145, 21);
            this.cboLocalidad.TabIndex = 0;
            this.cboLocalidad.SelectedValueChanged += new System.EventHandler(this.cboLocalidad_SelectedValueChanged);
            // 
            // pnlFiltroSimple
            // 
            this.pnlFiltroSimple.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlFiltroSimple.Controls.Add(this.label1);
            this.pnlFiltroSimple.Controls.Add(this.txtFiltroSimple);
            this.pnlFiltroSimple.Location = new System.Drawing.Point(7, 42);
            this.pnlFiltroSimple.Name = "pnlFiltroSimple";
            this.pnlFiltroSimple.Size = new System.Drawing.Size(836, 71);
            this.pnlFiltroSimple.TabIndex = 17;
            this.pnlFiltroSimple.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escribe al menos 3 letras de un empleado";
            // 
            // txtFiltroSimple
            // 
            this.txtFiltroSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroSimple.Location = new System.Drawing.Point(7, 34);
            this.txtFiltroSimple.Name = "txtFiltroSimple";
            this.txtFiltroSimple.Size = new System.Drawing.Size(545, 29);
            this.txtFiltroSimple.TabIndex = 0;
            this.txtFiltroSimple.TextChanged += new System.EventHandler(this.txtFiltroSimple_TextChanged);
            // 
            // rbFiltroSimple
            // 
            this.rbFiltroSimple.AutoSize = true;
            this.rbFiltroSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFiltroSimple.Location = new System.Drawing.Point(10, 12);
            this.rbFiltroSimple.Name = "rbFiltroSimple";
            this.rbFiltroSimple.Size = new System.Drawing.Size(132, 28);
            this.rbFiltroSimple.TabIndex = 16;
            this.rbFiltroSimple.TabStop = true;
            this.rbFiltroSimple.Text = "Filtro Simple";
            this.rbFiltroSimple.UseVisualStyleBackColor = true;
            this.rbFiltroSimple.CheckedChanged += new System.EventHandler(this.rbFiltroAvanzado_CheckedChanged);
            // 
            // rbFiltroAvanzado
            // 
            this.rbFiltroAvanzado.AutoSize = true;
            this.rbFiltroAvanzado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFiltroAvanzado.Location = new System.Drawing.Point(149, 13);
            this.rbFiltroAvanzado.Name = "rbFiltroAvanzado";
            this.rbFiltroAvanzado.Size = new System.Drawing.Size(158, 28);
            this.rbFiltroAvanzado.TabIndex = 15;
            this.rbFiltroAvanzado.TabStop = true;
            this.rbFiltroAvanzado.Text = "Filtro Avanzado";
            this.rbFiltroAvanzado.UseVisualStyleBackColor = true;
            this.rbFiltroAvanzado.CheckedChanged += new System.EventHandler(this.rbFiltroAvanzado_CheckedChanged);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(690, 12);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(134, 44);
            this.btnReiniciar.TabIndex = 6;
            this.btnReiniciar.Text = "Todos";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // FrmListadoEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 544);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnActivos);
            this.Controls.Add(this.dgvEmpleados);
            this.Controls.Add(this.btnInactivos);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmListadoEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de empleados";
            this.Load += new System.EventHandler(this.FrmListadoEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnFiltroAvanzado.ResumeLayout(false);
            this.pnFiltroAvanzado.PerformLayout();
            this.pnlFiltroSimple.ResumeLayout(false);
            this.pnlFiltroSimple.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActivos;
        private System.Windows.Forms.Button btnInactivos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFiltroSimple;
        private System.Windows.Forms.RadioButton rbFiltroAvanzado;
        private System.Windows.Forms.Panel pnFiltroAvanzado;
        private System.Windows.Forms.Panel pnlFiltroSimple;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltroSimple;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCargo;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReiniciar;
    }
}