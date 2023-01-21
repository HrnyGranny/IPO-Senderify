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
                if (Guia_lst.SelectedIndex != -1 && Pdi_lst.SelectedIndex != -1 && Dificultad_lst.SelectedIndex != -1)
                {
                    String Guia = Guia_lst.Items[Guia_lst.SelectedIndex].ToString();
                    String Pdi = Pdi_lst.Items[Pdi_lst.SelectedIndex].ToString();
                    String Dificultad = Dificultad_lst.Items[Dificultad_lst.SelectedIndex].ToString();
                    String fecha = Convert.ToString(Fecha1_txt.Text) + "/" + Convert.ToString(Fecha2_txt.Text) + "/" + Convert.ToString(Fecha3_txt.Text);
                    int Num_excursionistas = Convert.ToInt32(NumeroExcursionistas_txt.Text);

                    if(20 < Num_excursionistas || Num_excursionistas < 4)
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
                            MessageBox.Show("Ruta añadida");
                            Dificultad_lst.Background = Brushes.White;
                            Guia_lst.Background = Brushes.White;
                            Pdi_lst.Background = Brushes.White;
                            NumeroExcursionistas_txt.Background = Brushes.White;
                            LimpiarBox();
                        }
                    }  
                }
                else
                {
                    MessageBox.Show("Selecciona todas las opciones!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Dificultad_lst.Background = Brushes.LightPink;
                    Guia_lst.Background = Brushes.LightPink;
                    Pdi_lst.Background = Brushes.LightPink;
                }

                Rutas rutas = new Rutas(ListGuia, ListPdi, ListRuta);
                rutas.Modificar_Btm.IsEnabled = true;
                rutas.Eliminar_Btm.IsEnabled = true;
                rutas.Info_Btm.IsEnabled = true;

            }
            catch (FormatException)
            {
                MessageBox.Show("Error: hay campos cuyos valores no están bien puestos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void LimpiarBox()
        {
            Nombre_txt.Clear();
            Origen_txt.Clear();
            Destino_txt.Clear();
            Fecha1_txt.Clear();
            Fecha2_txt.Clear();
            Fecha3_txt.Clear();
            NumeroExcursionistas_txt.Clear();
            Tiempo_txt.Clear();
            Acceso_txt.Clear();
            Vuelta_txt.Clear();
            Material_txt.Clear();
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
            MessageBox.Show("Añadir Ruta: \n\t Rellena todos los huecos de información, selecciona donde se pueda y presiona el botón de aceptar \n Cancelar: \n\t Presiona el botón con la X en rojo", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
