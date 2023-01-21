using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenderismo.Dominio
{
    public class Guia
    {
        private String nombre;
        private String apellido;
        //foto
        private String idioma;
        private String disponibilidad;
        private String teléfono;
        private String correo;
        private Double puntuación;

        public Guia(string nombre, string apellido, string idioma, string disponibilidad, string teléfono, string correo, Double puntuación)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.idioma = idioma;
            this.disponibilidad = disponibilidad;
            this.teléfono = teléfono;
            this.correo = correo;
            this.puntuación = puntuación;
        }

        public String getNombre() 
        { 
            return nombre; 
        }
        public String getApellido()
        {
            return apellido;
        }

        public String getIdioma()
        {
            return idioma;
        }

        public String getDisponibilidad()
        {
            return disponibilidad;
        }

        public String getTelefono()
        {
            return this.teléfono;
        }

        public String getCorreo()
        {
            return correo;
        }
        public Double getPuntuacion()
        {
            return this.puntuación;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
        public void setApellido(String apellido)
        {
            this.apellido = apellido;
        }
        public void setIdioma(String idioma)
        {
            this.idioma = idioma;
        }
        public void setDisponibilidad(String disponibilidad)
        {
            this.disponibilidad= disponibilidad;
        }
        public void setTelefono(String telefono)
        {
            this.teléfono = telefono;
        }
        public void setCorreo(String correo)
        {
            this.correo = correo;
        }
        public void setPuntuacion(Double puntuacion)
        {
            this.puntuación= puntuacion;
        }

    }
}
