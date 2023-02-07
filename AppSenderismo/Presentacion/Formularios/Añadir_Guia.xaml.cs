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
                Reset();

                if (Check() == 1)
                {
                    MessageBox.Show("Error: ¡Debes rellenar todos los huecos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Boolean exists = false;

                Guia g = new Guia(Convert.ToString(Nombre_Txt.Text), Convert.ToString(Apellido_Txt.Text), Convert.ToString(Idioma_Txt.Text), Convert.ToString(Disponibilidad_Txt.Text), Convert.ToString(Telefono_Txt.Text), Convert.ToString(Correo_Txt.Text), Convert.ToDouble(Puntuacion_Txt.Text));

                for (int i = 0; i < ListGuia.Count; i++)
                {
                    if (ListGuia[i].getNombre() == g.getNombre()) { exists = true; MessageBox.Show("No se ha podido añadir la guia por que ya existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); break; }
                }
                if (!exists)
                {
                    ListGuia.Add(g);
                    MessageBox.Show("¡Guia añadida con éxito!");
                    LimpiarBox();
                }

                Guias guias = new Guias(ListGuia, ListPdi, ListRutas);
                guias.Modificar_Btm.IsEnabled = true;
                guias.Eliminar_Btm.IsEnabled = true;

            }
            catch (FormatException)
            {
                MessageBox.Show("Error: ¡Hay campos cuyos valores no están bien puestos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Puntuacion_Txt.Background = Brushes.LightPink;
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

        public void Reset()
        {
            Nombre_Txt.Background = Brushes.White;
            Apellido_Txt.Background = Brushes.White;
            Idioma_Txt.Background = Brushes.White;
            Disponibilidad_Txt.Background = Brushes.White;
            Telefono_Txt.Background = Brushes.White;
            Correo_Txt.Background = Brushes.White;
            Puntuacion_Txt.Background = Brushes.White;
        }

        public int Check()
        {
            int v = 0;

            if (string.IsNullOrEmpty(Nombre_Txt.Text) || string.IsNullOrEmpty(Apellido_Txt.Text) || string.IsNullOrEmpty(Idioma_Txt.Text) || string.IsNullOrEmpty(Disponibilidad_Txt.Text) || string.IsNullOrEmpty(Telefono_Txt.Text) || string.IsNullOrEmpty(Correo_Txt.Text) || string.IsNullOrEmpty(Puntuacion_Txt.Text))
            {
                v = 1;
            }
            if (string.IsNullOrEmpty(Nombre_Txt.Text))
            {
                Nombre_Txt.Background = Brushes.LightPink;
            }
            if (string.IsNullOrEmpty(Apellido_Txt.Text))
            {
                Apellido_Txt.Background = Brushes.LightPink;
            }
            if (string.IsNullOrEmpty(Idioma_Txt.Text))
            {
                Idioma_Txt.Background = Brushes.LightPink;
            }
            if (string.IsNullOrEmpty(Disponibilidad_Txt.Text))
            {
                Disponibilidad_Txt.Background = Brushes.LightPink;
            }
            if (string.IsNullOrEmpty(Telefono_Txt.Text))
            {
                Telefono_Txt.Background = Brushes.LightPink;
            }
            if (string.IsNullOrEmpty(Correo_Txt.Text))
            {
                Correo_Txt.Background = Brushes.LightPink;
            }
            if (string.IsNullOrEmpty(Puntuacion_Txt.Text))
            {
                Puntuacion_Txt.Background = Brushes.LightPink;
            }

            return v;
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
            MessageBox.Show("Añadir Guia: \n\tRellena todos los huecos de información y presiona el botón de añadir", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Fotos_combo_Initialized(object sender, EventArgs e)
        {
            Fotos_combo.Items.Add("Imagen 1");
            Fotos_combo.Items.Add("Imagen 2");
            Fotos_combo.Items.Add("Imagen 3");
        }
    }
}
