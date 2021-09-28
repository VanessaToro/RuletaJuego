using Autentication_FormsApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autentication_FormsApp
{
    public partial class Inicio : Form
    {
        public Inicio(Object usuario)
        {
            InitializeComponent();
        }

        private void ConsultarUsuarios()
        {
            LlamarAPI api = new LlamarAPI();
            string url = "https://localhost:44380/api/Usuarios/GetUsuario";

            object respuesta = api.Ejecutar<Object>(url, null, "GET");
       
            cbxUsuario.DisplayMember = "Value";
            cbxUsuario.ValueMember = "Index";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}
