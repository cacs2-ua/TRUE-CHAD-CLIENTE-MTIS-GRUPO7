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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Cliente_Mtis_Facturacion_Grupo7
{
    public partial class ucConsultarFactura : UserControl
    {
        public ucConsultarFactura()
        {
            InitializeComponent();
        }

        private async void consultarButton_Click(object sender, EventArgs e)
        {
            string WSKey = Utils.obtenerRestKey();
            string factura = numeroFacturaTextBox.Text.Trim();
            string email = emailEmpresaTextBox.Text.Trim();

            var url = "http://localhost:14103/api/consulta-facturas/iniciar";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("wskey", WSKey);

            var body = new
            {
                numeroFactura = factura,
                emailEmpresa = email
            };

            try
            {
                var jsonBody = JsonConvert.SerializeObject(body);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // 👇 Corrección aquí
                    var wrapper = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseContent);
                    var facturaJson = wrapper["factura"].ToString();
                    var facturaData = JsonConvert.DeserializeObject<Dictionary<string, object>>(facturaJson);

                    facturaDataGridView.Columns.Clear();
                    facturaDataGridView.Rows.Clear();

                    foreach (var kvp in facturaData)
                    {
                        facturaDataGridView.Columns.Add(kvp.Key, kvp.Key);
                    }

                    int rowIndex = facturaDataGridView.Rows.Add();
                    int columnIndex = 0;

                    foreach (var kvp in facturaData)
                    {
                        // Formatear fechas si es necesario
                        if (kvp.Value is string str && DateTime.TryParse(str, out DateTime dt))
                        {
                            facturaDataGridView.Rows[rowIndex].Cells[columnIndex].Value = dt.ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            facturaDataGridView.Rows[rowIndex].Cells[columnIndex].Value = kvp.Value?.ToString();
                        }

                        columnIndex++;
                    }
                }
                else
                {
                    MessageBox.Show($"Error: {responseContent}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numeroFacturaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailEmpresaTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
