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

namespace HBSIS.Services.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txt_pesquisa_TextChanged(object sender, EventArgs e)
        {
            var result = new AcessoAPI().MeuGet("http://localhost:5000/PokemonAPI/PokemonP?Nome=" + txt_pesquisa.Text);

            txt_result.Text = result;
        }
    }
}
