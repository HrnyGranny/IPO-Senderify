using AppSenderismo.Dominio;
using AppSenderismo.Presentacion.Formularios;
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

namespace AppSenderismo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Guias.xaml
    /// </summary>
    public partial class Guias : Window
    {
        List<Pdi> ListPdi = new List<Pdi>();
        List<Guia> ListGuia = new List<Guia>();
        List<Ruta> ListRutas = new List<Ruta>();
        public Guias(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas)
        {
            InitializeComponent();
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;

            for (int i = 0; i < ListGuia.Count; i++)
            {
                Guias_Lst.Items.Add(ListGuia[i].getNombre());
            }

            if (Guias_Lst.HasItems == false)
            {
                Modificar_Btm.IsEnabled = false;
                Eliminar_Btm.IsEnabled = false;
            }

        }

        public void Rellenar()
        {
            for (int i = 0; i < this.ListGuia.Count; i++)
            {
                try
                {
                    if (Guias_Lst.Items[Guias_Lst.SelectedIndex].ToString() == this.ListGuia[i].getNombre())
                    {
                        GuiaSelec.Content = Guias_Lst.Items[Guias_Lst.SelectedIndex];
                        GIApellido_Txt.Text = this.ListGuia[i].getApellido();
                        GIIdioma_Txt.Text = this.ListGuia[i].getIdioma();
                        GIDisponibilidad_Txt.Text = this.ListGuia[i].getDisponibilidad();
                        GITeléfono_Txt.Text = "" + this.ListGuia[i].getTelefono();
                        GICorreo_Txt.Text = "" + this.ListGuia[i].getCorreo();
                        GIPuntuación_Txt.Text = Convert.ToString(this.ListGuia[i].getPuntuacion());

                        if (this.ListGuia[i].getNombre() == "Jose")
                        {
                            Guia_Foto.Source = new BitmapImage(new Uri("/Imágenes/Jose.jpg", UriKind.Relative));
                        }

                        if (this.ListGuia[i].getNombre() == "Carmen")
                        {
                            Guia_Foto.Source = new BitmapImage(new Uri("/Imágenes/Maria.jpg", UriKind.Relative));
                        }

                        if (this.ListGuia[i].getNombre() == "Carlos")
                        {
                            Guia_Foto.Source = new BitmapImage(new Uri("/Imágenes/Carlos.jpg", UriKind.Relative));
                        }
                    }
                }
                catch(Exception ex)
                {
                    String e = ""+ex;
                }
            }

        }



        private void Eliminar_Btm_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Vas a eliminar un guia de forma definitiva, ¿Estas seguro?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                if (Guias_Lst.SelectedIndex != -1)
                {
                    String nombre = Guias_Lst.Items[Guias_Lst.SelectedIndex].ToString();
                    for (int i = 0; i < ListGuia.Count; i++)
                    {
                        if (nombre == ListGuia[i].getNombre())
                        {
                            Guias_Lst.UnselectAll();
                            GIApellido_Txt.Text = "";
                            GIIdioma_Txt.Text = "";
                            GIDisponibilidad_Txt.Text = "";
                            GITeléfono_Txt.Text = "";
                            GICorreo_Txt.Text = "";
                            GIPuntuación_Txt.Text = "";
                            Guia_Foto.Visibility= Visibility.Collapsed;
                            FotoPrueba.Visibility = Visibility.Visible;
                            ListGuia.Remove(ListGuia[i]);
                            MessageBox.Show("¡Guía eliminada con exito!");
                            Guias_Lst.Items.Clear();
                            GuiaSelec.Content = "Guía Seleccionada";
                            for (int j = 0; j < ListGuia.Count; j++)
                            {
                                {
                                    Guias_Lst.Items.Add(ListGuia[j].getNombre());
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona primero un guía!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (Guias_Lst.HasItems == false)
            {
                Modificar_Btm.IsEnabled = false;
                Eliminar_Btm.IsEnabled = false;

            }
        }

        private void Añadir_Btm_Click(object sender, RoutedEventArgs e)
        {
            Añadir_Guia añadir = new Añadir_Guia(this.ListGuia, this.ListPdi, this.ListRutas);
            añadir.InitializeComponent();
            añadir.Show();
            this.Hide();
        }

        private void Modificar_Btm_Click(object sender, RoutedEventArgs e)
        {
            if (Guias_Lst.SelectedIndex != -1)
            {
                String nombreGuia = Guias_Lst.Items[Guias_Lst.SelectedIndex].ToString();
                Modificar_Guia modificar = new Modificar_Guia(ListGuia, ListPdi, ListRutas, nombreGuia);
                modificar.InitializeComponent();
                modificar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selecciona primero una Guía!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Rutas_Btm_Click(object sender, RoutedEventArgs e)
        {
            Rutas rutas = new Rutas(ListGuia, ListPdi, ListRutas);
            rutas.InitializeComponent();
            rutas.Show();
            this.Hide();
        }

        private void Excursionistas_Btm_Click(object sender, RoutedEventArgs e)
        {
            Excursionistas excursionistas = new Excursionistas(ListGuia, ListPdi, ListRutas);
            excursionistas.InitializeComponent();
            excursionistas.Show();
            this.Hide();
        }

        private void Salida_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            User u = new User();
            this.Close();
            u.Show();
        }

        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Añadir: \n\tBotón para añadir Guias \n Modificar: \n\tBotón para modificar una Guia seleccionada \n Eliminar: \n\tBotón para eliminar una Guia seleccionada", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Guias_Lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FotoPrueba.Visibility= Visibility.Collapsed;
            Guia_Foto.Visibility = Visibility.Visible;
            Rellenar();
        }
    }
}

