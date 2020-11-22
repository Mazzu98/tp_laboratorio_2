using Archivos;
using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FormPrincipal : Form
    {
        private DataTable dt;
        private SqlDataAdapter da;

        private const string PATH_DATOS = "Datos.xml";
        private const string PATH_SCHEMA= "Esquema.xml";

        /// <summary>
        /// Constructor: configura el form
        /// </summary>
        public FormPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (!this.ConfigurarDataAdapter())
            {
                MessageBox.Show("ERROR AL CONFIGURAR EL DATAADAPTER!!!");
                Application.Exit();
            }
            this.ConfigurarDataTable();

            try
            {
                this.da.Fill(this.dt);
                this.ConfigurarGrilla();
                this.dataGridView1.DataSource = this.dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// compara dos Laptops
        /// Proyecto WindowsForms – FormPrincipal – Metodo ConfigurarDataAdapter 
        /// </summary>
        /// <returns> Devuelve true si pudo conectarse y false si no</returns>
        private bool ConfigurarDataAdapter()
        {
            bool rta = false;

            try
            {
                SqlConnection cn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Vetna_Computadoras;Integrated Security=True");

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id, tipo, gama, precio, perisfericos, bluetooth FROM Computadoras", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO Computadoras (tipo, gama, precio, perisfericos, bluetooth) VALUES (@tipo, @gama, @precio, @perisfericos, @bluetooth)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE Computadoras SET tipo=@tipo, gama=@gama, precio=@precio, perisfericos=@perisfericos, bluetooth=@bluetooth WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM Computadoras WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.InsertCommand.Parameters.Add("@gama", SqlDbType.VarChar, 50, "gama");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.InsertCommand.Parameters.Add("@perisfericos", SqlDbType.Bit, 1, "perisfericos");
                this.da.InsertCommand.Parameters.Add("@bluetooth", SqlDbType.Bit, 1, "bluetooth");

                this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.UpdateCommand.Parameters.Add("@gama", SqlDbType.VarChar, 50, "gama");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.da.UpdateCommand.Parameters.Add("@perisfericos", SqlDbType.Bit, 1, "perisfericos");
                this.da.UpdateCommand.Parameters.Add("@bluetooth", SqlDbType.Bit, 1, "bluetooth");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                rta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return rta;
        }

        /// <summary>
        /// configura el dataTable
        /// </summary>
        private void ConfigurarDataTable()
        {
            this.dt = new DataTable("Persona");

            this.dt.Columns.Add("id", typeof(int));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1; 
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }

        /// <summary>
        /// Configura la grilla
        /// </summary>
        private void ConfigurarGrilla()
        {
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(138, 184, 187);

            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(190, 190, 190);

            this.dataGridView1.BackgroundColor = Color.Beige;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.GridColor = Color.Black;

            this.dataGridView1.AllowUserToResizeRows = false;

            this.dataGridView1.ReadOnly = false;

            this.dataGridView1.MultiSelect = false;

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(47, 79, 79);
            this.dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.RowHeadersVisible = false;

        }

        /// <summary>
        /// Abre el FormCompu para cargar una computadora nueva a la tabla
        /// Proyecto WindowsForms – FormPrincipal –  asigno función al evento
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormCompu frm = new FormCompu();
            frm.evento += frm.CerrarHilo;
            DialogResult rta = frm.ShowDialog();
            
            if(rta == DialogResult.OK)
            {
                DataRow fila = this.dt.NewRow();

                fila["tipo"] = frm.Compu.Tipo;
                fila["gama"] = frm.Compu.Gama;
                fila["precio"] = frm.Compu.Precio;
                if (frm.Compu is Desktop)
                {
                    fila["perisfericos"] = ((Desktop)frm.Compu).Perisfericos;
                    fila["bluetooth"] = false;
                }
                else if (frm.Compu is Laptop)
                {
                    fila["bluetooth"] = ((Laptop)frm.Compu).Bluetooth;
                    fila["perisfericos"] = false;
                }

                this.dt.Rows.Add(fila);
            }
        }

        /// <summary>
        /// Abre el FormCompu para modificar una computadora de la tabla
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int i = this.dataGridView1.SelectedRows[0].Index;
            try
            {
                DataRow fila = this.dt.Rows[i];
                Computadora compu = TomarDatosDeFila(fila);

                FormCompu frm = new FormCompu(compu, EFormCompu.Modificar);
                frm.evento += frm.CerrarHilo;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    fila["gama"] = frm.Compu.Gama;
                    fila["precio"] = frm.Compu.Precio;
                    if (frm.Compu.Tipo == ETipoPc.Desktop)
                    {
                        fila["perisfericos"] = ((Desktop)frm.Compu).Perisfericos;
                    }

                    if (frm.Compu.Tipo == ETipoPc.Laptop)
                    {
                        fila["bluetooth"] = ((Laptop)frm.Compu).Bluetooth;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("La fila seleccionada no contiene un elemento");
            }
        }

        /// <summary>
        /// Abre el FormCompu para mostrar los datos de la computadora que se desea eliminar
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            { 
                DataRowView fila = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;

                Computadora compu = TomarDatosDeFila(fila.Row);

                FormCompu frm = new FormCompu(compu, EFormCompu.Eliminar);
                frm.evento += frm.CerrarHilo;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    fila.Delete();
                }
                dataGridView1.Rows[0].Selected = true;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("La fila seleccionada no contiene un elemento");
            }
        }

        /// <summary>
        /// Muestra el ticket de la venta y pregunta si deseas realizzarla, si es así lo elimina de la lista y guarda el ticket en un archivo de texto
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            
            string ticket;
            DataRowView fila = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
            Computadora compu = TomarDatosDeFila(fila.Row);
            Tickets t = new Tickets();
            ticket = t.hacerTicket(compu);
            DialogResult dialogResult = MessageBox.Show(ticket, "Ticket",MessageBoxButtons.OKCancel);

            if(dialogResult == DialogResult.OK)
            {
                try
                {
                    Texto txt = new Texto();
                    if(t.GuardarTicket($"id_{fila["id"]}_ticket.txt", ticket))
                    {
                        MessageBox.Show("Ticket guardado");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                fila.Delete();
            }
            dataGridView1.Rows[0].Selected = true;
        }

        /// <summary>
        /// Toma los datos de la fila y los devuelve como una Computadora
        /// </summary>
        /// <param name="fila">DataRow</param>
        /// <returns> Devuelve una Computadora con los datos de la fila</returns>
        private Computadora TomarDatosDeFila(DataRow fila)
        {
            int id = Int32.Parse(fila["id"].ToString());
            EGama gama = default;
            switch (fila["gama"])
            {
                case "Baja":
                    gama = EGama.Baja;
                    break;
                case "Media":
                    gama = EGama.Media;
                    break;
                case "Alta":
                    gama = EGama.Alta;
                    break;
            }

            ETipoPc tipo = default;
            switch (fila["tipo"])
            {
                case "Desktop":
                    tipo = ETipoPc.Desktop;
                    break;
                case "Laptop":
                    tipo = ETipoPc.Laptop;
                    break;
            }
            float precio = float.Parse(fila["precio"].ToString());
            Computadora compu = default;
            if (tipo == ETipoPc.Desktop)
            {
                bool perisfericos = bool.Parse(fila["perisfericos"].ToString());
                compu = new Desktop(id, tipo, gama, precio, perisfericos);
            }
            else if (tipo == ETipoPc.Laptop)
            {
                bool bluetooth = bool.Parse(fila["bluetooth"].ToString());
                compu = new Laptop(id, tipo, gama, precio, bluetooth);
            }
            return compu;
        }

        /// <summary>
        /// Sincroniza los cambios del data table con la base de datos mediante el SqlDataAdapter
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.da.Update(dt) > 0)
                {
                    MessageBox.Show("Datos sincronizados");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Los dato no se pudieron sincronizar");
            }
        }

        /// <summary>
        /// Guarda en archivos un xml el esquema de el DataTable y en otro los datos
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                this.dt.WriteXmlSchema(PATH_SCHEMA);
                this.dt.WriteXml(PATH_DATOS);
                MessageBox.Show("Se han guardado el esquema y los datos del DataTable!!!");

            }
            catch
            {
                MessageBox.Show("Error al guardar el DataTable. ",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
