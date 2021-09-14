﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocios;



namespace Pan3
{
    public partial class Form1 : Form
    {
        string cstock;
        string cppu;
        string ccode;
        string ccategoria;
        string cnombre;
        private string idproveedor;
        private string idcliente;
        private string idautorizado;
        private bool editarse = false;
        E_Proveedor objEProveedor = new E_Proveedor();
        NegProveedores objNegProveedor = new NegProveedores();
        E_Cliente objECliente = new E_Cliente();
        NegCliente objNegCliente = new NegCliente();
        E_Autorizados objEAutorizado = new E_Autorizados();
        NegAutorizados objNegAutorizado = new NegAutorizados();

        public Form1()
        {
            InitializeComponent();

            CrearColumnas();
            lbltime.Text = DateTime.Now.ToString();
            NUDCantidad.Maximum = decimal.MaxValue;
            BTVenta.BackgroundImageLayout = ImageLayout.Stretch;
            BTRemover.BackgroundImageLayout = ImageLayout.Stretch;
            BTMasuno.BackgroundImageLayout = ImageLayout.Stretch;
            BTMenosuno.BackgroundImageLayout = ImageLayout.Stretch;
            BTCancelar.BackgroundImageLayout = ImageLayout.Stretch;
            CBProducto.AutoCompleteMode = AutoCompleteMode.Suggest;

            ToolTip TTventa = new ToolTip();
            TTventa.ShowAlways = true;
            TTventa.SetToolTip(BTVenta, "Finalizar Venta.\r\nSuma la totalidad de los productos y efectúa la venta.");
            TTventa.IsBalloon = true;
            TTventa.AutoPopDelay = 15000;

            ToolTip TTremover = new ToolTip();
            TTremover.ShowAlways = true;
            TTremover.SetToolTip(BTRemover, "Remover Producto.\r\nRemueve todas las unidades del producto seleccionado de la lista de venta.");
            TTremover.IsBalloon = true;
            TTremover.AutoPopDelay = 15000;

            ToolTip TTmasuno = new ToolTip();
            TTmasuno.ShowAlways = true;
            TTmasuno.SetToolTip(BTMasuno, "Agregar Unidad.\r\nAgrega una unidad al producto seleccionado de la lista de venta.");
            TTmasuno.IsBalloon = true;
            TTmasuno.AutoPopDelay = 15000;

            ToolTip TTmenosuno = new ToolTip();
            TTmenosuno.ShowAlways = true;
            TTmenosuno.SetToolTip(BTMenosuno, "Restar Unidad.\r\nResta una unidad al producto seleccionado de la lista de venta.");
            TTmenosuno.IsBalloon = true;
            TTmenosuno.AutoPopDelay = 15000;

            ToolTip TTcancelar = new ToolTip();
            TTcancelar.ShowAlways = true;
            TTcancelar.SetToolTip(BTCancelar, "Cancelar Venta.\r\nRemueve todos los productos de la lista de venta.");
            TTcancelar.IsBalloon = true;
            TTcancelar.AutoPopDelay = 15000;

        }

        #region venta
        private void CBProducto_TextChanged(object sender, EventArgs e)
        {
            if (CBProducto.Text == "001 - Facturas")
            {
                cstock = "-";
                cppu = "30";
                ccode = "001";
                ccategoria = "Panadería";
                cnombre = "Facturas";
                lbluom.Text = "Unidades";
            }

            if (CBProducto.Text == "005 - Criollitos de Hojaldre")
            {
                cstock = "-";
                cppu = "0,25";
                ccode = "005";
                ccategoria = "Panadería";
                cnombre = "Criollitos de Hojaldre";
                lbluom.Text = "Gramos";
            }

            if (CBProducto.Text == "103 - Coca - Gaseosa 2L")
            {
                cstock = "16";
                cppu = "180";
                ccode = "103";
                ccategoria = "Gaseosas y Bebidas";
                cnombre = "Coca - 2L";
                lbluom.Text = "Unidades";
            }

            if (CBProducto.Text == "212 - Cerealitas - Galletas Arroz 250g")
            {
                cstock = "8";
                cppu = "120";
                ccode = "212";
                ccategoria = "Galletas";
                cnombre = "Cerealitas - Galletas Arroz 250g";
                lbluom.Text = "Unidades";
            }

            select_item();
        }

        private void BTAgregar_Click(object sender, EventArgs e)
        {
            Decimal preciodouble = NUDCantidad.Value * Convert.ToDecimal(cppu);
            string precioxcantidad = preciodouble.ToString();
            string cantidad = NUDCantidad.Value.ToString();

            DGVListaVenta.Rows.Add(cantidad, cnombre, cppu, precioxcantidad);

            decimal preciototal = 0;
            for (int i = 0; i < DGVListaVenta.Rows.Count; ++i)
            {
                preciototal += Convert.ToDecimal(DGVListaVenta.Rows[i].Cells[3].Value);
            }
            lbltotal.Text = "Total: $" + preciototal.ToString();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TVProductos.SelectedNode.Text == "Facturas")
            {
                cstock = "-";
                cppu = "30";
                ccode = "001";
                ccategoria = "Panadería";
                lbluom.Text = "Unidades";
            }

            if (TVProductos.SelectedNode.Text == "Criollitos de Hojaldre")
            {
                cstock = "-";
                cppu = "0,25";
                ccode = "005";
                ccategoria = "Panadería";
                lbluom.Text = "Gramos";
            }

            if (TVProductos.SelectedNode.Text == "Coca - 2L")
            {
                cstock = "16";
                cppu = "180";
                ccode = "103";
                ccategoria = "Gaseosas y Bebidas";
                lbluom.Text = "Unidades";
            }

            if (TVProductos.SelectedNode.Text == "Cerealitas - Galletas Arroz 250g")
            {
                cstock = "8";
                cppu = "120";
                ccode = "212";
                ccategoria = "Galletas";
                lbluom.Text = "Unidades";
            }
            cnombre = TVProductos.SelectedNode.Text;
            select_item();
            NUDCantidad.Focus();
            NUDCantidad.Select(0, NUDCantidad.Text.Length);
        }


        private void select_item()
        {
            TBStock.Text = cstock;
            TBCategoría.Text = ccategoria;
            TBCode.Text = ccode;
            TBPrecioU.Text = cppu;
            NUDCantidad.Value = 1;
        }

        #endregion
        private void TimerHora_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("HH:mm\r\ndd/MM/yyyy");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarBuscarTablaP("");
            accionestabla();
            LlenarDGV();
            LlenarDGVAut();
        }

        #region proveedor

        public void mostrarBuscarTablaP(string buscar)
        {
            NegProveedores objNegocio = new NegProveedores();
            dgvProv.DataSource = objNegocio.ListandoProveedores(buscar);
        }

        public void accionestabla()
        {
            dgvProv.Columns[0].Visible = false;
            dgvProv.Columns[8].Visible = false;
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTablaP(txtbuscar.Text);
        }

        private void LimpiarTxt()
        {
            txtprov.Text = "";
            txtrs.Text = "";
            txtmail.Text = "";
            txttel.Text = "";
            txttelR.Text = "";
            txtdom.Text = "";
            txtcuil.Text = "";

            txtprov.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarTxt();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProv.SelectedRows.Count > 0)
            {
                editarse = true;
                idproveedor = dgvProv.CurrentRow.Cells[0].Value.ToString();
                txtprov.Text = dgvProv.CurrentRow.Cells[1].Value.ToString();
                txtrs.Text = dgvProv.CurrentRow.Cells[2].Value.ToString();
                txtmail.Text = dgvProv.CurrentRow.Cells[3].Value.ToString();
                txttel.Text = dgvProv.CurrentRow.Cells[4].Value.ToString();
                txttelR.Text = dgvProv.CurrentRow.Cells[5].Value.ToString();
                txtdom.Text = dgvProv.CurrentRow.Cells[6].Value.ToString();
                txtcuil.Text = dgvProv.CurrentRow.Cells[7].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione el proveedor que desea editar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editarse == false)
            {
                try
                {
                    objEProveedor.Name = txtprov.Text;
                    objEProveedor.Razonsocial = txtrs.Text;
                    objEProveedor.Mail = txtmail.Text;
                    objEProveedor.Tel = txttel.Text;
                    objEProveedor.Telrep = txttelR.Text;
                    objEProveedor.Dom = txtdom.Text;
                    objEProveedor.Cuil = txtcuil.Text;

                    objNegProveedor.InsertandoProveedor(objEProveedor);

                    MessageBox.Show("Proveedor guardado");
                    mostrarBuscarTablaP("");
                    LimpiarTxt();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo guardar el proveedor" + ex);
                }
            }

            if (editarse == true)
            {
                try
                {
                    objEProveedor.Id = Convert.ToInt32(idproveedor);
                    objEProveedor.Name = txtprov.Text;
                    objEProveedor.Razonsocial = txtrs.Text;
                    objEProveedor.Mail = txtmail.Text;
                    objEProveedor.Tel = txttel.Text;
                    objEProveedor.Telrep = txttelR.Text;
                    objEProveedor.Dom = txtdom.Text;
                    objEProveedor.Cuil = txtcuil.Text;

                    objNegProveedor.EditandoProveedor(objEProveedor);

                    MessageBox.Show("Proveedor editado");
                    mostrarBuscarTablaP("");
                    editarse = false;
                    LimpiarTxt();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo editar el proveedor" + ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProv.SelectedRows.Count > 0)
            {
                objEProveedor.Id = Convert.ToInt32(idproveedor);
                objEProveedor.Estado = true;
                objNegProveedor.EliminandoProveedor(objEProveedor);

                MessageBox.Show("Se eliminó el proveedor correctamente");
                mostrarBuscarTablaP("");
            }
            else
            {
                MessageBox.Show("Seleccione el proveedor que desea eliminar");
            }
        }

        #endregion

        #region Cliente

        private void CrearColumnas()
        {
            dgvCliente.ColumnCount = 7;
            dgvCliente.Columns[0].HeaderText = "Id";
            dgvCliente.Columns[1].HeaderText = "Nombre cliente";
            dgvCliente.Columns[2].HeaderText = "Nombre negocio";
            dgvCliente.Columns[3].HeaderText = "Domicilio";
            dgvCliente.Columns[4].HeaderText = "E-mail";
            dgvCliente.Columns[5].HeaderText = "Telefono";
            dgvCliente.Columns[6].HeaderText = "Estado";
        }
        private void LlenarDGV()
        {
            dgvCliente.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegCliente.ListandoClientes("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvCliente.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
            }
            else
                MessageBox.Show("No hay profesionales cargados en el sistema");
        }

        private void BtnG_Click(object sender, EventArgs e)
        {
            if (editarse == false)
            {
                try
                {
                    objECliente.Nombre_cl = txtNomCliente.Text;
                    objECliente.Nombre_neg = TxtNomCom.Text;
                    objECliente.Dom = TxtDomCliente.Text;
                    objECliente.Mail = TxtEmailCliente.Text;
                    objECliente.Tel = TxtTelCliente.Text;
                    objECliente.Esta_cancelado = false;

                    objNegCliente.InsertandoCliente("Alta", objECliente);
                    MessageBox.Show("Cliente guardado");
                    LlenarDGV();
                    LimpiarTxtC();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo guardar el cliente" + ex);
                }
            }

            if (editarse == true)
            {
                try
                {
                    objECliente.Id = Convert.ToInt32(idcliente);
                    objECliente.Nombre_cl = txtNomCliente.Text;
                    objECliente.Nombre_neg = TxtNomCom.Text;
                    objECliente.Dom = TxtDomCliente.Text;
                    objECliente.Mail = TxtEmailCliente.Text;
                    objECliente.Tel = TxtTelCliente.Text;

                    objNegCliente.EditandoCliente("Modificar", objECliente);

                    MessageBox.Show("Cliente editado");
                    LimpiarTxt();
                    LlenarDGV();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo editar el cliente" + ex);
                }
            }
        }

        private void LimpiarTxtC()
        {
            txtNomCliente.Text = "";
            TxtNomCom.Text = "";
            TxtDomCliente.Text = "";
            TxtEmailCliente.Text = "";
            TxtTelCliente.Text = "";

            txtNomCliente.Focus();
        }

        private void BtnEditC_Click(object sender, EventArgs e)

        {
            editarse = true;

            if (dgvCliente.SelectedRows.Count > 0)
            {
                idcliente = dgvCliente.CurrentRow.Cells[0].Value.ToString();
                txtNomCliente.Text = dgvCliente.CurrentRow.Cells[1].Value.ToString();
                TxtNomCom.Text = dgvCliente.CurrentRow.Cells[2].Value.ToString();
                TxtDomCliente.Text = dgvCliente.CurrentRow.Cells[3].Value.ToString();
                TxtEmailCliente.Text = dgvCliente.CurrentRow.Cells[4].Value.ToString();
                TxtTelCliente.Text = dgvCliente.CurrentRow.Cells[5].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione el proveedor que desea editar");
            }
        }

        private void btnnuevocliente_Click(object sender, EventArgs e)
        {
            LimpiarTxtC();
        }

        private void btncancelarC_Click(object sender, EventArgs e)
        {
            LimpiarTxtC();
        }

        private void BtnEC_Click(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                objECliente.Id = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value.ToString());
                objECliente.Esta_cancelado = true;
                objNegCliente.EliminandoCliente("Eliminar", objECliente);

                MessageBox.Show("Se eliminó el cliente correctamente");
                LlenarDGV();
            }
            else
            {
                MessageBox.Show("Seleccione el cliente que desea eliminar");
            }
        }

        #endregion

        #region Autorizado

        private void CrearColumnasAut()
        {
            dgvAutorizados.ColumnCount = 6;
            dgvAutorizados.Columns[0].HeaderText = "Id";
            dgvAutorizados.Columns[1].HeaderText = "Nombre";
            dgvAutorizados.Columns[2].HeaderText = "Apellido";
            dgvAutorizados.Columns[3].HeaderText = "Usuario";
            dgvAutorizados.Columns[4].HeaderText = "Clave";
            dgvAutorizados.Columns[5].HeaderText = "Estado";
        }
        private void LlenarDGVAut()
        {
            dgvAutorizados.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegAutorizado.ListandoAutorizados("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvAutorizados.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                }
            }
            else
                MessageBox.Show("No hay autorizados cargados en el sistema");
        }     

        #endregion

        private void BtnGAut_Click(object sender, EventArgs e)
        {
            if (editarse == false)
            {
                try
                {
                    objEAutorizado.Nombre_aut = txtNomAut.Text;
                    objEAutorizado.Apellido_aut = txtApAut.Text;
                    objEAutorizado.Usuario_aut = txtUsAut.Text;
                    objEAutorizado.Clave_aut = txtClaveAut.Text;
                    objEAutorizado.Esta_cancelado = false;

                    objNegAutorizado.InsertandoAutorizados("Alta", objEAutorizado);
                    MessageBox.Show("Autorizado guardado");
                    LlenarDGVAut();
                    LimpiarTxtA();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo guardar el autorizado" + ex);
                }
            }

            if (editarse == true)
            {
                try
                {
                    objEAutorizado.Id = Convert.ToInt32(idautorizado);
                    objEAutorizado.Nombre_aut = txtNomAut.Text;
                    objEAutorizado.Apellido_aut = txtApAut.Text;
                    objEAutorizado.Usuario_aut = txtUsAut.Text;
                    objEAutorizado.Clave_aut = txtClaveAut.Text;

                    objNegAutorizado.EditandoAutorizados("Modificar", objEAutorizado);

                    MessageBox.Show("Autorizado editado");
                    LimpiarTxtA();
                    LlenarDGVAut();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo editar el autorizado" + ex);
                }
            }
        }


        private void LimpiarTxtA()
        {
            txtNomAut.Text = "";
            txtApAut.Text = "";
            txtUsAut.Text = "";
            txtClaveAut.Text = "";
            txtConfCAut.Text = "";

            txtNomAut.Focus();
        }

        private void BtnEdAut_Click(object sender, EventArgs e)
        {
            editarse = true;

            if (dgvAutorizados.SelectedRows.Count > 0)
            {
                idautorizado = dgvAutorizados.CurrentRow.Cells[0].Value.ToString();
                txtNomAut.Text = dgvAutorizados.CurrentRow.Cells[1].Value.ToString();
                txtApAut.Text = dgvAutorizados.CurrentRow.Cells[2].Value.ToString();
                txtUsAut.Text = dgvAutorizados.CurrentRow.Cells[3].Value.ToString();
                txtClaveAut.Text = dgvAutorizados.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione el autorizado que desea editar");
            }
        }

        private void BtnNAut_Click(object sender, EventArgs e)
        {
            LimpiarTxtA();
        }

        private void BtnElAut_Click(object sender, EventArgs e)
        {
            if (dgvAutorizados.SelectedRows.Count > 0)
            {
                objEAutorizado.Id = Convert.ToInt32(dgvAutorizados.CurrentRow.Cells[0].Value.ToString());
                objEAutorizado.Esta_cancelado = true;
                objNegAutorizado.EliminandoAutorizados("Eliminar", objEAutorizado);

                MessageBox.Show("Se eliminó el autorizado correctamente");
                LlenarDGV();
            }
            else
            {
                MessageBox.Show("Seleccione el autorizado que desea eliminar");
            }
        }
    }
}