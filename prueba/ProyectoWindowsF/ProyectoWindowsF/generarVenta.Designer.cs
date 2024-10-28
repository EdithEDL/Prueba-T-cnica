namespace ProyectoWindowsF
{
    partial class generarVenta
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
            this.groupProductos = new System.Windows.Forms.GroupBox();
            this.Seleccionar = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // groupProductos
            // 
            this.groupProductos.BackColor = System.Drawing.Color.Gainsboro;
            this.groupProductos.Controls.Add(this.Seleccionar);
            this.groupProductos.Controls.Add(this.btnCancelar);
            this.groupProductos.Controls.Add(this.btnComprar);
            this.groupProductos.Controls.Add(this.dg);
            this.groupProductos.Controls.Add(this.btnAgregar);
            this.groupProductos.Controls.Add(this.txtCantidad);
            this.groupProductos.Controls.Add(this.label2);
            this.groupProductos.Controls.Add(this.label1);
            this.groupProductos.Location = new System.Drawing.Point(12, 25);
            this.groupProductos.Name = "groupProductos";
            this.groupProductos.Size = new System.Drawing.Size(621, 449);
            this.groupProductos.TabIndex = 0;
            this.groupProductos.TabStop = false;
            this.groupProductos.Text = "Generar Ventas";
            // 
            // Seleccionar
            // 
            this.Seleccionar.FormattingEnabled = true;
            this.Seleccionar.Location = new System.Drawing.Point(153, 66);
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Size = new System.Drawing.Size(226, 21);
            this.Seleccionar.TabIndex = 9;
            this.Seleccionar.SelectedIndexChanged += new System.EventHandler(this.Seleccionar_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(401, 392);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.Green;
            this.btnComprar.ForeColor = System.Drawing.Color.White;
            this.btnComprar.Location = new System.Drawing.Point(153, 392);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 7;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // dg
            // 
            this.dg.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(28, 216);
            this.dg.Name = "dg";
            this.dg.RowHeadersWidth = 51;
            this.dg.Size = new System.Drawing.Size(563, 150);
            this.dg.TabIndex = 6;
             // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(501, 173);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(153, 118);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(226, 20);
            this.txtCantidad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Productos:";
            // 
            // generarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(661, 515);
            this.Controls.Add(this.groupProductos);
            this.Name = "generarVenta";
            this.Text = "generarVenta";
            this.groupProductos.ResumeLayout(false);
            this.groupProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupProductos;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.ComboBox Seleccionar;
    }
}