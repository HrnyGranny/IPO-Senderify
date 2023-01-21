using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenderismo.Dominio
{
    internal class Excursionista
    {
        private String nombre;
        private String apellido;
        private String teléfono;
        private String correo;
        private List<Ruta> ruta_realizada;
        private List<Ruta> ruta_futura;

        public Excursionista(string nombre, string apellido, string teléfono, string correo, List<Ruta> ruta_realizada, List<Ruta> ruta_futura)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Teléfono = teléfono;
            this.Correo = correo;
            this.Ruta_realizada = ruta_realizada;
            this.Ruta_futura = ruta_futura;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Teléfono { get => teléfono; set => teléfono = value; }
        public string Correo { get => correo; set => correo = value; }
        public List<Ruta> Ruta_realizada { get => ruta_realizada; set => ruta_realizada = value; }
        public List<Ruta> Ruta_futura { get => ruta_futura; set => ruta_futura = value; }
    }

}
