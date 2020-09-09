using System;
using System.Windows.Forms;
using Entidades;



namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double result;
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

            result = Calculadora.Operar(numero1, numero2, cmbOperador.Text);

            lblResultado.Text = result.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(txtNumero1.Text);
            lblResultado.Text = numero.DecimalBinario(txtNumero1.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero(txtNumero1.Text);
            lblResultado.Text = numero.BinarioDecimal(txtNumero1.Text);
        }
    }
}
