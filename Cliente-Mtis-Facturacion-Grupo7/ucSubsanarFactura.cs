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
    public partial class ucSubsanarFactura : UserControl
    {
        public ucSubsanarFactura()
        {
            InitializeComponent();
        }

        private void subsanarButton_Click(object sender, EventArgs e)
        {
            string WSKey = Utils.obtenerRestKey();
        }
    }
}
