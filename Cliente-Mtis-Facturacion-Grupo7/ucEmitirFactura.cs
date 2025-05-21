using System;
using System.Collections.Generic;          // los mantenemos, tal y como estaban
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.utils;

namespace Cliente_Mtis_Facturacion_Grupo7
{
    public partial class ucEmitirFactura : UserControl
    {
        public ucEmitirFactura() => InitializeComponent();

        //────────────────────────────────────────────────────────
        //  BOTÓN «Emitir»
        //────────────────────────────────────────────────────────
        private async void emitirButton_Click(object sender, EventArgs e)
        {
            // 0️⃣  WSKey
            string wsKey = Utils.obtenerRestKey();
            if (wsKey == "WSKey not Found")
            {
                MessageBox.Show("No se encontró la WSKey (restkey.txt).",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1️⃣  Consultar si el e-mail existe (pero **no** abortamos si es false)
            bool empresaExiste = false;
            try
            {
                empresaExiste = await EmpresaExisteAsync(emailEmpresaTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error contactando al servicio de validación:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;               // aquí sí abortamos, fue un fallo de red/servidor
            }

            // 2️⃣  Construir el JSON de la factura con los datos del formulario
            var factura = new
            {
                nombreEmpresa = nombreEmpresaTextBox.Text.Trim(),
                emailEmpresa = emailEmpresaTextBox.Text.Trim(),
                identificadorFiscalEmpresa = identificadorFiscalEmpresaTextBox.Text.Trim(),
                identificadorEmpleador = identificadorEmpleadorTextBox.Text.Trim(),
                ibanEmpresa = ibanEmpresaTextBox.Text.Trim(),
                paisEmpresa = paisEmpresaTextBox.Text.Trim(),
                provinciaEmpresa = provinciaEmpresaTextBox.Text.Trim(),
                localidadEmpresa = localidadEmpresaTextBox.Text.Trim(),
                direccionCompletaFacturacion = direccionCompletaFacturacionTextBox.Text.Trim(),
                codigoPostal = codigoPostalEmpresaTextbox.Text.Trim(),
                numeroFactura = numeroFacturaTextBox.Text.Trim(),
                baseImponible = double.Parse(baseImponibleTextBox.Text),
                iva = double.Parse(ivaTextBox.Text),
                moneda = monedaTextBox.Text,
                fechaDesdeFacturacion = fechaInicioFacturacionTextBox.Text.Trim(),
                fechaHastaFacturacion = fechaFinalFacturacionTextBox.Text.Trim()
            };

            string jsonFactura = JsonSerializer.Serialize(factura);

            // 3️⃣  Llamar al flujo de Mule (puerto 14101)
            using HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:14101")
            };

            var req = new HttpRequestMessage(HttpMethod.Post, "/api/emision-facturas/iniciar")
            {
                Content = new StringContent(jsonFactura, Encoding.UTF8, "application/json")
            };
            req.Headers.Add("WSKey", wsKey);

            try
            {
                HttpResponseMessage resp = await client.SendAsync(req);
                string respContent = await resp.Content.ReadAsStringAsync();
                bool ok = resp.IsSuccessStatusCode;

                // 4️⃣  Mensajes al usuario
                if (ok && empresaExiste)
                {
                    // caso feliz: empresa conocida + 200 de Mule
                    MessageBox.Show("Factura emitida correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ok && !empresaExiste)
                {
                    // Mule devolvió 200, pero la empresa no figuraba en la B.D.
                    MessageBox.Show("Error: El correo de la empresa no está registrado en el sistema.\n" +
                                    "Se ha notificado por e-mail.",
                                    "Empresa no encontrada",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else   // Mule devolvió error (4xx/5xx)
                {
                    MessageBox.Show("Error al emitir la factura:\n" + respContent,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción lanzando la solicitud:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //────────────────────────────────────────────────────────
        //  AUXILIAR • Comprueba si el e-mail existe
        //────────────────────────────────────────────────────────
        /// <summary>
        /// Llama a /api/validaciones/empresa-existe (puerto 12678)  
        /// Devuelve true si la respuesta contiene «resultado =true».  
        /// </summary>
        private static async Task<bool> EmpresaExisteAsync(string email)
        {
            string wsKey = Utils.obtenerRestKey();
            if (wsKey == "WSKey not Found")
                throw new InvalidOperationException("WSKey no encontrada.");

            var bodyJson = JsonSerializer.Serialize(new { email });

            using HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12678")
            };

            var req = new HttpRequestMessage(HttpMethod.Post, "/api/validaciones/empresa-existe")
            {
                Content = new StringContent(bodyJson, Encoding.UTF8, "application/json")
            };
            req.Headers.Add("WSKey", wsKey);

            HttpResponseMessage resp = await client.SendAsync(req);
            resp.EnsureSuccessStatusCode();   // exception si 4xx/5xx

            using var stream = await resp.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);

            // acepta { "resultado": true }  o  { "mensaje": { "resultado": true } }
            if (doc.RootElement.TryGetProperty("resultado", out JsonElement direct))
                return direct.GetBoolean();

            if (doc.RootElement.TryGetProperty("mensaje", out JsonElement msg) &&
                msg.TryGetProperty("resultado", out JsonElement nested))
                return nested.GetBoolean();

            throw new InvalidOperationException("Formato JSON inesperado en la respuesta.");
        }
    }
}
