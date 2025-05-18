namespace Cliente_Mtis_Facturacion_Grupo7
{
    partial class ucConsultarFactura
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            emailEmpresaLabel = new Label();
            emailEmpresaTextBox = new TextBox();
            numeroFacturaLabel = new Label();
            numeroFacturaTextBox = new TextBox();
            consultarButton = new Button();
            facturaDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)facturaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.FromArgb(128, 128, 255);
            label1.Location = new Point(683, 32);
            label1.Name = "label1";
            label1.Size = new Size(292, 37);
            label1.TabIndex = 0;
            label1.Text = "Consultar una factura";
            // 
            // emailEmpresaLabel
            // 
            emailEmpresaLabel.AutoSize = true;
            emailEmpresaLabel.Location = new Point(556, 122);
            emailEmpresaLabel.Name = "emailEmpresaLabel";
            emailEmpresaLabel.Size = new Size(112, 15);
            emailEmpresaLabel.TabIndex = 10;
            emailEmpresaLabel.Text = "Email de la empresa";
            // 
            // emailEmpresaTextBox
            // 
            emailEmpresaTextBox.Location = new Point(698, 120);
            emailEmpresaTextBox.Margin = new Padding(3, 2, 3, 2);
            emailEmpresaTextBox.Name = "emailEmpresaTextBox";
            emailEmpresaTextBox.Size = new Size(287, 23);
            emailEmpresaTextBox.TabIndex = 9;
            emailEmpresaTextBox.TextChanged += emailEmpresaTextBox_TextChanged;
            // 
            // numeroFacturaLabel
            // 
            numeroFacturaLabel.AutoSize = true;
            numeroFacturaLabel.Location = new Point(551, 87);
            numeroFacturaLabel.Name = "numeroFacturaLabel";
            numeroFacturaLabel.Size = new Size(119, 15);
            numeroFacturaLabel.TabIndex = 8;
            numeroFacturaLabel.Text = "Número de la factura";
            // 
            // numeroFacturaTextBox
            // 
            numeroFacturaTextBox.Location = new Point(698, 85);
            numeroFacturaTextBox.Margin = new Padding(3, 2, 3, 2);
            numeroFacturaTextBox.Name = "numeroFacturaTextBox";
            numeroFacturaTextBox.Size = new Size(287, 23);
            numeroFacturaTextBox.TabIndex = 7;
            numeroFacturaTextBox.TextChanged += numeroFacturaTextBox_TextChanged;
            // 
            // consultarButton
            // 
            consultarButton.BackColor = SystemColors.GradientActiveCaption;
            consultarButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            consultarButton.Location = new Point(761, 162);
            consultarButton.Margin = new Padding(3, 2, 3, 2);
            consultarButton.Name = "consultarButton";
            consultarButton.Size = new Size(164, 38);
            consultarButton.TabIndex = 37;
            consultarButton.Text = "Consultar";
            consultarButton.UseVisualStyleBackColor = false;
            consultarButton.Click += consultarButton_Click;
            // 
            // facturaDataGridView
            // 
            facturaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            facturaDataGridView.Location = new Point(294, 293);
            facturaDataGridView.Name = "facturaDataGridView";
            facturaDataGridView.Size = new Size(1040, 150);
            facturaDataGridView.TabIndex = 38;
            // 
            // ucConsultarFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(facturaDataGridView);
            Controls.Add(consultarButton);
            Controls.Add(emailEmpresaLabel);
            Controls.Add(emailEmpresaTextBox);
            Controls.Add(numeroFacturaLabel);
            Controls.Add(numeroFacturaTextBox);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ucConsultarFactura";
            Size = new Size(1664, 752);
            ((System.ComponentModel.ISupportInitialize)facturaDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label emailEmpresaLabel;
        private TextBox emailEmpresaTextBox;
        private Label numeroFacturaLabel;
        private TextBox numeroFacturaTextBox;
        private Button consultarButton;
        private DataGridView facturaDataGridView;
    }
}
