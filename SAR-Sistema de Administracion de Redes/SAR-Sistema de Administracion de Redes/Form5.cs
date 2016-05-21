using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAR_Sistema_de_Administracion_de_Redes
{
    public partial class Form5 : Form
    {
        
        EquiposService.EquiposClient obj = new EquiposService.EquiposClient();
        public Form5()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker1.MaxDate = DateTime.Now;
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength!=7){
                MessageBox.Show("La serie del equipo debe contener 7 caracteres.");
            }
            else if (textBox3.TextLength == 0 )
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }
            else  {
            EquiposService.Equipo objequipodetail = new EquiposService.Equipo();
            EquiposService.Equipo resultado = new EquiposService.Equipo();
            objequipodetail.Nu_serie = textBox1.Text;
            objequipodetail.Modelo = textBox3.Text;
            objequipodetail.Caracteris = textBox2.Text;
            objequipodetail.Estado = "STK";
            objequipodetail.Fecha_compra = dateTimePicker1.Text;
            resultado=obj.CrearEquipo(objequipodetail);
            if (resultado.Nu_serie != "")
            {
                MessageBox.Show("El Equipo con serie " + textBox1.Text + " fue registrado exitosamente");
                Form3 form3 = new Form3();
                form3.ReloadForm();
                form3.Update();
                form3.Refresh();
                Form5.ActiveForm.Visible = false;
            
            }
            else
            {
                MessageBox.Show("El Equipo con serie " + textBox1.Text + " ya existe!");

            }

            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5.ActiveForm.Visible = false;
        }
    }
}
