namespace Cliente_Mtis_Facturacion_Grupo7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void emitirUnaFacturaNuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            ucEmitirFactura uc = new ucEmitirFactura();
            uc.Width = panelContenedor.ClientSize.Width;
            uc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelContenedor.Controls.Add(uc);
        }

        private void subsanarUnaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            ucSubsanarFactura uc = new ucSubsanarFactura();
            uc.Width = panelContenedor.ClientSize.Width;
            uc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelContenedor.Controls.Add(uc);

        }

        private void consultarUnaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panelContenedor.Controls.Clear();

            ucConsultarFactura uc = new ucConsultarFactura();
            uc.Width = panelContenedor.ClientSize.Width;
            uc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelContenedor.Controls.Add(uc);
        }

        private void anularUnaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            ucAnularFactura uc = new ucAnularFactura();
            uc.Width = panelContenedor.ClientSize.Width;
            uc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelContenedor.Controls.Add(uc);
        }

        private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContenedor.Controls.Clear();

            ucEstadisticas uc = new ucEstadisticas();
            uc.Width = panelContenedor.ClientSize.Width;
            uc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelContenedor.Controls.Add(uc);

        }
    }
}
