using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP4
{
    public partial class Form1 : Form
    {
        //CREARLO SIEMPRE
        // objeto para la lista enlazada
        ListaEnlazada Movimientos = new ListaEnlazada();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipoMovimiento.Items.Add("Depósito");
            cmbTipoMovimiento.Items.Add("Extracción");
            cmbTipoMovimiento.SelectedIndex = 0;
        }


        //IGUAL
        //Agregamos los datos a un nuevo nodo de la lista Moviminetos
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Crear un nuevo nodo 
            Nodo nuevoMovimiento = new Nodo();

            //guardamos los datos
            nuevoMovimiento.CodigoSucursal = int.Parse(txtCodigoSucursal.Text);
            nuevoMovimiento.TipoMovimiento = cmbTipoMovimiento.SelectedIndex + 1;
            nuevoMovimiento.Cuenta = int.Parse(txtCuenta.Text);
            nuevoMovimiento.Fecha = dtpFecha.Value.Date; // para las fechas 
            nuevoMovimiento.Importe = int.Parse(txtImporte.Text);

            //Agreagmos al objeto creado arriba el nuevo movimiento 
            Movimientos.Insertar(nuevoMovimiento);

            // limpiar la interfaz
            txtCodigoSucursal.Text = "";
            txtConsultaCuenta.Text = "";
            txtCuenta.Text = "";
            txtImporte.Text = "";


            MessageBox.Show("Movimiento agregado correctamente.");
            // refrescar la grilla con los datos de los movimientos
            MostrarMovimientos();




        }


        //MOSTRAR EN EL DATAGRID
        private void MostrarMovimientos()
        {
            List<Nodo> mov = Movimientos.Listar(); // obtener la lista de movimientos


            grMovimientos.Rows.Clear(); // limpiar la grilla


            // recorrer todos los movimientos

            foreach (Nodo nodo in mov)
            {  //Agregamos los datos 
                grMovimientos.Rows.Add(
                    nodo.Cuenta.ToString(),
                    nodo.Fecha.ToString("dd/MM/yyyy"),
                    nodo.TipoMovimiento.ToString(),
                    nodo.Importe.ToString(),
                    nodo.CodigoSucursal.ToString()
                    );
            }




        }


        //BUSCAR NODO
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //guardamos el valor a buscar
            int cuentaBuscada = int.Parse(txtCuenta.Text);

            // Usamos el método Buscar de la lista enlazada
            Nodo nodoEncontrado = Movimientos.Buscar(cuentaBuscada);

            // Verificamos si el nodo fue encontrado
            if (nodoEncontrado != null)
            {
                // Si se encuentra, mostramos la información del nodo
                //MessageBox.Show($"Cuenta encontrada: {nodoEncontrado.Cuenta}\n" );

                MessageBox.Show($"Cuenta encontrada: {nodoEncontrado.Cuenta}\n" +
                                $"Importe: {nodoEncontrado.Importe}\n" +
                                $"Fecha: {nodoEncontrado.Fecha:dd/MM/yyyy}");
            }
            else
            {
                // Si no se encuentra, mostramos un mensaje de error
                MessageBox.Show("No se encontró ninguna cuenta con el número ingresado.");
            }
        }

        //ELIMINAR NODO
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //guardamos el valor a buscar
            int cuentaBuscada = int.Parse(txtCuenta.Text);


            Nodo nodoEncontrado = Movimientos.Eliminar(cuentaBuscada);

            if (nodoEncontrado != null)
            {
                MessageBox.Show($"Cuenta Eliminada: {nodoEncontrado.Cuenta}\n");
            }
            else
            {
                MessageBox.Show("No se encontró ninguna cuenta con el número ingresado.");

            }

            MostrarMovimientos();

        }

        //Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {

            //// Validar campos
            //if (string.IsNullOrWhiteSpace(txtCuenta.Text) || 
            //    string.IsNullOrWhiteSpace(txtCodigoSucursal.Text) ||
            //    string.IsNullOrWhiteSpace(txtImporte.Text))
            //{
            //    MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //Tomamos los datos nuevos 
            int cuentaBuscada = int.Parse(txtCuenta.Text);
            int nuevoCodigoSucursal = int.Parse(txtCodigoSucursal.Text);
            int nuevoTipoMovimiento = cmbTipoMovimiento.SelectedIndex + 1;
            int nuevoImporte = int.Parse(txtImporte.Text);
            DateTime nuevaFecha = dtpFecha.Value.Date;

            // Llamar al método Editar de la lista enlazada y le pasamos los nuevos valores por paramentros
            Nodo nodoEditado = Movimientos.Editar(cuentaBuscada, nuevoCodigoSucursal, nuevoTipoMovimiento, nuevoImporte, nuevaFecha);

            if (nodoEditado != null)
            {
                MessageBox.Show("Nodo editado correctamente.");
                MostrarMovimientos(); // Actualizar la vista
            }
            else
            {
                MessageBox.Show("No se encontró ninguna cuenta con el número ingresado.");
            }
        }

       //SUMAR SALDOS
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int tipoMovimiento = cmbTipoMovimiento.SelectedIndex + 1; // 1 para Depósito, 2 para Extracción

            int total = Movimientos.SumarSaldos(tipoMovimiento); // Obtener la suma

            // Mostrar el resultado en el txtConsultaCuenta
            txtConsultaCuenta.Text = $"Total: {total}";
        }
    }
}
