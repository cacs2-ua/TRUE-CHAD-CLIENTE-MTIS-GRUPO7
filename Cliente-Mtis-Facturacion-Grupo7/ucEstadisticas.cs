using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniciadorEstadisticasGlobalesSoap;
using WinFormsApp1.utils;

namespace Cliente_Mtis_Facturacion_Grupo7
{
    public partial class ucEstadisticas : UserControl
    {
        public ucEstadisticas()
        {
            InitializeComponent();
        }

        private async void ucEstadisticas_Load(object sender, EventArgs e)
        {
            string WSKey = Utils.obtenerSoapKey();
            int a = 1;

            var request = new iniciarRequest
            {
                WSKey = WSKey
            };

            try
            {
                using (var client = new IniciarConsultaEstadisticasGlobalesClient())
                {
                    var response = await client.iniciarAsync(request);
                    int b = 1;

                    totalReportesEmitidosLabel.Text = response.datosEntrada.numeroTotalReportesCreados.ToString();
                    totalFacturasEmitidasLabel.Text = response.datosEntrada.numeroTotalFacturasEmitidas.ToString();
                    sumaTotalImportesLabel.Text = response.datosEntrada.sumaTotalImportes.ToString();
                    totalTodasFacturasValidasLabel.Text = (response.datosEntrada.numeroTotalFacturasValidas + response.datosEntrada.numeroTotalFacturasSubsanadas).ToString();
                    totalFacturasValidasLabel.Text = response.datosEntrada.numeroTotalFacturasValidas.ToString();
                    totalFacturasSubsanadasLabel.Text = response.datosEntrada.numeroTotalFacturasSubsanadas.ToString();
                    totalFacturasAnuladasLabel.Text = response.datosEntrada.numeroTotalFacturasAnuladas.ToString();
                    totalFacturasInvalidasLabel.Text = response.datosEntrada.numeroTotalFacturasInvalidas.ToString();

                }
            } catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error con el tratamiento de las estadísticas globales:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
