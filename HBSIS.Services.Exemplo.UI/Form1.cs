using HBSIS.Services.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HBSIS.Services.Model.Util;

namespace HBSIS.Services.Exemplo.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            var departamento = new Departamento()
            {
                Descricao = txt_Nome.Text,
                Ativo = ddl_Situacao.SelectedText == "Ativo" ? true : false
            };

            var url = "http://localhost:21725/DepartamentoAPI/Departamento";

            var httpClient = new HttpClient();
            var request = httpClient.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(departamento), Encoding.UTF8, "application/json"));
            request.Wait();

            var result = request.Result.Content.ReadAsStringAsync();
            result.Wait();

            var resultBody = JsonConvert.DeserializeObject<List<Departamento>>(result.Result);

            Txt_minhalista.Text = "";
            resultBody.ForEach(s =>
            {
                Txt_minhalista.Text += s.Id + " - " + s.Descricao + " - " + s.Ativo + Environment.NewLine;
            });
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                var url = "http://localhost:21725/DepartamentoAPI/Departamento";

                var httpClient = new HttpClient();

                var request = httpClient.DeleteAsync(url + "?Guid=" + txt_id.Text);
                request.Wait();

                var result = request.Result.Content.ReadAsStringAsync();
                result.Wait();

                var resultBody = JsonConvert.DeserializeObject<Result<List<Departamento>>>(result.Result);

                if (resultBody.Error)
                {
                    if (resultBody.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MessageBox.Show("Deu Erro" + resultBody.Message);
                    }
                    else
                        MessageBox.Show("Erro desconhecido");
                }
                else
                {
                    Txt_minhalista.Text = "";
                    resultBody.Data.ForEach(s =>
                    {
                        Txt_minhalista.Text += s.Id + " - " + s.Descricao + " - " + s.Ativo + Environment.NewLine;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
