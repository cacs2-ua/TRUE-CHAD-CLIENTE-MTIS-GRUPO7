namespace Cliente_Mtis_Facturacion_Grupo7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            emitirUnaFacturaNuevaToolStripMenuItem = new ToolStripMenuItem();
            subsanarUnaFacturaToolStripMenuItem = new ToolStripMenuItem();
            consultarUnaFacturaToolStripMenuItem = new ToolStripMenuItem();
            anularUnaFacturaToolStripMenuItem = new ToolStripMenuItem();
            estadísticasToolStripMenuItem = new ToolStripMenuItem();
            panelContenedor = new Panel();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { emitirUnaFacturaNuevaToolStripMenuItem, subsanarUnaFacturaToolStripMenuItem, consultarUnaFacturaToolStripMenuItem, anularUnaFacturaToolStripMenuItem, estadísticasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1902, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // emitirUnaFacturaNuevaToolStripMenuItem
            // 
            emitirUnaFacturaNuevaToolStripMenuItem.Name = "emitirUnaFacturaNuevaToolStripMenuItem";
            emitirUnaFacturaNuevaToolStripMenuItem.Size = new Size(183, 24);
            emitirUnaFacturaNuevaToolStripMenuItem.Text = "Emitir una factura nueva";
            emitirUnaFacturaNuevaToolStripMenuItem.Click += emitirUnaFacturaNuevaToolStripMenuItem_Click;
            // 
            // subsanarUnaFacturaToolStripMenuItem
            // 
            subsanarUnaFacturaToolStripMenuItem.Name = "subsanarUnaFacturaToolStripMenuItem";
            subsanarUnaFacturaToolStripMenuItem.Size = new Size(161, 24);
            subsanarUnaFacturaToolStripMenuItem.Text = "Subsanar una factura";
            subsanarUnaFacturaToolStripMenuItem.Click += subsanarUnaFacturaToolStripMenuItem_Click;
            // 
            // consultarUnaFacturaToolStripMenuItem
            // 
            consultarUnaFacturaToolStripMenuItem.Name = "consultarUnaFacturaToolStripMenuItem";
            consultarUnaFacturaToolStripMenuItem.Size = new Size(163, 24);
            consultarUnaFacturaToolStripMenuItem.Text = "Consultar una factura";
            consultarUnaFacturaToolStripMenuItem.Click += consultarUnaFacturaToolStripMenuItem_Click;
            // 
            // anularUnaFacturaToolStripMenuItem
            // 
            anularUnaFacturaToolStripMenuItem.Name = "anularUnaFacturaToolStripMenuItem";
            anularUnaFacturaToolStripMenuItem.Size = new Size(144, 24);
            anularUnaFacturaToolStripMenuItem.Text = "Anular una factura";
            anularUnaFacturaToolStripMenuItem.Click += anularUnaFacturaToolStripMenuItem_Click;
            // 
            // estadísticasToolStripMenuItem
            // 
            estadísticasToolStripMenuItem.Name = "estadísticasToolStripMenuItem";
            estadísticasToolStripMenuItem.Size = new Size(99, 24);
            estadísticasToolStripMenuItem.Text = "Estadísticas";
            estadísticasToolStripMenuItem.Click += estadísticasToolStripMenuItem_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Controls.Add(label1);
            panelContenedor.Location = new Point(0, 31);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1902, 1002);
            panelContenedor.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Underline);
            label1.ForeColor = Color.FromArgb(128, 128, 255);
            label1.Location = new Point(662, 42);
            label1.Name = "label1";
            label1.Size = new Size(620, 46);
            label1.TabIndex = 2;
            label1.Text = "MTIS Facturación Electrónica Grupo 7";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panelContenedor);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem emitirUnaFacturaNuevaToolStripMenuItem;
        private ToolStripMenuItem subsanarUnaFacturaToolStripMenuItem;
        private ToolStripMenuItem consultarUnaFacturaToolStripMenuItem;
        private ToolStripMenuItem anularUnaFacturaToolStripMenuItem;
        private ToolStripMenuItem estadísticasToolStripMenuItem;
        private Panel panelContenedor;
        private Label label1;
    }
}
