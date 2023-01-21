using AppSenderismo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppSenderismo.Presentacion.Formularios
{
    /// <summary>
    /// Lógica de interacción para Modificar_Guia.xaml
    /// </summary>
    public partial class Modificar_Guia : Window
    {
        List<Guia> ListGuia;
        List<Pdi> ListPdi;
        List<Ruta> ListRutas;
        String Guia;
        public Modificar_Guia(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas, String Guia)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            this.Guia = Guia;
            InitializeComponent();
            IniciarGuias();
        }

        public void IniciarGuias()
        {
            for (int i = 0; i < ListGuia.Count; i++)
            {
                if (this.Guia == ListGuia[i].getNombre())
                {
                    Nombre_lbl_use.Content = this.Guia;
                    Apellido_Txt.Text = ListGuia[i].getApellido();
                    Idioma_Txt.Text = ListGuia[i].getIdioma();
                    Disponibilidad_Txt.Text = ListGuia[i].getDisponibilidad();
                    Telefono_Txt.Text = ListGuia[i].getTelefono();
                    Correo_Txt.Text = ListGuia[i].getCorreo();
                    Puntuacion_Txt.Text = Convert.ToString(ListGuia[i].getPuntuacion());
                }
            }
        }

        private void Añadir_Btm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int j = 0; j < this.ListGuia.Count; j++)
                {
                    if (this.Guia == this.ListGuia[j].getNombre())
                    {
                        ListGuia[j].setApellido(Convert.ToString(Apellido_Txt.Text));
                        ListGuia[j].setIdioma(Convert.ToString(Idioma_Txt.Text));
                        ListGuia[j].setDisponibilidad(Convert.ToString(Disponibilidad_Txt.Text));
                        ListGuia[j].setTelefono(Convert.ToString(Telefono_Txt.Text));
                        ListGuia[j].setCorreo(Convert.ToString(Correo_Txt.Text));
                        ListGuia[j].setPuntuacion(Convert.ToDouble(Puntuacion_Txt.Text) / 100);
      
                        MessageBox.Show("Guia modificada");
                        IniciarGuias();
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Error: hay campos cuyos valores no están bien puestos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Modificar guia: \n\t Rellena todos los huecos de información y presiona el botón de Modificar \n Cancelar: \n\t Presiona el botón con la X en rojo", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancelar_Btm_Click(object sender, RoutedEventArgs e)
        {
            Guias guias = new Guias(ListGuia, ListPdi, ListRutas);
            guias.InitializeComponent();
            guias.Show();
            this.Hide();
        }
    }
}
