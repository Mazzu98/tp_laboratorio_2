
namespace WindowsForms
{
    partial class FormCompu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCompu));
            this.label1 = new System.Windows.Forms.Label();
            this.rbDesktop = new System.Windows.Forms.RadioButton();
            this.rbLaptop = new System.Windows.Forms.RadioButton();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPerisfericos = new System.Windows.Forms.CheckBox();
            this.cbBluetooth = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbGama = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // rbDesktop
            // 
            this.rbDesktop.AutoSize = true;
            this.rbDesktop.Location = new System.Drawing.Point(63, 45);
            this.rbDesktop.Name = "rbDesktop";
            this.rbDesktop.Size = new System.Drawing.Size(65, 17);
            this.rbDesktop.TabIndex = 1;
            this.rbDesktop.Text = "Desktop";
            this.rbDesktop.UseVisualStyleBackColor = true;
            this.rbDesktop.CheckedChanged += new System.EventHandler(this.rbDesktop_CheckedChanged);
            // 
            // rbLaptop
            // 
            this.rbLaptop.AutoSize = true;
            this.rbLaptop.Location = new System.Drawing.Point(134, 45);
            this.rbLaptop.Name = "rbLaptop";
            this.rbLaptop.Size = new System.Drawing.Size(58, 17);
            this.rbLaptop.TabIndex = 2;
            this.rbLaptop.TabStop = true;
            this.rbLaptop.Text = "Laptop";
            this.rbLaptop.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(32, 97);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(204, 20);
            this.txtId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gama: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Precio";
            // 
            // cbPerisfericos
            // 
            this.cbPerisfericos.AutoSize = true;
            this.cbPerisfericos.Location = new System.Drawing.Point(32, 225);
            this.cbPerisfericos.Name = "cbPerisfericos";
            this.cbPerisfericos.Size = new System.Drawing.Size(80, 17);
            this.cbPerisfericos.TabIndex = 6;
            this.cbPerisfericos.Text = "Perisfericos";
            this.cbPerisfericos.UseVisualStyleBackColor = true;
            // 
            // cbBluetooth
            // 
            this.cbBluetooth.AutoSize = true;
            this.cbBluetooth.Location = new System.Drawing.Point(32, 225);
            this.cbBluetooth.Name = "cbBluetooth";
            this.cbBluetooth.Size = new System.Drawing.Size(71, 17);
            this.cbBluetooth.TabIndex = 6;
            this.cbBluetooth.Text = "Bluetooth";
            this.cbBluetooth.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(32, 284);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(161, 284);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbGama
            // 
            this.cmbGama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGama.FormattingEnabled = true;
            this.cmbGama.Items.AddRange(new object[] {
            "Baja",
            "Media",
            "Alta"});
            this.cmbGama.Location = new System.Drawing.Point(32, 141);
            this.cmbGama.Name = "cmbGama";
            this.cmbGama.Size = new System.Drawing.Size(204, 21);
            this.cmbGama.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.DecimalPlaces = 2;
            this.txtPrecio.Location = new System.Drawing.Point(32, 188);
            this.txtPrecio.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(204, 20);
            this.txtPrecio.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(203, 225);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 32);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FormCompu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 328);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.cmbGama);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbBluetooth);
            this.Controls.Add(this.cbPerisfericos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.rbLaptop);
            this.Controls.Add(this.rbDesktop);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCompu";
            this.Text = "FormCompu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCompu_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDesktop;
        private System.Windows.Forms.RadioButton rbLaptop;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbPerisfericos;
        private System.Windows.Forms.CheckBox cbBluetooth;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbGama;
        private System.Windows.Forms.NumericUpDown txtPrecio;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}