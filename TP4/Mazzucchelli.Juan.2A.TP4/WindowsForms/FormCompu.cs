using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FormCompu : Form
    {
        public delegate void DelegadoSinParam();
        /// <summary>
        /// Proyecto WindowsForms – FormCompu – evento
        /// </summary>
        public event DelegadoSinParam evento;

        protected Computadora c;
        protected Thread hilo;

        /// <summary>
        /// Accede a c de la clase
        /// </summary>
        /// <returns> Devuelve Computadora</returns>
        public Computadora Compu
        {
            get { return c; }
        }

        /// <summary>
        /// Inicializa el form (sin argumentos se usa para agregar)
        /// Inicia el hilo que rotará la imagen infinitas veces
        /// Proyecto WindowsForms – FormCompu – FormCompu()
        /// </summary>
        public FormCompu()
        {
            InitializeComponent();
            this.hilo = new Thread(this.ImagenRotacion);
            this.hilo.Start();
            
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Agregar";
            this.cbPerisfericos.Visible = false;
        }

        /// <summary>
        /// Inicializa el form con los datos de la computadora y si se modificará o eliminará
        /// </summary>
        /// <param name="c">Computadora</param>
        /// <param name="fc">EFormCompu</param>
        public FormCompu(Computadora c,EFormCompu fc)
            :this()
        {
            this.c = c;
            if(c is Desktop)
            {
                configuraFormDesktop((Desktop)c);
            }
            else if(c is Laptop)
            {
                configuraFormLaptop((Laptop)c);
            }
            if(fc == EFormCompu.Modificar)
            {
                configurarFormModificar();
            }
            else if(fc == EFormCompu.Eliminar)
            {
                configurarFormEliminar();
            }
            
        }

        /// <summary>
        /// Configura el form si recive un Desktop
        /// </summary>
        /// <param name="d">Desktop</param>
        private void configuraFormDesktop(Desktop d)
        {
            this.cbPerisfericos.Visible = true;
            this.cbBluetooth.Enabled = false;
            this.cbBluetooth.Visible = false;
            this.rbDesktop.Checked = true;
            this.txtId.Text = d.IdComputadora.ToString();
            switch(d.Gama)
            {
                case EGama.Baja:
                    this.cmbGama.SelectedIndex = 0;
                    break;
                case EGama.Media:
                    this.cmbGama.SelectedIndex = 1;
                    break;
                case EGama.Alta:
                    this.cmbGama.SelectedIndex = 2;
                    break;
            }
            this.txtPrecio.Text = d.Precio.ToString();
            this.cbPerisfericos.Checked = d.Perisfericos;
        }

        /// <summary>
        /// Configura el form si recive un Laptop
        /// </summary>
        /// <param name="l">Laptop</param>
        private void configuraFormLaptop(Laptop l)
        {
            this.cbPerisfericos.Enabled = false;
            this.cbPerisfericos.Visible = false;
            this.rbLaptop.Checked = true;
            this.txtId.Text = l.IdComputadora.ToString();
            switch (l.Gama)
            {
                case EGama.Baja:
                    this.cmbGama.SelectedIndex = 0;
                    break;
                case EGama.Media:
                    this.cmbGama.SelectedIndex = 1;
                    break;
                case EGama.Alta:
                    this.cmbGama.SelectedIndex = 2;
                    break;
            }
            this.txtPrecio.Text = l.Precio.ToString();
            this.cbBluetooth.Checked = l.Bluetooth;
        }

        /// <summary>
        /// Configura el form si es para modificar
        /// </summary>
        private void configurarFormModificar()
        {
            this.Text = "Modificar";
            this.rbDesktop.Enabled = false;
            this.rbLaptop.Enabled = false;
            this.txtId.Enabled = false;
        }

        /// <summary>
        /// Configura el form si es para eliminar
        /// </summary>
        private void configurarFormEliminar()
        {
            this.Text = "Eliminar";
            this.rbDesktop.Enabled = false;
            this.rbLaptop.Enabled = false;
            this.txtId.Enabled = false;
            this.txtPrecio.Enabled = false;
            this.cmbGama.Enabled = false;
            this.cbBluetooth.Enabled = false;
            this.cbPerisfericos.Enabled = false;
        }

        /// <summary>
        /// Si el radio button cambia se habilitará la opcion correspondiente para Desktop o Laptop
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void rbDesktop_CheckedChanged(object sender, EventArgs e)
        {
            if(rbDesktop.Checked)
            {
                this.cbBluetooth.Enabled = false;
                this.cbBluetooth.Visible = false;
                this.cbPerisfericos.Enabled = true;
                this.cbPerisfericos.Visible = true;
            }
            else
            {
                this.cbBluetooth.Enabled = true;
                this.cbBluetooth.Visible = true;
                this.cbPerisfericos.Enabled = false;
                this.cbPerisfericos.Visible = false;
            }
        }

        /// <summary>
        /// Se acepta la operacion y se devuelve un DialogResult.OK
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(this.txtId.Text,out id);
            EGama gama = EGama.Baja;
            switch(this.cmbGama.SelectedIndex)
            {
                case 0:
                    gama = EGama.Baja;
                    break;
                case 1:
                    gama = EGama.Media;
                    break;
                case 2:
                    gama = EGama.Alta;
                    break;
            }
            float precio = 0;
            float.TryParse(this.txtPrecio.Text,out precio);
            bool bluetooth = this.cbBluetooth.Checked;
            bool perisfericos = this.cbPerisfericos.Checked;

            if(this.rbDesktop.Checked == true)
            {
                this.c = new Desktop(id,ETipoPc.Desktop,gama,precio,perisfericos);
            }
            else if (this.rbLaptop.Checked == true)
            {
                this.c = new Laptop(id, ETipoPc.Laptop, gama, precio, bluetooth);
            }

            evento.Invoke();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// se cancela la operacion
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            evento.Invoke();
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Cierra el hilo
        /// </summary>
        public void CerrarHilo()
        {
            this.hilo.Abort();
        }

        /// <summary>
        /// Rota infinitamente la imagen de una computadora
        /// </summary>
        private void ImagenRotacion()
        {
            
            Image flipImage = this.pictureBox1.Image;
            Bitmap bitmap = new Bitmap(flipImage);

            while (true)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
                this.pictureBox1.Image = bitmap;
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Cuando se cierre el form con la cruz se invocará el evento
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void FormCompu_FormClosing(object sender, FormClosingEventArgs e)
        {
            evento.Invoke();
        }
    }
}
