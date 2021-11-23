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
using Microsoft.VisualBasic;
using System.Drawing.Printing;

namespace Pan3
{
    public partial class Caja : Form
    {
        public string NombreAutorizado = "";
        public int IdAutorizado = 0;

        NegAutorizados objNegAutorizado = new();

        E_Caja objECaja = new E_Caja();
        NegCaja objNegCaja = new NegCaja();

        Form1 frm1 = new();
        public Caja()
        {
            InitializeComponent();
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(txtMontoApertura.Text) <= 0)
                {
                    MessageBox.Show("Ingrese el monto de apertura");
                    txtMontoApertura.SelectAll();
                    txtMontoApertura.Focus();
                }
                else
                {
                    if (!CajaAbierta())
                    {
                        int nGrabados = -1;
                        objECaja.Id_Autorizado1 = IdAutorizado;
                        objECaja.Fecha1 = DateTime.Now.ToString("d");
                        objECaja.ImporteInicial1 = decimal.Parse(txtMontoApertura.Text);
                        objECaja.ImporteFinal1 = decimal.Parse(txtMontoApertura.Text);
                        objECaja.Estado1 = true;
                        nGrabados = objNegCaja.abmCaja("Alta", objECaja);

                        MessageBox.Show("Se abrio caja correctamente", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm1.Show();
                        Hide();
                    }                     
                }
            }

            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir caja");
            }
        }

        public Boolean CajaAbierta()
        {
            bool estado = false;

            string fecha = DateTime.Now.ToString("d");

            DataSet ds = objNegAutorizado.ListadoAutorizadoPorFecha(fecha);

            if (ds.Tables[0].Rows.Count == 0)
            {
                estado = true;
            }

            return estado;
        }

    }
}
