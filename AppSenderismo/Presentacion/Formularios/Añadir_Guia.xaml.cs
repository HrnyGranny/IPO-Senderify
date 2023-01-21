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
    /// Lógica de interacción para Añadir_Guia.xaml
    /// </summary>
    public partial class Añadir_Guia : Window
    {
        List<Pdi> ListPdi = new List<Pdi>();
        List<Guia> ListGuia = new List<Guia>();
        List<Ruta> ListRutas = new List<Ruta>();
        public Añadir_Guia(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            InitializeComponent();
        }

        private void Añadir_Btm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Boolean exists = false;

                Guia g = new Guia(Convert.ToString(Nombre_Txt.Text), Convert.ToString(Apellido_Txt.Text), Convert.ToString(Idioma_Txt.Text), Convert.ToString(Disponibilidad_Txt.Text), Convert.ToString(Telefono_Txt.Text), Convert.ToString(Correo_Txt.Text), Convert.ToDouble(Puntuacion_Txt.Text));

                for (int i = 0; i < ListGuia.Count; i++)
                {
                    if (ListGuia[i].getNombre() == g.getNombre()) { exists = true; MessageBox.Show("No se ha podido añadir la guia por que ya existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); break; }
                }
                if (!exists)
                {
                    ListGuia.Add(g);
                    MessageBox.Show("Guia añadida");
                    LimpiarBox();
                }

                Guias guias = new Guias(ListGuia, ListPdi, ListRutas);
                guias.Modificar_Btm.IsEnabled = true;
                guias.Eliminar_Btm.IsEnabled = true;
                guias.Info_Btm.IsEnabled=true;

            }
            catch (FormatException)
            {
                MessageBox.Show("Error: hay campos cuyos valores no están bien puestos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LimpiarBox()
        {
            Nombre_Txt.Clear();
            Apellido_Txt.Clear();
            Idioma_Txt.Clear();
            Disponibilidad_Txt.Clear();
            Telefono_Txt.Clear();
            Correo_Txt.Clear();
            Puntuacion_Txt.Clear();
       
        }

        private void Cancelar_Btm_Click(object sender, RoutedEventArgs e)
        {
            Guias guias = new Guias(ListGuia,ListPdi,ListRutas);
            guias.InitializeComponent();
            guias.Show();
            this.Hide();
        }

        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Añadir Guia: \n\t Rellena todos los huecos de información y presiona el botón de aceptar \n Cancelar: \n\t Presiona el botón con la X en rojo", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
