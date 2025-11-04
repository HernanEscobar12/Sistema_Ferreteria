namespace Sistema_Ferreteria
{
    partial class FrmMenu
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlBtns = new System.Windows.Forms.Panel();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pnlForms = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.pnlMenu.SuspendLayout();
            this.pnlBtns.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(662, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(198, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Menu Sistema";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.pnlMenu.Controls.Add(this.pbBanner);
            this.pnlMenu.Controls.Add(this.lblTitulo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1224, 80);
            this.pnlMenu.TabIndex = 11;
            // 
            // pnlBtns
            // 
            this.pnlBtns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.pnlBtns.Controls.Add(this.pnlUsuario);
            this.pnlBtns.Controls.Add(this.btnInventario);
            this.pnlBtns.Controls.Add(this.btnCaja);
            this.pnlBtns.Controls.Add(this.btnProductos);
            this.pnlBtns.Controls.Add(this.btnClientes);
            this.pnlBtns.Controls.Add(this.button1);
            this.pnlBtns.Controls.Add(this.btnUsuarios);
            this.pnlBtns.Controls.Add(this.btnProveedores);
            this.pnlBtns.Controls.Add(this.btnCompras);
            this.pnlBtns.Controls.Add(this.btnVentas);
            this.pnlBtns.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBtns.Location = new System.Drawing.Point(0, 80);
            this.pnlBtns.Name = "pnlBtns";
            this.pnlBtns.Size = new System.Drawing.Size(190, 581);
            this.pnlBtns.TabIndex = 12;
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlUsuario.Controls.Add(this.btnSalir);
            this.pnlUsuario.Controls.Add(this.lblUsuario);
            this.pnlUsuario.Controls.Add(this.pictureBox2);
            this.pnlUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUsuario.Location = new System.Drawing.Point(0, 521);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(190, 60);
            this.pnlUsuario.TabIndex = 11;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(51, 21);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(66, 18);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            // 
            // pnlForms
            // 
            this.pnlForms.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForms.Location = new System.Drawing.Point(190, 80);
            this.pnlForms.Name = "pnlForms";
            this.pnlForms.Size = new System.Drawing.Size(1034, 581);
            this.pnlForms.TabIndex = 13;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = global::Sistema_Ferreteria.Properties.Resources.right_from_bracket_solid_full;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(137, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(50, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sistema_Ferreteria.Properties.Resources.circle_user_solid_full;
            this.pictureBox2.Location = new System.Drawing.Point(10, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnInventario
            // 
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnInventario.Image = global::Sistema_Ferreteria.Properties.Resources.Inventario;
            this.btnInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.Location = new System.Drawing.Point(0, 320);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(190, 40);
            this.btnInventario.TabIndex = 10;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCaja.FlatAppearance.BorderSize = 0;
            this.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaja.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaja.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCaja.Image = global::Sistema_Ferreteria.Properties.Resources.Caja;
            this.btnCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaja.Location = new System.Drawing.Point(0, 280);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(190, 40);
            this.btnCaja.TabIndex = 9;
            this.btnCaja.Text = "Caja";
            this.btnCaja.UseVisualStyleBackColor = true;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProductos.Image = global::Sistema_Ferreteria.Properties.Resources.Productos;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 240);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(190, 40);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClientes.Image = global::Sistema_Ferreteria.Properties.Resources.Clientes;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 200);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(190, 40);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Image = global::Sistema_Ferreteria.Properties.Resources.Empleados;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Empleados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUsuarios.Image = global::Sistema_Ferreteria.Properties.Resources.Usuarios;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 120);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(190, 40);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProveedores.Image = global::Sistema_Ferreteria.Properties.Resources.Proveedores;
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Location = new System.Drawing.Point(0, 80);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(190, 40);
            this.btnProveedores.TabIndex = 6;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompras.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCompras.Image = global::Sistema_Ferreteria.Properties.Resources.Compras;
            this.btnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompras.Location = new System.Drawing.Point(0, 40);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(190, 40);
            this.btnCompras.TabIndex = 7;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVentas.Image = global::Sistema_Ferreteria.Properties.Resources.Ventas;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(0, 0);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(190, 40);
            this.btnVentas.TabIndex = 8;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // pbBanner
            // 
            this.pbBanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBanner.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbBanner.Image = global::Sistema_Ferreteria.Properties.Resources.bannerFerr;
            this.pbBanner.Location = new System.Drawing.Point(0, 0);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(190, 80);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBanner.TabIndex = 1;
            this.pbBanner.TabStop = false;
            this.pbBanner.Click += new System.EventHandler(this.pbBanner_Click_1);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 661);
            this.Controls.Add(this.pnlForms);
            this.Controls.Add(this.pnlBtns);
            this.Controls.Add(this.pnlMenu);
            this.MinimumSize = new System.Drawing.Size(1240, 600);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlBtns.ResumeLayout(false);
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.Panel pnlBtns;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlForms;
    }
}