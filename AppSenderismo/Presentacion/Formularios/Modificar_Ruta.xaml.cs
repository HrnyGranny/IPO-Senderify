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
    /// Lógica de interacción para Modificar_Ruta.xaml
    /// </summary>
    public partial class Modificar_Ruta : Window
    {
        List<Guia> ListGuia;
        List<Pdi> ListPdi;
        List<Ruta> ListRutas;
        String Nombre;
        public Modificar_Ruta(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas, String Nombre)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            this.Nombre = Nombre;
            InitializeComponent();
            IniciarDatos();
            Nombre_lbl_use.Content = this.Nombre;
        }

        public void IniciarDatos()
        {
            for(int i = 0; i<this.ListRutas.Count; i++)
            {
                if (this.Nombre == this.ListRutas[i].getNombre())
                {
                    Origen_txt.Text = ListRutas[i].getOrigen();
                    Destino_txt.Text = ListRutas[i].getDestino();
                    //Fecha_lbl_use.Content = ListRutas[i].getFecha();
                    DividirFecha(ListRutas[i].getFecha());
                    NumeroExcursionistas_txt.Text = "" + ListRutas[i].getNum_escursionistas();
                    Tiempo_txt.Text = "" + ListRutas[i].getTiempo();
                    Dificultad_Lbl_a.Content = ListRutas[i].getDificultad();
                    Acceso_txt.Text = ListRutas[i].getAcceso();
                    Vuelta_txt.Text = ListRutas[i].getVuelta();
                    Material_txt.Text = ListRutas[i].getMaterial();
                    Guia_lbl_use.Content = ListRutas[i].getGuia().getNombre();
                    Pdi_lbl_use.Content = ListRutas[i].getPdi().getNombre();

                    Guia_lst.Items.Clear();
                    for (int k = 0; k < ListGuia.Count; k++)
                    {
                        Guia_lst.Items.Add(ListGuia[k].getNombre());
                    }

                    Pdi_lst.Items.Clear();
                    for (int j = 0; j < ListPdi.Count; j++)
                    {
                        Pdi_lst.Items.Add(ListPdi[j].getNombre());
                    }
                }
            }

        }

        public void DividirFecha(String fecha)
        {
            String [] FechaDividida = (fecha.Split('/'));
            Fecha1_txt.Text = FechaDividida[0];
            Fecha2_txt.Text = FechaDividida[1];
            Fecha3_txt.Text = FechaDividida[2];


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

                    if (20 < Num_excursionistas || Num_excursionistas < 4)
                    {
                        MessageBox.Show("El numero de Excursionistas tiene que estar entre 4 y 20", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        NumeroExcursionistas_txt.Background = Brushes.LightPink;
                    }
                    else
                    {
                        int GuiaPos = 0;
                        int PdiPos = 0;

                        for (int i = 0; i < ListGuia.Count; i++)
                        {
                            if (ListGuia[i].getNombre() == Guia) { GuiaPos = i; break; }
                        }

                        for (int i = 0; i < ListPdi.Count; i++)
                        {
                            if (ListPdi[i].getNombre() == Pdi) { PdiPos = i; break; }
                        }

                        for (int j = 0; j < this.ListRutas.Count; j++)
                        {
                            if (this.Nombre == this.ListRutas[j].getNombre())
                            {
                                ListRutas[j].setOrigen(Convert.ToString(Origen_txt.Text));
                                ListRutas[j].setDestino(Convert.ToString(Destino_txt.Text));
                                ListRutas[j].setFecha(fecha);
                                ListRutas[j].setDificultad(Dificultad);
                                ListRutas[j].setGuia(ListGuia[GuiaPos]);
                                ListRutas[j].setNum_escursionistas(Convert.ToInt32(NumeroExcursionistas_txt.Text));
                                ListRutas[j].setTiempo(Convert.ToInt32(Tiempo_txt.Text));
                                ListRutas[j].setAcceso(Convert.ToString(Acceso_txt.Text));
                                ListRutas[j].setVuelta(Convert.ToString(Vuelta_txt.Text));
                                ListRutas[j].setMaterial(Convert.ToString(Material_txt.Text));
                                ListRutas[j].setPdi(ListPdi[PdiPos]);
                                ListRutas[j].setCheck(false);

                                MessageBox.Show("Ruta modificada");
                                Dificultad_lst.Background = Brushes.White;
                                Guia_lst.Background = Brushes.White;
                                Pdi_lst.Background = Brushes.White;
                                NumeroExcursionistas_txt.Background = Brushes.White;
                                IniciarDatos();
                            }
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

            }
            catch (FormatException)
            {
                MessageBox.Show("Error: hay campos cuyos valores no están bien puestos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Cancelar_Btm_Click(object sender, RoutedEventArgs e)
        {
            Rutas rutas = new Rutas(ListGuia, ListPdi, ListRutas);
            rutas.InitializeComponent();
            rutas.Show();
            this.Hide();
        }

        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Modificar Ruta: \n\t Rellena todos los huecos de información, selecciona donde se pueda y presiona el botón de modificar \n Cancelar: \n\t Presiona el botón con la X en rojo", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
