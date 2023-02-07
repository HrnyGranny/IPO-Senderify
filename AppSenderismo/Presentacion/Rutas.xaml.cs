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
        List<Excursionista> ListExcursionistas = new List<Excursionista>();
        public Rutas(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            IniciarExcursionistas();
            InitializeComponent();

            if (ListRutas != null)
            {
                for (int i = 0; i < ListRutas.Count; i++)
                {
                    if (ListRutas[i].getCheck() == false)
                    {
                        Rutas_Lst.Items.Add(ListRutas[i].getNombre());
                    }

                }
            }


            if (Rutas_Lst.HasItems == false)
            {
                Modificar_Btm.IsEnabled = false;
                Eliminar_Btm.IsEnabled = false;
                Guia_Btm.IsEnabled = false;
                Pdi_Btm.IsEnabled = false;
                Excusionistas_Btm_Accion.IsEnabled = false;
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
                if (MessageBox.Show("Vas a eliminar una ruta de forma definitiva, ¿Estas seguro?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    String nombre = Rutas_Lst.Items[Rutas_Lst.SelectedIndex].ToString();
                    for (int i = 0; i < ListRutas.Count; i++)
                    {
                        if (nombre == ListRutas[i].getNombre())
                        {
                            Rutas_Lst.UnselectAll();
                            Guia_Btm.IsEnabled = false;
                            Pdi_Btm.IsEnabled = false;
                            Excusionistas_Btm_Accion.IsEnabled = false;
                            IOrigen_Txt.Text = "";
                            IDestino_Txt.Text = "";
                            IFecha_Txt.Text = "";
                            INExcursionistas_Txt.Text = "";
                            ITiempo_Txt.Text = "";
                            IAcceso_Txt.Text = "";
                            IVuelta_Txt.Text = "";
                            IMaterial_Txt.Text = "";
                            IDificultad_Txt.Text = "";
                            IGuia_Txt.Text = "";
                            IPdi_Txt.Text = "";
                            ListRutas.Remove(ListRutas[i]);
                            MessageBox.Show("Ruta eliminada");
                            //Antiguas_chb.IsChecked = false;
                            Rutas_Lst.Items.Clear();
                            if (Antiguas_chb.IsChecked == true)
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

            if (Rutas_Lst.HasItems == false)
            {
                Modificar_Btm.IsEnabled = false;
                Eliminar_Btm.IsEnabled = false;
                Guia_Btm.IsEnabled = false;
                Pdi_Btm.IsEnabled = false;
                Excusionistas_Btm_Accion.IsEnabled = false;


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

        private void Salida_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            User u = new User();
            this.Close();
            u.Show();

        }

        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MessageBox.Show("Añadir: \n\tBotón para añadir rutas \n Modificar: \n\tBotón para modificar una ruta seleccionada \nEliminar: \n\tBotón para eliminar una ruta seleccionada \n\n#Para ver rutas antiguas marca o desmarca la casilla 'Incluir antiguas'\n#Para ampliar información darle a los botones con iconos de información", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

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
            Excursionistas excursionistas = new Excursionistas(ListGuia, ListPdi, ListRutas);
            excursionistas.InitializeComponent();
            excursionistas.Show();
            this.Hide();
        }

        public void Rellenar()
        {
            try
            {
                for (int i = 0; i < this.ListRutas.Count; i++)
                {
                    if (Rutas_Lst.Items[Rutas_Lst.SelectedIndex].ToString() == this.ListRutas[i].getNombre())
                    {
                        RutaSelec.Content = Rutas_Lst.Items[Rutas_Lst.SelectedIndex];
                        IOrigen_Txt.Text = this.ListRutas[i].getOrigen();
                        IDestino_Txt.Text = this.ListRutas[i].getDestino();
                        IFecha_Txt.Text = this.ListRutas[i].getFecha();
                        INExcursionistas_Txt.Text = "" + this.ListRutas[i].getNum_escursionistas();
                        ITiempo_Txt.Text = "" + this.ListRutas[i].getTiempo();
                        IAcceso_Txt.Text = this.ListRutas[i].getAcceso();
                        IVuelta_Txt.Text = this.ListRutas[i].getVuelta();
                        IMaterial_Txt.Text = this.ListRutas[i].getMaterial();
                        IDificultad_Txt.Text = this.ListRutas[i].getDificultad();
                        IGuia_Txt.Text = this.ListRutas[i].getGuia().getNombre();
                        IPdi_Txt.Text = ListRutas[i].getPdi().getNombre();
                        RellenarExc(Rutas_Lst.Items[Rutas_Lst.SelectedIndex].ToString());
                    }
                }

            }
            catch(Exception ex)
            {
                String e;
                e = Convert.ToString(ex);
            }  
        }

        public void RellenarGuia(String Guia)
        {
            GuiaSelec.Content = Guia;
            for (int i = 0; i < this.ListGuia.Count; i++)
            {
                if (Guia == this.ListGuia[i].getNombre())
                {
                    GIApellido_Txt.Text = ListGuia[i].getApellido();
                    GIIdioma_Txt.Text = ListGuia[i].getIdioma();
                    GIDisponibilidad_Txt.Text = ListGuia[i].getDisponibilidad();
                    GITeléfono_Txt.Text = ListGuia[i].getTelefono();
                    GICorreo_Txt.Text = ListGuia[i].getCorreo();
                    GIPuntuación_Txt.Text = Convert.ToString(ListGuia[i].getPuntuacion());
                }
            } 
        }

        public void RellenarPdi(String Pdi)
        {
            PdiSelec.Content = Pdi;
            for (int i = 0; i < ListPdi.Count; i++)
            {
                if (Pdi == ListPdi[i].getNombre())
                {
                    PIDescripcion_Txt.Text = ListPdi[i].getDescripcion();
                    PITipologia_Txt.Text = ListPdi[i].getTipologia();

                    if (Pdi == "Cascada")
                    {
                        Pdi_Foto.Source = new BitmapImage(new Uri("/Imágenes/Cascada.jpg", UriKind.Relative));
                    }

                    if (Pdi == "Acantilado")
                    {
                        Pdi_Foto.Source = new BitmapImage(new Uri("/Imágenes/Acantilado.jpg", UriKind.Relative));
                    }

                    if (Pdi == "Puente")
                    {
                        Pdi_Foto.Source = new BitmapImage(new Uri("/Imágenes/Puente.jpg", UriKind.Relative));
                    }
                }
            }
        }

        public void RellenarExc(String Ruta)
        {

            Excursionistas_Lst.Items.Clear();

            if (Ruta == "Pueblo")
            {
                Excursionistas_Lst.Items.Add(ListExcursionistas[0].Nombre);
                Excursionistas_Lst.Items.Add(ListExcursionistas[2].Nombre);
                Excursionistas_Lst.Items.Add(ListExcursionistas[4].Nombre);
            }

            if (Ruta == "Campo")
            {
                Excursionistas_Lst.Items.Add(ListExcursionistas[0].Nombre);
                Excursionistas_Lst.Items.Add(ListExcursionistas[1].Nombre);
                Excursionistas_Lst.Items.Add(ListExcursionistas[2].Nombre);
                Excursionistas_Lst.Items.Add(ListExcursionistas[3].Nombre);
            }

            if (Ruta == "Vega")
            {
                Excursionistas_Lst.Items.Add(ListExcursionistas[1].Nombre);
                Excursionistas_Lst.Items.Add(ListExcursionistas[2].Nombre);
                Excursionistas_Lst.Items.Add(ListExcursionistas[4].Nombre);
            }
            
        }

        private void Rutas_Lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modificar_Btm.IsEnabled = true;
            Eliminar_Btm.IsEnabled = true;
            Guia_Btm.IsEnabled = true;
            Pdi_Btm.IsEnabled = true;
            Excusionistas_Btm_Accion.IsEnabled = true;
            Rellenar();
            GState.Visibility = Visibility.Collapsed;
            GInfo.Visibility = Visibility.Collapsed;
            GuiaSelec.Visibility = Visibility.Collapsed;
            Volver_Btm.Visibility = Visibility.Collapsed;
            PState.Visibility = Visibility.Collapsed;
            PInfo.Visibility = Visibility.Collapsed;
            PdiSelec.Visibility = Visibility.Collapsed;
            Pdi_Foto.Visibility = Visibility.Collapsed;
            Volver2_Btm.Visibility = Visibility.Collapsed;
            RutaSelec.Visibility = Visibility.Visible;
            State.Visibility = Visibility.Visible;
            Info.Visibility = Visibility.Visible;
            IGuia_Txt.Visibility = Visibility.Visible;
            IPdi_Txt.Visibility = Visibility.Visible;
            Guia_Btm.Visibility = Visibility.Visible;
            Pdi_Btm.Visibility = Visibility.Visible;
            GuiaPdi.Visibility = Visibility.Visible;
            GuiaPdiInfo.Visibility = Visibility.Visible;
            GuiaPdi1.Visibility = Visibility.Visible;
            Excusionistas_Btm_Accion.Visibility = Visibility.Visible;
        }

        private void Guia_Btm_Click(object sender, RoutedEventArgs e)
        {
            RutaSelec.Visibility = Visibility.Collapsed;
            State.Visibility = Visibility.Collapsed;
            Info.Visibility = Visibility.Collapsed;
            IGuia_Txt.Visibility = Visibility.Collapsed;
            IPdi_Txt.Visibility = Visibility.Collapsed;
            Guia_Btm.Visibility = Visibility.Collapsed;
            Pdi_Btm.Visibility = Visibility.Collapsed;
            GuiaPdi.Visibility = Visibility.Collapsed;
            GuiaPdi1.Visibility = Visibility.Collapsed;
            GuiaPdiInfo.Visibility = Visibility.Collapsed;
            Excusionistas_Btm_Accion.Visibility = Visibility.Collapsed;
            RellenarGuia(Convert.ToString(IGuia_Txt.Text));
            GState.Visibility = Visibility.Visible;
            GInfo.Visibility = Visibility.Visible;
            GuiaSelec.Visibility = Visibility.Visible;
            Volver_Btm.Visibility = Visibility.Visible;
        }

        private void Volver_Btm_Click(object sender, RoutedEventArgs e)
        {
            GState.Visibility = Visibility.Collapsed;
            GInfo.Visibility = Visibility.Collapsed;
            GuiaSelec.Visibility = Visibility.Collapsed;
            Volver_Btm.Visibility = Visibility.Collapsed;
            RutaSelec.Visibility = Visibility.Visible;
            State.Visibility = Visibility.Visible;
            Info.Visibility = Visibility.Visible;
            IGuia_Txt.Visibility = Visibility.Visible;
            IPdi_Txt.Visibility = Visibility.Visible;
            Guia_Btm.Visibility = Visibility.Visible;
            Pdi_Btm.Visibility = Visibility.Visible;
            GuiaPdi.Visibility = Visibility.Visible;
            GuiaPdiInfo.Visibility = Visibility.Visible;
            GuiaPdi1.Visibility = Visibility.Visible;
            Excusionistas_Btm_Accion.Visibility = Visibility.Visible;
        }

        private void Pdi_Btm_Click(object sender, RoutedEventArgs e)
        {
            RutaSelec.Visibility = Visibility.Collapsed;
            State.Visibility = Visibility.Collapsed;
            Info.Visibility = Visibility.Collapsed;
            IGuia_Txt.Visibility = Visibility.Collapsed;
            IPdi_Txt.Visibility = Visibility.Collapsed;
            Guia_Btm.Visibility = Visibility.Collapsed;
            Pdi_Btm.Visibility = Visibility.Collapsed;
            GuiaPdi.Visibility = Visibility.Collapsed;
            GuiaPdiInfo.Visibility = Visibility.Collapsed;
            GuiaPdi1.Visibility = Visibility.Collapsed;
            Excusionistas_Btm_Accion.Visibility = Visibility.Collapsed;
            RellenarPdi(Convert.ToString(IPdi_Txt.Text));
            PState.Visibility = Visibility.Visible;
            PInfo.Visibility = Visibility.Visible;
            PdiSelec.Visibility = Visibility.Visible;
            Pdi_Foto.Visibility = Visibility.Visible;
            Volver2_Btm.Visibility = Visibility.Visible;
        }

        private void Volver2_Btm_Click(object sender, RoutedEventArgs e)
        {
            PState.Visibility = Visibility.Collapsed;
            PInfo.Visibility = Visibility.Collapsed;
            PdiSelec.Visibility = Visibility.Collapsed;
            Pdi_Foto.Visibility = Visibility.Collapsed;
            Volver2_Btm.Visibility = Visibility.Collapsed;
            RutaSelec.Visibility = Visibility.Visible;
            State.Visibility = Visibility.Visible;
            Info.Visibility = Visibility.Visible;
            IGuia_Txt.Visibility = Visibility.Visible;
            IPdi_Txt.Visibility = Visibility.Visible;
            Guia_Btm.Visibility = Visibility.Visible;
            Pdi_Btm.Visibility = Visibility.Visible;
            GuiaPdi.Visibility = Visibility.Visible;
            GuiaPdiInfo.Visibility = Visibility.Visible;
            GuiaPdi1.Visibility = Visibility.Visible;
            Excusionistas_Btm_Accion.Visibility = Visibility.Visible;
        }

        public void IniciarExcursionistas()
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
            catch (Exception ex)
            {
                String e = ex.Message;
                
            }
        }

        private void Volver3_Btm_Click(object sender, RoutedEventArgs e)
        {
            Excursionistas__Lbl.Visibility= Visibility.Collapsed;
            Excursionistas_Lst.Visibility= Visibility.Collapsed;
            Volver3_Btm.Visibility = Visibility.Collapsed;
            PState.Visibility = Visibility.Collapsed;
            PInfo.Visibility = Visibility.Collapsed;
            PdiSelec.Visibility = Visibility.Collapsed;
            Pdi_Foto.Visibility = Visibility.Collapsed;
            Volver2_Btm.Visibility = Visibility.Collapsed;
            RutaSelec.Visibility = Visibility.Visible;
            State.Visibility = Visibility.Visible;
            Info.Visibility = Visibility.Visible;
            IGuia_Txt.Visibility = Visibility.Visible;
            IPdi_Txt.Visibility = Visibility.Visible;
            Guia_Btm.Visibility = Visibility.Visible;
            Pdi_Btm.Visibility = Visibility.Visible;
            GuiaPdi.Visibility = Visibility.Visible;
            GuiaPdiInfo.Visibility = Visibility.Visible;
            GuiaPdi1.Visibility = Visibility.Visible;
            Excusionistas_Btm_Accion.Visibility = Visibility.Visible;

        }

        private void Excusionistas_Btm_Accion_Click(object sender, RoutedEventArgs e)
        {
            RutaSelec.Visibility = Visibility.Collapsed;
            State.Visibility = Visibility.Collapsed;
            Info.Visibility = Visibility.Collapsed;
            IGuia_Txt.Visibility = Visibility.Collapsed;
            IPdi_Txt.Visibility = Visibility.Collapsed;
            Guia_Btm.Visibility = Visibility.Collapsed;
            Pdi_Btm.Visibility = Visibility.Collapsed;
            GuiaPdi.Visibility = Visibility.Collapsed;
            GuiaPdiInfo.Visibility = Visibility.Collapsed;
            GuiaPdi1.Visibility = Visibility.Collapsed;
            Excusionistas_Btm_Accion.Visibility = Visibility.Collapsed;
            Volver3_Btm.Visibility = Visibility.Visible;
            Excursionistas__Lbl.Visibility= Visibility.Visible;
            Excursionistas_Lst.Visibility = Visibility.Visible;

        }
    }
}

