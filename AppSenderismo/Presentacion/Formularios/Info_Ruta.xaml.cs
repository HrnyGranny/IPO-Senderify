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
    /// Lógica de interacción para Info_Ruta.xaml
    /// </summary>
    public partial class Info_Ruta : Window
    {
        List<Guia> ListGuia;
        List<Pdi> ListPdi;
        List<Ruta> ListRutas;
        String Nombre;
        public Info_Ruta(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas, String Nombre)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            this.Nombre = Nombre;
            InitializeComponent();
            IniciarDatos();
        }
        public void IniciarDatos()
        {
            for (int i = 0; i < this.ListRutas.Count; i++)
            {
                if (this.Nombre == this.ListRutas[i].getNombre())
                {
                    Nombre_txt.Text = this.Nombre;
                    Origen_txt.Text = ListRutas[i].getOrigen();
                    Destino_txt.Text = ListRutas[i].getDestino();
                    Fecha1_txt.Text = ListRutas[i].getFecha();
                    Dificultad_Txt.Text = ListRutas[i].getDificultad();
                    NumeroExcursionistas_txt.Text = "" + ListRutas[i].getNum_escursionistas();
                    Tiempo_txt.Text = "" + ListRutas[i].getTiempo();
                    Acceso_txt.Text = ListRutas[i].getAcceso();
                    Vuelta_txt.Text = ListRutas[i].getVuelta();
                    Material_txt.Text = ListRutas[i].getMaterial();
                    Guia_Txt.Text = ListRutas[i].getGuia().getNombre();
                    Pdi_Txt.Text = ListRutas[i].getPdi().getNombre();

                    Nombre_txt.IsReadOnly = true;
                    Origen_txt.IsReadOnly = true;
                    Destino_txt.IsReadOnly = true;
                    Fecha1_txt.IsReadOnly = true;
                    Dificultad_Txt.IsReadOnly = true;
                    NumeroExcursionistas_txt.IsReadOnly = true;
                    Tiempo_txt.IsReadOnly = true;
                    Acceso_txt.IsReadOnly = true;
                    Vuelta_txt.IsReadOnly = true;
                    Material_txt.IsReadOnly = true;
                    Guia_Txt.IsReadOnly = true;
                    Pdi_Txt.IsReadOnly = true;
                }
            }
        }

        private void Cancelar_Btm_Click(object sender, RoutedEventArgs e)
        {
            Rutas rutas = new Rutas(ListGuia,ListPdi,ListRutas);
            rutas.InitializeComponent();
            rutas.Show();
            this.Hide();
        }

        private void Guia_Btm_Click(object sender, RoutedEventArgs e)
        {
            Boolean exists = false;
            for (int i = 0; i < this.ListGuia.Count; i++)
            {
                if(Convert.ToString(Guia_Txt.Text) == ListGuia[i].getNombre())
                {
                    exists = true;
                }
            }

            if (exists)
            {
                InfoGuia Guia = new InfoGuia(ListGuia, ListPdi, ListRutas, Convert.ToString(Guia_Txt.Text), this.Nombre);
                Guia.InitializeComponent();
                Guia.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Lo siento, el guia no existe o ha sido eliminado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private void Pdi_Btm_Click(object sender, RoutedEventArgs e)
        {
            InfoPdi pdi = new InfoPdi(ListGuia, ListPdi, ListRutas, Convert.ToString(Pdi_Txt.Text), this.Nombre);
            pdi.InitializeComponent();
            pdi.Show();
            this.Hide();

        }
    }
}
