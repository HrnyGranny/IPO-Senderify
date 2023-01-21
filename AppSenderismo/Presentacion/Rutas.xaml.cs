using AppSenderismo.Dominio;
using AppSenderismo.Presentacion.Formularios;
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

namespace AppSenderismo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Rutas.xaml
    /// </summary>
    public partial class Rutas : Window
    {
        List<Pdi> ListPdi = new List<Pdi>();
        List<Guia> ListGuia = new List<Guia>();
        List<Ruta> ListRutas = new List<Ruta>();
        public Rutas(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            InitializeComponent();

            for (int i = 0; i < ListRutas.Count; i++)
            {
                if (ListRutas[i].getCheck() == false)
                {
                    Rutas_Lst.Items.Add(ListRutas[i].getNombre());
                }

            }

            if (Rutas_Lst.HasItems == false)
            {
                Modificar_Btm.IsEnabled = false;
                Eliminar_Btm.IsEnabled = false;
                Info_Btm.IsEnabled = false;

            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Rutas_Lst.Items.Clear();
            for (int i = 0; i < ListRutas.Count; i++)
            {
                Rutas_Lst.Items.Add(ListRutas[i].getNombre());
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Rutas_Lst.Items.Clear();
            for (int i = 0; i < ListRutas.Count; i++)
            {
                if (ListRutas[i].getCheck() == false)
                {
                    Rutas_Lst.Items.Add(ListRutas[i].getNombre());
                }

            }

        }

        private void Añadir_Btm_Click(object sender, RoutedEventArgs e)
        {
            Añadir_Ruta añadir = new Añadir_Ruta(this.ListGuia, this.ListPdi, this.ListRutas);
            añadir.InitializeComponent();
            añadir.Show();
            this.Hide();

        }

        private void Eliminar_Btm_Click(object sender, RoutedEventArgs e)
        {

            if (Rutas_Lst.SelectedIndex != -1)
            {
                if (MessageBox.Show("Esta accion es definitva, ¿Estas seguro?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    String nombre = Rutas_Lst.Items[Rutas_Lst.SelectedIndex].ToString();
                    for (int i = 0; i < ListRutas.Count; i++)
                    {
                        if (nombre == ListRutas[i].getNombre())
                        {
                            Rutas_Lst.UnselectAll();
                            ListRutas.Remove(ListRutas[i]);
                            MessageBox.Show("Ruta eliminada");
                            //Antiguas_chb.IsChecked = false;
                            Rutas_Lst.Items.Clear();
                            if(Antiguas_chb.IsChecked == true)
                            {
                                for (int j = 0; j < ListRutas.Count; j++)
                                {
                                    Rutas_Lst.Items.Add(ListRutas[j].getNombre());
                                }

                            }
                            else
                            {
                                for (int j = 0; j < ListRutas.Count; j++)
                                {
                                    if (ListRutas[j].getCheck() == false)
                                    {
                                        Rutas_Lst.Items.Add(ListRutas[j].getNombre());
                                    }

                                }
                            }
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Selecciona primero una ruta!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if(Rutas_Lst.HasItems == false)
            {
                Modificar_Btm.IsEnabled= false;
                Eliminar_Btm.IsEnabled= false;
                Info_Btm.IsEnabled= false;

            }

        }

        private void Modificar_Btm_Click(object sender, RoutedEventArgs e)
        {
            if (Rutas_Lst.SelectedIndex != -1)
            {
                String nombreRuta = Rutas_Lst.Items[Rutas_Lst.SelectedIndex].ToString();
                Modificar_Ruta modificar = new Modificar_Ruta(this.ListGuia, this.ListPdi, this.ListRutas, nombreRuta);
                modificar.InitializeComponent();
                modificar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selecciona primero una ruta!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Info_Btm_Click(object sender, RoutedEventArgs e)
        {
            if (Rutas_Lst.SelectedIndex != -1)
            {
                String nombreRuta = Rutas_Lst.Items[Rutas_Lst.SelectedIndex].ToString();
                Info_Ruta info = new Info_Ruta(this.ListGuia, this.ListPdi, this.ListRutas, nombreRuta);
                info.InitializeComponent();
                info.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selecciona primero una ruta!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Salida_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            User u = new User();
            this.Hide();
            u.Show();

        }

        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MessageBox.Show("Añadir: \n\t Botón para añadir rutas \n Modificar: \n\t Botón para modificar una ruta seleccionada \n Eliminar: \n\t Botón para eliminar una ruta seleccionada \n Informacion: \n\t Botón para obtener informacion de una ruta seleccionada \n\n #Para ver rutas antiguas marca o desmarca la casilla 'Incluir antiguas'", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Guias_Btm_Click(object sender, RoutedEventArgs e)
        {
            Guias guias = new Guias(ListGuia, ListPdi, ListRutas);
            guias.InitializeComponent();
            guias.Show();
            this.Hide();

        }

        private void Excursionistas_Btm_Click(object sender, RoutedEventArgs e)
        {
            Excursionistas excursionistas = new Excursionistas(ListGuia,ListPdi,ListRutas);
            excursionistas.InitializeComponent();
            excursionistas.Show();
            this.Hide();
        }
    }
}

