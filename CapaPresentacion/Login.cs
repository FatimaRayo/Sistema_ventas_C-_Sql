using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

//creando clase para validar  usuario y contraseña//

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        //inicializamos la ventana 
        public Login()
        {
            InitializeComponent();
        }
        //declaramos un boton de cancelar, el cual solamente cierra el programa
        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        
        //declaramos un boton de ingresar el cual este hay un envento en cual valida si el usurio existe o no
        private void btningresar_Click(object sender, EventArgs e)
        {
            //validacion para que el usuario y la contraseña ingresada coincide 
            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();


            // si el usuario y la contraseña coincide, se inician las otras GUIS
            if (ousuario != null)
            {

                Inicio form = new Inicio(ousuario);

                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;

            }
            //si el usuario y la contraseña no coinciden, manda una ventana con la informacion mostrada
            else {
                MessageBox.Show("no se encontro el usuario","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

            

        }
         
        // solamente limpia los campos donde se ingresa el usuario y la contraseña
        private void frm_closing(object sender, FormClosingEventArgs e) {

            txtdocumento.Text = "";
            txtclave.Text = "";
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
