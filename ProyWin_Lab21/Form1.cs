using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyWin_Lab21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Users\\angel\\Documents\\MeadeWillis";
            openFileDialog1.Filter = "Todos|*.*|Archivos de Texto(.txt)| *.txt| Archivos PDF(.pdf) | *.pdf";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLectura.Text = "";
                string ruta = openFileDialog1.FileName;
                StreamReader lector = new StreamReader(ruta);
                int contador =0;
                while (lector.ReadLine() != null)
                {
                    //Console.WriteLine(lector.ReadLine());
                    string lineaLeidaActual = lector.ReadLine();
                    txtLectura.Text += String.Format(lineaLeidaActual+"{0}",Environment.NewLine);
                    contador += 1;
                }
                lector.Dispose();
                txtLectura.Text +="Se han cargado un total de " +contador.ToString() + "líneas del archivo";
                txtLectura.ReadOnly = true;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtLectura.ReadOnly = false;
            MessageBox.Show("Has habilitado el textbox para editarlo");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.InitialDirectory = "C:\\Users\\angel\\Documents\\MeadeWillis";
                saveFileDialog1.Filter = "Archivos de Texto(.txt)| *.txt| Archivos PDF(.pdf) | *.pdf";
                //saveFileDialog1.ShowDialog(); Cada vez que llamo a esta función, se abre el explorador de archivos

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string rutaNuevoArchivo = saveFileDialog1.FileName;
                    StreamWriter escritor = new StreamWriter(rutaNuevoArchivo);
                    int contador = 0;

                    for (contador = 0; contador < txtLectura.Lines.Length; contador++)
                    {
                        escritor.WriteLine(txtLectura.Lines[contador]);
                    }

                    escritor.WriteLine("En total, hemos escrito:" + contador.ToString() + " líneas");
                    escritor.Dispose();
                    MessageBox.Show("Se han creado el archivo correctamente");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }

        }
    }
}
