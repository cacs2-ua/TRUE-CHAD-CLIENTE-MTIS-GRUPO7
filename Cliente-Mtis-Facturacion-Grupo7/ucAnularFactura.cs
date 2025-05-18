using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.utils;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Cliente_Mtis_Facturacion_Grupo7
{
    public partial class ucAnularFactura : UserControl
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public ucAnularFactura()
        {
            InitializeComponent();
        }


        private async void anularButton_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://localhost:14104/api/anulacion-facturas/iniciar";

            string WSKey = Utils.obtenerRestKey();
            string email = emailEmpresaTextBox.Text.Trim();
            string factura = numeroFacturaTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || !Utils.IsValidEmail(email))
            {
                MessageBox.Show("El campo Email no es válido.", "Campo no valido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(factura))
            {
                MessageBox.Show("El campo número de la factura de la empresa es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var data = new
            {
                numeroFactura = factura,
                emailEmpresa = email
            };
            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
            {
                Content = content
            };

            request.Headers.Add("WSKey", WSKey);
            try
            {
                HttpResponseMessage response = await httpClient.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();
                string mensaje = JsonDocument.Parse(result).RootElement.GetProperty("mensaje").GetString();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                       mensaje,
                       "Se completó el proceso",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                   );
                }
                else
                {
                    MessageBox.Show(
                       mensaje,
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                   );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,                
                    "Error con el proceso",             
                    MessageBoxButtons.OK,  
                    MessageBoxIcon.Error      
                );
            }


        }
    }
}
