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
    /// Lógica de interacción para InfoPdi.xaml
    /// </summary>
    public partial class InfoPdi : Window
    {
        List<Guia> ListGuia;
        List<Pdi> ListPdi;
        List<Ruta> ListRutas;
        String Pdi;
        String NombreRuta;
        public InfoPdi(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas, String Pdi, string NombreRuta)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            this.Pdi = Pdi;
            this.NombreRuta = NombreRuta;
            InitializeComponent();
            Rellenar();
        }

        public void Rellenar()
        {
            for (int i = 0; i < ListPdi.Count; i++)
            {
                if (this.Pdi == ListPdi[i].getNombre())
                {
                    Nombre_Txt.Text = ListPdi[i].getNombre();
                    Descripcion_Txt.Text = ListPdi[i].getDescripcion();
                    Tipologia_Txt.Text = ListPdi[i].getTipologia();

                    if(this.Pdi == "Cascada")
                    {
                        Pdi_Foto.Source = new BitmapImage(new Uri("/Imágenes/Cascada.jpg", UriKind.Relative));
                    }

                    if (this.Pdi == "Acantilado")
                    {
                        Pdi_Foto.Source = new BitmapImage(new Uri("/Imágenes/Acantilado.jpg", UriKind.Relative));
                    }

                    if (this.Pdi == "Puente")
                    {
                        Pdi_Foto.Source = new BitmapImage(new Uri("/Imágenes/Puente.jpg", UriKind.Relative));
                    }

                    Nombre_Txt.IsReadOnly = true;
                    Descripcion_Txt.IsReadOnly = true;
                    Tipologia_Txt.IsReadOnly = true;

                }
            }
        }

        private void Cancelar_Btm_Click(object sender, RoutedEventArgs e)
        {
            Info_Ruta info = new Info_Ruta(this.ListGuia, this.ListPdi, this.ListRutas, this.NombreRuta);
            info.InitializeComponent();
            info.Show();
            this.Hide();
        }
    }
}
