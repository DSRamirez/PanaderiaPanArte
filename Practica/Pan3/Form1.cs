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
    public partial class Form1 : Form
    {
        private string idproveedor;
        private string idcliente;
        private string idautorizado;
        private string idproducto;
        private string idcategoria;
        private bool editarse = false;

        public string NombreAutorizado = "";
        public int IdAutorizado = 0;

        E_Proveedor objEProveedor = new E_Proveedor();
        NegProveedores objNegProveedor = new NegProveedores();
        E_Cliente objECliente = new E_Cliente();
        NegCliente objNegCliente = new NegCliente();
        E_Autorizados objEAutorizado = new E_Autorizados();
        NegAutorizados objNegAutorizado = new NegAutorizados();
        E_Categoria objECategoria = new E_Categoria();
        NegCategoria objNegCategoria = new NegCategoria();
        E_Producto objEProducto = new E_Producto();
        NegProducto objNegProducto = new NegProducto();
        NegVenta objNegVenta = new NegVenta();
        E_Ventas objEVenta = new E_Ventas();
        E_ProductoVenta objEProductoVenta = new E_ProductoVenta();
        NegProductoVenta objNegProductoVenta = new NegProductoVenta();

        public Form1()
        {
            InitializeComponent();

            CrearColumnas();
            CrearColumnasAut();
            CrearColumnasProd();
            CrearColumnasCat();
            lbltime.Text = DateTime.Now.ToString();
            BTVenta.BackgroundImageLayout = ImageLayout.Stretch;
            BTRemover.BackgroundImageLayout = ImageLayout.Stretch;
            BTMasuno.BackgroundImageLayout = ImageLayout.Stretch;
            BTMenosuno.BackgroundImageLayout = ImageLayout.Stretch;
            BTCancelar.BackgroundImageLayout = ImageLayout.Stretch;
            CBProducto.AutoCompleteMode = AutoCompleteMode.Suggest;

            #region ToolTip

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

            #endregion
        }
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
            LlenarDGVCat();
            LlenarDGVProd();
            LlenarCbCat();
            LlenarCbProductos();
            MostarAut();
            LlenarCbClientes();
        }

        #region Proveedor

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
            else if (dgvProv.SelectedRows.Count <= 0)
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
            else if (dgvCliente.SelectedRows.Count <= 0)
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

            dgvAutorizados.Columns[0].Visible = false;
        }

        private void MostarAut()
        {
            lblAut.Text = lblAut.Text + NombreAutorizado;          
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
        }     

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
            else if (dgvAutorizados.SelectedRows.Count <= 0)
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
        #endregion

        #region Producto

        private void CrearColumnasProd()
        {
            dgvProductos.ColumnCount = 7;
            dgvProductos.Columns[0].HeaderText = "Id";
            dgvProductos.Columns[1].HeaderText = "Codigo";
            dgvProductos.Columns[2].HeaderText = "Nombre";
            dgvProductos.Columns[3].HeaderText = "Stock";
            dgvProductos.Columns[4].HeaderText = "Precio de compra";
            dgvProductos.Columns[5].HeaderText = "Precio de venta";
            dgvProductos.Columns[6].HeaderText = "Categoría";

            dgvProductos.Columns[0].Visible = false;

        }

        private void LlenarDGVProd()
        {
            dgvProductos.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegProducto.ListandoProductos("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvProductos.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
            }
        }

        private void LimpiarTxtProd()
        {
            txtCodProd.Text = "";
            txtNomProd.Text = "";
            txtStockP.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
        }

        private void btnGProd_Click(object sender, EventArgs e)
        {
            if (editarse == false)
            {
                try
                {
                    objEProducto.Cod_prod = Convert.ToInt32(txtCodProd.Text);
                    objEProducto.Nombre_prod = txtNomProd.Text;
                    objEProducto.Stock_prod = Convert.ToInt32(txtStockP.Text);
                    objEProducto.P_compra = Convert.ToDecimal(txtPrecioCompra.Text);
                    objEProducto.P_venta = Convert.ToDecimal(txtPrecioVenta.Text);
                    objEProducto.Idcat = Convert.ToInt32(cbCategoria.SelectedIndex);

                    objNegProducto.InsertandoProducto("Alta", objEProducto);
                    MessageBox.Show("Producto guardado");
                    LlenarDGVProd();
                    LimpiarTxtProd();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo guardar el producto" + ex);
                }
            }

            if (editarse == true)
            {
                try
                {
                    objEProducto.Id = Convert.ToInt32(idproducto);
                    objEProducto.Cod_prod = Convert.ToInt32(txtCodProd.Text);
                    objEProducto.Nombre_prod = txtNomProd.Text;
                    objEProducto.Stock_prod = Convert.ToInt32(txtStockP.Text);
                    objEProducto.P_compra = Convert.ToDecimal(txtPrecioCompra.Text);
                    objEProducto.P_venta = Convert.ToDecimal(txtPrecioVenta.Text);
                    objEProducto.Idcat = Convert.ToInt32(cbCategoria.SelectedIndex);


                    objNegProducto.EditandoProducto("Modificar", objEProducto);

                    MessageBox.Show("Producto editado");
                    LimpiarTxtProd();
                    LlenarDGVProd();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo editar el producto" + ex);
                }
            }
        }

        private void btnEdProd_Click(object sender, EventArgs e)
        {
            editarse = true;

            if (dgvProductos.SelectedRows.Count > 0)
            {
                idproducto = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                txtCodProd.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                txtNomProd.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                txtStockP.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                txtPrecioCompra.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
                txtPrecioVenta.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
                cbCategoria.Text = dgvProductos.CurrentRow.Cells[6].Value.ToString();

            }
            else if (dgvProductos.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione el producto que desea editar");
            }
        }

        private void btnElProd_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                objEProducto.Id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                objNegProducto.EditandoProducto("Eliminar", objEProducto);

                MessageBox.Show("Se eliminó el producto correctamente");
                LlenarDGVProd();
            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea eliminar");
            }
        }

        #endregion

        #region Categorias

        private void CrearColumnasCat()
        {
            dgvCategorias.ColumnCount = 3;
            dgvCategorias.Columns[0].HeaderText = "Id";
            dgvCategorias.Columns[1].HeaderText = "Nombre";
            dgvCategorias.Columns[2].HeaderText = "Código";

            dgvCategorias.Columns[0].Visible = false;
        }

        private void LimpiarTxtCat()
        {
            txtCodCat.Text = "";
            txtNomCat.Text = "";

            txtCodCat.Focus();
        }

        private void LlenarDGVCat()
        {
            dgvCategorias.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegCategoria.ListandoCategorias("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvCategorias.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
            }
            else
                MessageBox.Show("No hay categorias cargadas en el sistema");
        }

        private void LlenarCbCat()
        
        {
            cbCategoria.Items.Clear();
            Datos.DatosConexionDB datosConexionDB = new Datos.DatosConexionDB();
            datosConexionDB.AbrirConexion();
            SqlCommand cmd = new SqlCommand("select * from categoria", datosConexionDB.Conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbCategoria.Items.Add(dr[1].ToString());
                cbCategoria.ValueMember = dr[0].ToString(); ;
            }
            datosConexionDB.CerrarConexion();
            cbCategoria.Items.Insert(0, "");
            cbCategoria.SelectedIndex = 0;
        }

        private void btnGCat_Click(object sender, EventArgs e)
        {
            if (editarse == false)
            {
                try
                {
                    objECategoria.Cod = txtCodCat.Text;
                    objECategoria.Name = txtNomCat.Text;

                    objNegCategoria.InsertandoCategoria("Alta", objECategoria);
                    MessageBox.Show("Categoría guardada");
                    LlenarDGVCat();
                    LimpiarTxtCat();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo guardar la categoría" + ex);
                }
            }

            if (editarse == true)
            {
                try
                {
                    objECategoria.Id = Convert.ToInt32(ID);
                    objECategoria.Cod = txtCodCat.Text;
                    objECategoria.Name = txtNomCat.Text;

                    objNegCategoria.EditandoCategoria("Modificar", objECategoria);

                    MessageBox.Show("Categoría editada");
                    LimpiarTxtCat();
                    LlenarDGVCat();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo editar la categoria" + ex);
                }
            }
        }

        private void btnEdCat_Click(object sender, EventArgs e)
        {
            editarse = true;

            if (dgvCategorias.SelectedRows.Count > 0)
            {
                idcategoria = dgvCategorias.CurrentRow.Cells[0].Value.ToString();
                txtCodCat.Text = dgvAutorizados.CurrentRow.Cells[1].Value.ToString();
                txtNomCat.Text = dgvAutorizados.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la categoría que desea editar");
            }
        }

        private void btnElCat_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                objECategoria.Id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value.ToString());
                objNegCategoria.EliminandoCategoria("Eliminar", objECategoria);

                MessageBox.Show("Se eliminó la categoría correctamente");
                LlenarDGVCat();
            }
            else
            {
                MessageBox.Show("Seleccione la categoría que desea eliminar");
            }
        }

        #endregion

        #region Venta

        private void BTVenta_Click(object sender, EventArgs e)
        {
            
            try
            {
                objEProductoVenta.Id_producto = Convert.ToInt32(lblIdP.Text);
                objEProductoVenta.Cantidad = Convert.ToInt32(TxtCantidad.Text);
                objNegProducto.ActualizarStock("RestaStock", objEProductoVenta);
                objNegVenta.InsertandoVenta("Alta", objEVenta);

                objEVenta.Id_autorizado1 = IdAutorizado;
                objEVenta.Id_cliente1 = 0;
                objEVenta.Id_fpago1 = 0;
                objEVenta.Fecha_compra1 = (DateTime.Now).ToString();
                objEVenta.Hora_venta1 = "";
                objEVenta.Estado_trans1 = "";
                objEVenta.Num_Factura1 = "";


                MessageBox.Show("Venta realizada con éxito");
                DGVListaVenta.Rows.Clear();
                lbltotal.Text = "";
                TBStock.Text = "";
                TBPrecioU.Text = "";
                TBCode.Text = "";
                TBCategoría.Text = "";
                CBProducto.Items.Clear();
                TxtCantidad.Text = "";
                LlenarDGVProd();
            }
            catch (Exception)
            {

                MessageBox.Show ("La venta no se pudo realizar");
            }
        }

        private void LlenarCbProductos()
        {
            DataSet ds = new DataSet();
            ds = objNegProducto.ListandoProductos("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    CBProducto.Items.Add(dr["Nombre_producto"].ToString());
                    CBProducto.ValueMember = dr[0].ToString();
                }
            }
        }

        private void BTAgregar_Click(object sender, EventArgs e)
        {

            decimal precioxcantidad = Convert.ToInt32(TxtCantidad.Text) * Convert.ToInt32(TBPrecioU.Text);

            DGVListaVenta.Rows.Add(TxtCantidad.Text, CBProducto.Text, TBPrecioU.Text, precioxcantidad);

            decimal preciototal = 0;
            for (int i = 0; i < DGVListaVenta.Rows.Count; ++i)
            {
                preciototal += Convert.ToDecimal(DGVListaVenta.Rows[i].Cells[3].Value);
            }
            lbltotal.Text = "Total: $" + preciototal.ToString();

        }

        private void CBProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datos.DatosConexionDB datosConexionDB = new Datos.DatosConexionDB();
            string consulta = "Select * from producto where Nombre_producto = '" + CBProducto.Text + "'";
            SqlCommand cm = new SqlCommand(consulta, datosConexionDB.Conexion);
            datosConexionDB.AbrirConexion();

            SqlDataReader leer = cm.ExecuteReader();

            if (leer.Read() == true)
            {
                TBStock.Text = leer["Stock_producto"].ToString();
                TBPrecioU.Text = leer["Preciouv_producto"].ToString();
                TBCode.Text = leer["Cod_producto"].ToString();
                TBCategoría.Text = leer["Id_categoria"].ToString();
                lblIdP.Text = leer["Id_producto"].ToString();
            }

            datosConexionDB.CerrarConexion();

        }

        #endregion

        private void LlenarCbClientes()
        {
            DataSet ds = new DataSet();
            ds = objNegCliente.ListandoClientes("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    CBCliente.Items.Add(dr["nombre_cliente"].ToString());
                    CBProducto.ValueMember = dr[0].ToString();
                }
            }
        }
    }
}