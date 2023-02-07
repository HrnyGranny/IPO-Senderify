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

                    if (this.ListGuia[i].getNombre() == "Jose")
                    {
                        Guia_Img.Source = new BitmapImage(new Uri("/Imágenes/Jose.jpg", UriKind.Relative));
                    }

                    if (this.ListGuia[i].getNombre() == "Carmen")
                    {
                        Guia_Img.Source = new BitmapImage(new Uri("/Imágenes/Maria.jpg", UriKind.Relative));
                    }

                    if (this.ListGuia[i].getNombre() == "Carlos")
                    {
                        Guia_Img.Source = new BitmapImage(new Uri("/Imágenes/Carlos.jpg", UriKind.Relative));
                    }
                }
            }
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

                for (int j = 0; j < this.ListGuia.Count; j++)
                {
                    if (this.Guia == this.ListGuia[j].getNombre())
                    {
                        ListGuia[j].setApellido(Convert.ToString(Apellido_Txt.Text));
                        ListGuia[j].setIdioma(Convert.ToString(Idioma_Txt.Text));
                        ListGuia[j].setDisponibilidad(Convert.ToString(Disponibilidad_Txt.Text));
                        ListGuia[j].setTelefono(Convert.ToString(Telefono_Txt.Text));
                        ListGuia[j].setCorreo(Convert.ToString(Correo_Txt.Text));
                        ListGuia[j].setPuntuacion(Convert.ToDouble(Puntuacion_Txt.Text));
      
                        MessageBox.Show("¡Guia modificada con exito!");
                        IniciarGuias();
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Error: ¡Hay campos cuyos valores no están bien puestos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Puntuacion_Txt.Background = Brushes.LightPink;
            }
        }

        public void Reset()
        {           
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

            if (string.IsNullOrEmpty(Apellido_Txt.Text) || string.IsNullOrEmpty(Idioma_Txt.Text) || string.IsNullOrEmpty(Disponibilidad_Txt.Text) || string.IsNullOrEmpty(Telefono_Txt.Text) || string.IsNullOrEmpty(Correo_Txt.Text) || string.IsNullOrEmpty(Puntuacion_Txt.Text))
            {
                v = 1;
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

        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Modificar guia: \n\tRellena todos los huecos de información y presiona el botón de Modificar", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Cancelar_Btm_Click(object sender, RoutedEventArgs e)
        {
            Guias guias = new Guias(ListGuia, ListPdi, ListRutas);
            guias.InitializeComponent();
            guias.Show();
            this.Hide();
        }

        private void Fotos_combo_Initialized(object sender, EventArgs e)
        {
            Fotos_combo.Items.Add("Imagen 1");
            Fotos_combo.Items.Add("Imagen 2");
            Fotos_combo.Items.Add("Imagen 3");
        }   
    }
}
