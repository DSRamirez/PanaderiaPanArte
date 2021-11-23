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
                        frmCaja.Show();
                    }
                    else
                    {
                        frm.Show();
                    }
                }
            }
        }

        private bool cajaSinCerrar(int id_Autorizado)
        {
            bool cajaSinCerrar = false;            
            bool ultimo_estado = false;
            int ultimo_id_Autorizado = 0;

            DataSet ds = objNegCaja.datosUltimoAutorizadoConCajaAbierta();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ultimo_estado = bool.Parse(dr[0].ToString());
                ultimo_id_Autorizado = int.Parse(dr[1].ToString());
            }

            if (ultimo_estado == true && (id_Autorizado != ultimo_id_Autorizado))
            {
                cajaSinCerrar = true;
                MessageBox.Show("La caja del usuario anterior aún sigue abierta", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return cajaSinCerrar;
        }

        //private void CerrarCaja()
        //{
        //    int nGrabados = -1;

        //    objECaja.ImporteFinal1 = Convert.ToDecimal(0);
        //    objECaja.Estado1 = false;
        //    objECaja.Fecha1 = DateTime.Now.ToString("d");
        //    nGrabados = objNegCaja.abmCaja("Cierre", objECaja);

        //    if (nGrabados == -1)
        //    {
        //        MessageBox.Show("No se pudo cerrar la caja");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cierre de caja realizado");
        //        frmCaja.Show();
        //    }
        //}

    }
}
