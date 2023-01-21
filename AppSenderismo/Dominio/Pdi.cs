using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenderismo.Dominio
{
    public class Pdi
    {
        private String nombre;
        private String descripcion;
        private String tipologia;
        //fotos

        public Pdi(String nombre, String descripcion, String tipologia)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipologia = tipologia;
        }

        public String getNombre() 
        { 
            return nombre; 
        }
        public String getDescripcion()
        {
            return descripcion;
        }
        public String getTipologia()
        {
            return tipologia;
        }
        
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }
        public void setTipologia(String tipologia)
        {
            this.tipologia= tipologia;
        }
    }
}
