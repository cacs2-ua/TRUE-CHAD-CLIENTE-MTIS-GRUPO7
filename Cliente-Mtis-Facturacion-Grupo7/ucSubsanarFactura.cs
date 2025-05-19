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
using System.Text.Json;

namespace Cliente_Mtis_Facturacion_Grupo7
{
    public partial class ucSubsanarFactura : UserControl
    {
        public ucSubsanarFactura()
        {
            InitializeComponent();
        }

        private async void subsanarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailEmpresaTextBox.Text))
            {
                MessageBox.Show("El campo Email de la empresa es obligatorio.","Campo obligatorio",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(numeroFacturaTextBox.Text))
            {
                MessageBox.Show("El campo Número de factura es obligatorio.","Campo obligatorio",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(baseImponibleTextBox.Text))
            {
                MessageBox.Show("El campo Base imponible es obligatorio.","Campo obligatorio",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(monedaTextBox.Text))
            {
                MessageBox.Show("El campo Moneda es obligatorio.","Campo obligatorio",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            string WSKey = Utils.obtenerRestKey();

            var nombreEmpresa = nombreEmpresaTextBox.Text.Trim();
            var emailEmpresa = emailEmpresaTextBox.Text.Trim();
            var identificadorFiscalEmpresa = identificadorFiscalEmpresaTextBox.Text.Trim();
            var identificadorEmpleador = identificadorEmpleadorTextBox.Text.Trim();
            var ibanEmpresa = ibanEmpresaTextBox.Text.Trim();
            var paisEmpresa = paisEmpresaTextBox.Text.Trim();
            var provinciaEmpresa = provinciaEmpresaTextBox.Text.Trim();
            var localidadEmpresa = localidadEmpresaTextBox.Text.Trim();
            var direccionFacturacion = direccionCompletaFacturacionTextBox.Text.Trim();
            var codigoPostal = codigoPostalEmpresaTextbox.Text.Trim();
            var numeroFactura = numeroFacturaTextBox.Text.Trim();

            if (!decimal.TryParse(baseImponibleTextBox.Text.Trim(), out var baseImponible))
            {
                MessageBox.Show("Base imponible inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(ivaTextBox.Text.Trim(), out var iva))
            {
                MessageBox.Show("IVA inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var moneda = monedaTextBox.Text.Trim();
            if (!DateTime.TryParse(fechaInicioFacturacionTextBox.Text.Trim(), out var fechaDesde))
            {
                MessageBox.Show("Fecha inicio inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!DateTime.TryParse(fechaFinalFacturacionTextBox.Text.Trim(), out var fechaHasta))
            {
                MessageBox.Show("Fecha fin inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var payload = new
            {
                nombreEmpresa,
                emailEmpresa,
                identificadorFiscalEmpresa,
                identificadorEmpleador,
                ibanEmpresa,
                paisEmpresa,
                provinciaEmpresa,
                localidadEmpresa,
                direccionCompletaFacturacion = direccionFacturacion,
                codigoPostal,
                numeroFactura,
                baseImponible,
                iva,
                moneda,
                fechaDesdeFacturacion = fechaDesde.ToString("yyyy-MM-dd"),
                fechaHastaFacturacion = fechaHasta.ToString("yyyy-MM-dd")
            };

            string json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("WSKey", WSKey);

            try
            {
                HttpResponseMessage response = await client.PostAsync("http://localhost:14102/api/subsanacion-facturas/iniciar",content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    using var doc = JsonDocument.Parse(responseBody);
                    string mensaje = doc.RootElement.GetProperty("mensaje").GetString();

                    MessageBox.Show(mensaje,"Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    using var doc = JsonDocument.Parse(responseBody);
                    string mensaje = doc.RootElement.GetProperty("error").GetString();

                    MessageBox.Show(mensaje, "Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción al enviar la petición:\n" + ex.Message,
                                "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
    }
}
