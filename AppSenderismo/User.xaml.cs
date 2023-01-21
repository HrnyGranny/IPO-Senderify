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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppSenderismo.Dominio;
using AppSenderismo.Presentacion;

namespace AppSenderismo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class User : Window
    {
        Usuario[] usuarios_DB = new Usuario[2];
        String usuario;
        public User()
        {
            InitializeComponent();
            IniciarUsuarios();
        }
        private void IniciarUsuarios()
        {
            usuarios_DB[0] = new Usuario("Alvaro", "wapisimo");
            usuarios_DB[1] = new Usuario("Cristina", "wapisima");

        }
        private void AceptarBtm_Click(object sender, RoutedEventArgs e)
        {
            String Usuario = UserTxt.Text;
            String Password = PassTxt.Password.ToString();
            Boolean LoginUser = false;
            Boolean LoginPass = false;

            if (Usuario == "" || Password == "")
            {
                UserTxt.BorderBrush = Brushes.Red;
                PassTxt.BorderBrush = Brushes.Red;
                MessageBox.Show("Login Incorrecto! Debe introducir Usuario y Contraseña", "Error Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            for (int i = 0; i < usuarios_DB.Length; i++)
            {
                if (Usuario == usuarios_DB[i].GetLogin())
                {
                    UserTxt.BorderBrush = Brushes.Black;
                    LoginUser = true;

                    if(Password == usuarios_DB[i].GetPass())
                    {
                        PassTxt.BorderBrush = Brushes.Black;
                        this.usuario = usuarios_DB[i].GetLogin();
                        LoginPass = true;
                    }
                }
            }

            if (!LoginUser)
            {
                UserTxt.BorderBrush = Brushes.Red;
                PassTxt.BorderBrush = Brushes.Black;
                UserTxt.Clear();
                MessageBox.Show("Login Incorrecto! Usuario no registrado", "Error Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!LoginPass)
            {
                UserTxt.BorderBrush = Brushes.Black;
                PassTxt.BorderBrush = Brushes.Red;
                PassTxt.Clear();
                MessageBox.Show("Login Incorrecto! Contraseña incorrecta", "Error Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //Si esta todo bien

            Inicio inicio = new Inicio(this.usuario);
            inicio.InitializeComponent();
            inicio.Show();
            this.Hide();

        }
        private void UsuarioOlvidadoLbl_MouseEnter(object sender, MouseEventArgs e)
        {
            UsuarioOlvidadoLbl.FontWeight= FontWeights.UltraBold;
            UsuarioOlvidadoLbl.Foreground = Brushes.LightBlue;

        }
        private void UsuarioOlvidadoLbl_MouseLeave(object sender, MouseEventArgs e)
        {
            UsuarioOlvidadoLbl.FontWeight = FontWeights.Bold;
            UsuarioOlvidadoLbl.Foreground = Brushes.White;
        }
        private void login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UsuarioOlvidadoLbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Para recuperar las credenciales contacta con: \n alvaroruizroldan@gmail.com", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AboutLbl_MouseEnter(object sender, MouseEventArgs e)
        {
            AboutLbl.FontWeight = FontWeights.UltraBold;
            AboutLbl.Foreground = Brushes.LightBlue;

        }

        private void AboutLbl_MouseLeave(object sender, MouseEventArgs e)
        {
            AboutLbl.FontWeight = FontWeights.Bold;
            AboutLbl.Foreground = Brushes.White;
        }

        private void AboutLbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Author: Álvaro Ruiz Roldán \nVersion: 1.1.6 \nFecha de realización: 15/01/2023", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
