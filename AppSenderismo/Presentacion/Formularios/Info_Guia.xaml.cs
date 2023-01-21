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
    /// Lógica de interacción para Info_Guia.xaml
    /// </summary>
    public partial class Info_Guia : Window
    {
        List<Guia> ListGuia;
        List<Pdi> ListPdi;
        List<Ruta> ListRutas;
        String Guia;
        public Info_Guia(List<Guia> ListGuia, List<Pdi> ListPdi, List<Ruta> ListRutas, String Guia)
        {
            this.ListGuia = ListGuia;
            this.ListPdi = ListPdi;
            this.ListRutas = ListRutas;
            this.Guia = Guia;
            InitializeComponent();
            Rellenar();
        }

        public void Rellenar()
        {
            for(int i = 0; i<ListGuia.Count; i++)
            {
                if (Guia == ListGuia[i].getNombre())
                {
                    Nombre_Txt.Text = ListGuia[i].getNombre();
                    Apellido_Txt.Text = ListGuia[i].getApellido();
                    Idioma_Txt.Text = ListGuia[i].getIdioma();
                    Disponibilidad_Txt.Text = ListGuia[i].getDisponibilidad();
                    Telefono_Txt.Text = ListGuia[i].getTelefono();
                    Correo_Txt.Text = ListGuia[i].getCorreo();
                    Puntuacion_Txt.Text = Convert.ToString(ListGuia[i].getPuntuacion());

                    Nombre_Txt.IsReadOnly = true;
                    Apellido_Txt.IsReadOnly = true;
                    Idioma_Txt.IsReadOnly = true;
                    Disponibilidad_Txt.IsReadOnly = true;
                    Telefono_Txt.IsReadOnly = true;
                    Correo_Txt.IsReadOnly = true;
                    Puntuacion_Txt.IsReadOnly = true;
                }
            }
        }

        private void Cancelar_Btm_Click(object sender, RoutedEventArgs e)
        {
            Guias guias = new Guias(ListGuia, ListPdi, ListRutas);
            guias.InitializeComponent();
            guias.Show();
            this.Hide();
        }
    }
}
