namespace Cliente_Mtis_Facturacion_Grupo7
{
    partial class ucAnularFactura
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
            anularButton = new Button();
            emailEmpresaLabel = new Label();
            emailEmpresaTextBox = new TextBox();
            numeroFacturaLabel = new Label();
            numeroFacturaTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.FromArgb(128, 128, 255);
            label1.Location = new Point(801, 42);
            label1.Name = "label1";
            label1.Size = new Size(319, 46);
            label1.TabIndex = 0;
            label1.Text = "Anular una factura";
            // 
            // anularButton
            // 
            anularButton.BackColor = SystemColors.GradientActiveCaption;
            anularButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            anularButton.Location = new Point(865, 214);
            anularButton.Name = "anularButton";
            anularButton.Size = new Size(187, 51);
            anularButton.TabIndex = 42;
            anularButton.Text = "Anular";
            anularButton.UseVisualStyleBackColor = false;
            anularButton.Click += anularButton_Click;
            // 
            // emailEmpresaLabel
            // 
            emailEmpresaLabel.AutoSize = true;
            emailEmpresaLabel.Location = new Point(631, 161);
            emailEmpresaLabel.Name = "emailEmpresaLabel";
            emailEmpresaLabel.Size = new Size(144, 20);
            emailEmpresaLabel.TabIndex = 41;
            emailEmpresaLabel.Text = "Email de la empresa";
            // 
            // emailEmpresaTextBox
            // 
            emailEmpresaTextBox.Location = new Point(793, 158);
            emailEmpresaTextBox.Name = "emailEmpresaTextBox";
            emailEmpresaTextBox.Size = new Size(327, 27);
            emailEmpresaTextBox.TabIndex = 40;
            // 
            // numeroFacturaLabel
            // 
            numeroFacturaLabel.AutoSize = true;
            numeroFacturaLabel.Location = new Point(625, 114);
            numeroFacturaLabel.Name = "numeroFacturaLabel";
            numeroFacturaLabel.Size = new Size(150, 20);
            numeroFacturaLabel.TabIndex = 39;
            numeroFacturaLabel.Text = "Número de la factura";
            // 
            // numeroFacturaTextBox
            // 
            numeroFacturaTextBox.Location = new Point(793, 111);
            numeroFacturaTextBox.Name = "numeroFacturaTextBox";
            numeroFacturaTextBox.Size = new Size(327, 27);
            numeroFacturaTextBox.TabIndex = 38;
            // 
            // ucAnularFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(anularButton);
            Controls.Add(emailEmpresaLabel);
            Controls.Add(emailEmpresaTextBox);
            Controls.Add(numeroFacturaLabel);
            Controls.Add(numeroFacturaTextBox);
            Controls.Add(label1);
            Name = "ucAnularFactura";
            Size = new Size(1902, 1002);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button anularButton;
        private Label emailEmpresaLabel;
        private TextBox emailEmpresaTextBox;
        private Label numeroFacturaLabel;
        private TextBox numeroFacturaTextBox;
    }
}
