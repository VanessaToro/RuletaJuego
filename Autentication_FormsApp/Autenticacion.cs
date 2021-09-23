using Autentication_FormsApp.Models;
using Autentication_FormsApp.Service;
using System;
using System.Windows.Forms;

namespace Autentication_FormsApp
{
    public partial class Autenticacion : Form
    {
        public Autenticacion()
        {
            InitializeComponent();
        }

        private void Autenticacion_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            LlamarAPI api = new LlamarAPI();
            string url = "https://localhost:44380/api/Usuarios/ValidarAutenticacionUsuario";

            Object peticion = new {
                usuario = txtUsuario.Text,
                clave = txtClave.Text
                };
            
            object respuesta = api.Ejecutar<Object>(url, peticion, "POST");
        }
    }
}
