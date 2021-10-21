using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocios;


namespace Pan3
{
    public partial class Login : Form
    {
        E_Autorizados objEAutorizado = new E_Autorizados();
        NegAutorizados objNegAutorizado = new NegAutorizados();

        public Login()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToString();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataSet datos = objNegAutorizado.Login(this.txtusuario.Text, this.txtpass.Text, objEAutorizado);
            if (datos.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("El usuario " + txtusuario.Text +" no existe" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
            else
            {
                Form1 frm = new();
                frm.NombreAutorizado = txtusuario.Text;
                //frm.IdAutorizado = Convert.ToInt32(datos.Tables[0]);
                this.Hide();
                frm.Show();
                
            }
        }

    }
}
