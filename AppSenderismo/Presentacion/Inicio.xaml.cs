using AppSenderismo.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        List<Ruta> ListRutas = new List<Ruta>();
        List<Pdi> ListPdi = new List<Pdi>();
        List<Guia> ListGuia = new List<Guia>();
        public Inicio(String user)
        {
            String fecha;
            InitializeComponent();
            IniciarPdi();
            IniciarGuias();
            IniciarRutas();
            fecha = leerFecha("Time.txt");
            Fecha_Lbl.Content = fecha;
            escribirFecha("Time.txt");
            //Usuario que obtenemos de la ventana de login
            Usuario_Lbl.Content = user;
            if (user == "Alvaro"){
                Usuario_Fto.Source = new BitmapImage(new Uri("/Presentacion/Usuarios/Alvaro.png", UriKind.Relative));
                Usuario_Box.Text = "Administrador jefe";
            }
            else
            {
                Usuario_Fto.Source = new BitmapImage(new Uri("/Presentacion/Usuarios/Cristina.jpeg", UriKind.Relative));
                Usuario_Box.Text = "Administrador suplente";
            }
        }
        private String leerFecha(String path)
        {
            String line = "";
            try
            {
                //Pasamos el path
                StreamReader sr = new StreamReader(path);
                //Leemos la primera fila
                line = sr.ReadLine();
                if (line == "")
                {
                    escribirFecha(path);
                    line = leerFecha(path);
                }
                //Cerramos el archivo
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return line;
        }
        private void escribirFecha(String path)
        {
            try
            {
                //Pasamos el path
                StreamWriter sw = new StreamWriter(path);
                //Escribimos la fecha
                DateTime thisDay = DateTime.Now;
                sw.WriteLine(thisDay.ToString("g"));
                //Cerramos el archivo
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void IniciarPdi()
        {
            ListPdi.Add(new Pdi("Acantilado", "Acantalido con vistas al pueblo", "Mirador"));
            ListPdi.Add(new Pdi("Cascada", "Cascada que salpica", "Zona Natural"));
            ListPdi.Add(new Pdi("Puente", "Puente que atraviesa el rio", "Zona turistica"));
        }

        public void IniciarGuias()
        {
            ListGuia.Add(new Guia("Jose", "Ruiz", "Español", "Total", "665594000", "hoxelex00@gmail.com", 7.9));
            ListGuia.Add(new Guia("Carmen", "Roldan", "Español, Francés", "Total", "656460658", "carmenroldan@gmail.com", 8.4));
            ListGuia.Add(new Guia("Carlos", "Leon", "Español, Inglés", "Parcial", "627029762", "carlos0090@gmail.com", 9.9));
        }
        public void IniciarRutas()
        {
            ListRutas.Add(new Ruta("Pueblo", "Ciuad Real", "Miguelturra", "10/01/2023", "Normal", ListGuia[0], 7, 10, "Entrada pueblo", "Centro del pueblo", "Ninguno", ListPdi[0], true));
            ListRutas.Add(new Ruta("Campo", "Ciudad Real", "Atalaya", "10/02/2023", "Difícil", ListGuia[1], 6, 9, "Puerta del campo", "Camino de vuelta", "Botas", ListPdi[1], false));
            ListRutas.Add(new Ruta("Vega", "Ciudad Real", "Daimiel", "29/01/2023", "Fácil", ListGuia[2], 5, 8, "Entrada puente", "Puente", "Cuerda", ListPdi[2], false));
        }

        private void Rutas_Btm_Click(object sender, RoutedEventArgs e)
        {
            Rutas rutas = new Rutas(ListGuia,ListPdi,ListRutas);
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
            this.Hide();
            u.Show();

        }
        private void Ayuda_Fto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Rutas: \n\t Botón para acceder al gestor de rutas \n Guías: \n\t Botón para acceder al gestor de guías \n Excursionistas: \n\t Botón para ver los excursionistas", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }


}
