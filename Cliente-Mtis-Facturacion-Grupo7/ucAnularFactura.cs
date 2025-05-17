using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.utils;

namespace Cliente_Mtis_Facturacion_Grupo7
{
    public partial class ucAnularFactura : UserControl
    {
        public ucAnularFactura()
        {
            InitializeComponent();
        }

        private void anularButton_Click(object sender, EventArgs e)
        {
            string WSKey = Utils.obtenerRestKey();
        }
    }
}
