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
        NegCaja objNegCaja = new NegCaja();
        E_Caja objECaja = new E_Caja();

        Caja frmCaja = new();
        

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
            int id_Autorizado = objNegAutorizado.Login(txtusuario.Text, txtpass.Text, objEAutorizado);
            Form1 frm = new();

            if (id_Autorizado == 0)
            {
                MessageBox.Show("La combinacion de usuario y clave no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!cajaSinCerrar(id_Autorizado))
                {
                    frm.NombreAutorizado = txtusuario.Text;
                    frm.IdAutorizado = id_Autorizado;

                    frmCaja.NombreAutorizado = txtusuario.Text;
                    frmCaja.IdAutorizado = id_Autorizado;

                    if (!frmCaja.CajaAbierta())
                    {
                        Hide();
                        frmCaja.Show();
                    }
                    else
                    {
                        frm.Show();
                    }
                }
            }
        }


        //cajaSinCerrar Comprueba si el usuario que ingresó antes tiene caja abierta, si es el mismo entonces abre el form1,
        //sino indica que no se ha cerrado la caja anterior
        private bool cajaSinCerrar(int id_Autorizado)
        {
            bool cajaSinCerrar = false;
            bool ultimo_estado = false;
            int ultimo_id_Autorizado = 0;

            DataSet ds = objNegCaja.datosUltimoAutorizadoConCajaAbierta();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ultimo_id_Autorizado = int.Parse(dr[1].ToString());
                ultimo_estado = bool.Parse(dr[5].ToString());
            }

            if (ultimo_estado == true && (id_Autorizado != ultimo_id_Autorizado))
            {
                cajaSinCerrar = true;
                MessageBox.Show("La caja del usuario anterior aún sigue abierta", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return cajaSinCerrar;
        }

    }
}
