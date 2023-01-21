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

namespace AppSenderismo.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Excursionistas.xaml
    /// </summary>
    public partial class Excursionistas : Window
    {
        List<Pdi> ListPdi = new List<Pdi>();
        List<Guia> ListGuia = new List<Guia>();
        List<Ruta> ListRutas = new List<Ruta>();
        List<Excursionista> ListExcursionistas = new List<Excursionista>();
        public Excursionistas(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            InitializeComponent();
            Crear_Excursionistas();

            for (int i = 0; i < ListExcursionistas.Count; i++)
            {
                Excursionistas_Lst.Items.Add(ListExcursionistas[i].Nombre);
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
            MessageBox.Show("Selecciona un Excursionista para ver su información y en caso de querer modificar algun valor hagalo y presione el botón de aceptar \n\n #Para ver rutas realizadas marca o desmarca la casilla 'Rutas realizadas'\"", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Rutas_Btm_Click(object sender, RoutedEventArgs e)
        {
            Rutas rutas = new Rutas(ListGuia, ListPdi, ListRutas);
            rutas.InitializeComponent();
            rutas.Show();
            this.Hide();
        }

        private void Guias_Btm_Click(object sender, RoutedEventArgs e)
        {
            Guias guias = new Guias(ListGuia, ListPdi, ListRutas);
            guias.InitializeComponent();
            guias.Show();
            this.Hide();
        }

        public void Crear_Excursionistas()
        {
            try
            {
                List<Ruta> Set1 = new List<Ruta>
            {
                ListRutas[1]
            };
                List<Ruta> Set2 = new List<Ruta>
            {
                ListRutas[2],
                ListRutas[1]
            };
                List<Ruta> Set3 = new List<Ruta>
            {
                ListRutas[1],
                ListRutas[2]
            };
                List<Ruta> Set4 = new List<Ruta>
            {
                ListRutas[2]
            };
                List<Ruta> Antigua = new List<Ruta>
            {
                ListRutas[0]
            };

                this.ListExcursionistas.Add(new Excursionista("Luis", "Perez", "607029761", "luisperez@gmail.com", Antigua, Set1));
                this.ListExcursionistas.Add(new Excursionista("Arturo", "Moraga", "627829741", "Arturo@gmail.com", null, Set2));
                this.ListExcursionistas.Add(new Excursionista("Esteban", "Rodrigez", "647029761", "Esteban@gmail.com", Antigua, Set3));
                this.ListExcursionistas.Add(new Excursionista("Lucas", "Fernandez", "627049761", "Lucas@gmail.com", null, Set1));
                this.ListExcursionistas.Add(new Excursionista("Conrrado", "Dueñas", "627029461", "Conrrado@gmail.com", Antigua, Set4));

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Rellenar()
        {
            for (int i = 0; i < this.ListExcursionistas.Count; i++)
            {
                if (Excursionistas_Lst.Items[Excursionistas_Lst.SelectedIndex].ToString() == this.ListExcursionistas[i].Nombre)
                {
                    Nombre_lbl_use.Content = Excursionistas_Lst.Items[Excursionistas_Lst.SelectedIndex];
                    Apellido_Txt.Text = this.ListExcursionistas[i].Apellido;
                    Telefono_Txt.Text = this.ListExcursionistas[i].Teléfono;
                    Correo_Txt.Text = this.ListExcursionistas[i].Correo;

                    Rutas_Lst.Items.Clear();
                    for (int j = 0; j < this.ListExcursionistas[i].Ruta_futura.Count; j++)
                    {
                        Rutas_Lst.Items.Add(this.ListExcursionistas[i].Ruta_futura[j].getNombre());
                    }

                }
            }
        }

        private void Rutas_Chk_Checked(object sender, RoutedEventArgs e)
        {
            if (Excursionistas_Lst.SelectedIndex != -1)
            {
                Rutas_Lst.Items.Clear();
                for (int i = 0; i < this.ListExcursionistas.Count; i++)
                {
                    if (Excursionistas_Lst.Items[Excursionistas_Lst.SelectedIndex].ToString() == Convert.ToString(this.ListExcursionistas[i].Nombre))
                    {
                        for (int j = 0; j < this.ListExcursionistas[i].Ruta_futura.Count; j++)
                        {
                            Rutas_Lst.Items.Add(this.ListExcursionistas[i].Ruta_futura[j].getNombre());
                        }

                        if (this.ListExcursionistas[i].Ruta_realizada != null)
                        {
                            for (int j = 0; j < this.ListExcursionistas[i].Ruta_realizada.Count; j++)
                            {
                                Rutas_Lst.Items.Add(this.ListExcursionistas[i].Ruta_realizada[j].getNombre());
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona primero un excursionista!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Rutas_Chk.IsChecked = false;
            }
        }

        private void Rutas_Chk_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Excursionistas_Lst.SelectedIndex != -1)
            {
                Rutas_Lst.Items.Clear();
                for (int i = 0; i < this.ListExcursionistas.Count; i++)
                {
                    if (Excursionistas_Lst.Items[Excursionistas_Lst.SelectedIndex].ToString() == this.ListExcursionistas[i].Nombre)
                    {
                        for (int j = 0; j < this.ListExcursionistas[i].Ruta_futura.Count; j++)
                        {
                            Rutas_Lst.Items.Add(this.ListExcursionistas[i].Ruta_futura[j].getNombre());
                        }
                    }
                }
            }
        }

        private void Excursionistas_Lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rutas_Chk.IsChecked = false;
            Rellenar();

        }

        private void Actualizar_Btm_Click(object sender, RoutedEventArgs e)
        {
            if (Excursionistas_Lst.SelectedIndex != -1)
            {
                for (int i = 0; i < this.ListExcursionistas.Count; i++)
                {
                    if (Excursionistas_Lst.Items[Excursionistas_Lst.SelectedIndex].ToString() == this.ListExcursionistas[i].Nombre)
                    {
                        this.ListExcursionistas[i].Apellido = Convert.ToString(Apellido_Txt.Text);
                        this.ListExcursionistas[i].Teléfono = Convert.ToString(Telefono_Txt.Text);
                        this.ListExcursionistas[i].Correo = Convert.ToString(Correo_Txt.Text);

                        MessageBox.Show("Excursionista modificado");

                    }

                }
            }
            else
            {
                MessageBox.Show("Selecciona primero un excursionista!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Rutas_Chk.IsChecked = false;

            }
        }
    }
}
