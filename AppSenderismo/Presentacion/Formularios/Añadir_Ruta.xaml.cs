using AppSenderismo.Dominio;
using System;
using System.Collections;
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
    /// Lógica de interacción para Añadir_Ruta.xaml
    /// </summary>
    public partial class Añadir_Ruta : Window
    {
        List<Guia> ListGuia;
        List<Pdi> ListPdi;
        List<Ruta> ListRuta;
        public Añadir_Ruta(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRuta)
        {
            InitializeComponent();
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRuta = ListRuta;

            for (int i = 0; i < ListGuia.Count; i++)
            {
                Guia_lst.Items.Add(ListGuia[i].getNombre());
            }

            for (int i = 0; i < ListPdi.Count; i++)
            {
                Pdi_lst.Items.Add(ListPdi[i].getNombre());
            }

        }

        private void Añadir_Btm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reset();

                if(Check() == 1)
                {
                    MessageBox.Show("Error: ¡Debes rellenar todos los huecos y seleccionar todas las opciones!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                String Guia = Guia_lst.Items[Guia_lst.SelectedIndex].ToString();
                String Pdi = Pdi_lst.Items[Pdi_lst.SelectedIndex].ToString();
                String Dificultad = Dificultad_lst.Items[Dificultad_lst.SelectedIndex].ToString();
                String fecha = Dias_combo.SelectedItem.ToString() + "/" + Mes_combo.SelectedItem.ToString() + "/" + Año_combo.SelectedItem.ToString();
                int Num_excursionistas = Convert.ToInt32(NumeroExcursionistas_txt.Text);

                if (20 < Num_excursionistas || Num_excursionistas < 4)
                {
                    MessageBox.Show("El numero de Excursionistas tiene que estar entre 4 y 20", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    NumeroExcursionistas_txt.Background = Brushes.LightPink;
                }
                else
                {
                    int GuiaPos = 0;
                    int PdiPos = 0;

                    Boolean exists = false;

                    for (int i = 0; i < ListGuia.Count; i++)
                    {
                        if (ListGuia[i].getNombre() == Guia) { GuiaPos = i; break; }
                    }

                    for (int i = 0; i < ListPdi.Count; i++)
                    {
                        if (ListPdi[i].getNombre() == Pdi) { PdiPos = i; break; }
                    }

                    Ruta r = new Ruta(Convert.ToString(Nombre_txt.Text), Convert.ToString(Origen_txt.Text), Convert.ToString(Destino_txt.Text), fecha, Dificultad, ListGuia[GuiaPos], Num_excursionistas, Convert.ToInt32(Tiempo_txt.Text), Convert.ToString(Acceso_txt.Text), Convert.ToString(Vuelta_txt.Text), Convert.ToString(Material_txt.Text), ListPdi[PdiPos], false);

                    for (int i = 0; i < ListRuta.Count; i++)
                    {
                        if (ListRuta[i].getNombre() == r.getNombre()) { exists = true; MessageBox.Show("No se ha podido añadir la ruta por que ya existe!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); break; }
                    }
                    if (!exists)
                    {
                        ListRuta.Add(r);
                        MessageBox.Show("¡Ruta añadida con exito!");                       
                        LimpiarBox();
                    }
                }

                Rutas rutas = new Rutas(ListGuia, ListPdi, ListRuta);
                rutas.Modificar_Btm.IsEnabled = true;
                rutas.Eliminar_Btm.IsEnabled = true;

            }
            catch (FormatException)
            {
                MessageBox.Show("Error: ¡Hay campos cuyos valores no están bien puestos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                int temp = 0;

                if (int.TryParse(Tiempo_txt.Text, out temp) == false)
                {
                    Tiempo_txt.Background = Brushes.LightPink;
                }

                if (int.TryParse(NumeroExcursionistas_txt.Text, out temp) == false)
                {
                    NumeroExcursionistas_txt.Background = Brushes.LightPink;
                }
            }

        }

        public void Reset()
        {
            Nombre_txt.Background = Brushes.White;
            Origen_txt.Background = Brushes.White;
            Destino_txt.Background = Brushes.White;
            Acceso_txt.Background = Brushes.White;
            Vuelta_txt.Background = Brushes.White;
            Fecha1_lbl.Foreground = Brushes.Black;
            Tiempo_txt.Background = Brushes.White;
            NumeroExcursionistas_txt.Background = Brushes.White;
            Material_txt.Background = Brushes.White;
            Dificultad_lst.Background = Brushes.White;
            Guia_lst.Background = Brushes.White;
            Pdi_lst.Background = Brushes.White;
        }

        public void LimpiarBox()
        {
            Nombre_txt.Clear();
            Origen_txt.Clear();
            Destino_txt.Clear();
            Dias_combo.Text = null; 
            Mes_combo.Text = null;
            Año_combo.Text= null;
            NumeroExcursionistas_txt.Clear();
            Tiempo_txt.Clear();
            Acceso_txt.Clear();
            Vuelta_txt.Clear();
            Material_txt.Clear();
            Guia_lst.SelectedIndex= -1;
            Pdi_lst.SelectedIndex = -1;
            Dificultad_lst.SelectedIndex = -1;
        }

        public int Check()
        {
            int v = 0;

            if (string.IsNullOrEmpty(Nombre_txt.Text) || string.IsNullOrEmpty(Origen_txt.Text) || string.IsNullOrEmpty(Destino_txt.Text) || string.IsNullOrEmpty(Acceso_txt.Text) || string.IsNullOrEmpty(Vuelta_txt.Text) || string.IsNullOrEmpty(Dias_combo.Text) || string.IsNullOrEmpty(Mes_combo.Text) || string.IsNullOrEmpty(Año_combo.Text) || string.IsNullOrEmpty(Tiempo_txt.Text) || string.IsNullOrEmpty(NumeroExcursionistas_txt.Text) || string.IsNullOrEmpty(Material_txt.Text) || Guia_lst.SelectedIndex == -1 || Dificultad_lst.SelectedIndex == -1 || Pdi_lst.SelectedIndex == -1)
            {
                v = 1;
            }
            if (string.IsNullOrEmpty(Nombre_txt.Text))
            {
                Nombre_txt.Background = Brushes.LightPink;
            }

            if (string.IsNullOrEmpty(Origen_txt.Text))
            {
                Origen_txt.Background = Brushes.LightPink;
            }

            if (string.IsNullOrEmpty(Destino_txt.Text))
            {
                Destino_txt.Background = Brushes.LightPink;
            }

            if (string.IsNullOrEmpty(Acceso_txt.Text))
            {
                Acceso_txt.Background = Brushes.LightPink;
            }

            if (string.IsNullOrEmpty(Vuelta_txt.Text))
            {
                Vuelta_txt.Background = Brushes.LightPink;
            }

            if (string.IsNullOrEmpty(Dias_combo.Text))
            {
                Fecha1_lbl.Foreground = Brushes.LightPink;
            }

            if (string.IsNullOrEmpty(Mes_combo.Text))
            {
                Fecha1_lbl.Foreground = Brushes.Red;
            }

            if (string.IsNullOrEmpty(Año_combo.Text))
            {
                Fecha1_lbl.Foreground = Brushes.Red;
            }

            if (string.IsNullOrEmpty(Tiempo_txt.Text))
            {
                Tiempo_txt.Background = Brushes.Red;
            }

            if (string.IsNullOrEmpty(NumeroExcursionistas_txt.Text))
            {
                NumeroExcursionistas_txt.Background = Brushes.LightPink;
            }

            if (string.IsNullOrEmpty(Material_txt.Text))
            {
                Material_txt.Background = Brushes.LightPink;
            }

            if (Guia_lst.SelectedIndex == -1)
            {
                Guia_lst.Background = Brushes.LightPink;
            }

            if (Dificultad_lst.SelectedIndex == -1)
            {
                Dificultad_lst.Background = Brushes.LightPink;
            }

            if (Pdi_lst.SelectedIndex == -1)
            {
                Pdi_lst.Background = Brushes.LightPink;
            }

            return v;
        }

        private void Cancelar_Btm_Click(object sender, RoutedEventArgs e)
        {
            Rutas rutas = new Rutas(ListGuia, ListPdi, ListRuta);
            rutas.InitializeComponent();
            rutas.Show();
            this.Hide();

        }

        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Añadir Ruta: \n\tRellena todos los huecos de información, selecciona donde se pueda y presiona el botón de añadir", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Dias_combo_Initialized(object sender, EventArgs e)
        {
            for (int i = 1; i <32;i++)
            {
                Dias_combo.Items.Add(i.ToString());
            }
        }

        private void Mes_combo_Initialized(object sender, EventArgs e)
        {
            for (int i = 1; i < 13; i++)
            {
                Mes_combo.Items.Add(i.ToString());
            }
        }

        private void Año_combo_Initialized(object sender, EventArgs e)
        {
            Año_combo.Items.Add("2023");
            Año_combo.Items.Add("2024");
        }
    }
}
