using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace AppSenderismo.Dominio
{
    public class Ruta
    {
        private String nombre;
        private String origen;
        private String destino;
        private String fecha;
        private String dificultad;
        //guia
        private Guia guia;
        //guia
        private int num_excursionistas;
        private int tiempo;
        private String acceso;
        private String vuelta;
        private String material;
        //pdi
        private Pdi pdi;
        //pdi
        //Boolean
        private Boolean check;

        public Ruta(String nombre, String origen, String destino, String fecha, String dificultad, Guia guia, int num_excursionistas, int tiempo, string acceso, string vuelta, string material,Pdi pdi, Boolean check)
        {
            this.nombre = nombre;
            this.origen = origen;
            this.destino = destino;
            this.fecha = fecha;
            this.dificultad = dificultad;
            this.guia = guia;
            this.num_excursionistas = num_excursionistas;
            this.tiempo = tiempo;
            this.acceso = acceso;
            this.vuelta = vuelta;
            this.material = material;
            this.pdi = pdi;
            this.check = check;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public String getOrigen()
        {
            return this.origen;
        }

        public String getDestino()
        {
            return this.destino;
        }

        public String getFecha()
        {
            return this.fecha;
        }

        public String getDificultad()
        {
            return this.dificultad;
        }

        public Guia getGuia()
        {
            return this.guia;
        }
        
        public int getNum_escursionistas()
        {
            return this.num_excursionistas;
        }

        public int getTiempo()
        {
            return this.tiempo;
        }

        public String getAcceso ()
        {
            return this.acceso;
        }

        public String getVuelta()
        {
            return this.vuelta;
        }

        public String getMaterial()
        {
            return this.material;
        }

        public Pdi getPdi()
        {
            return this.pdi;
        }

        public Boolean getCheck()
        {
            return this.check;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
        public void setOrigen(String origen)
        {
            this.origen = origen;
        }
        public void setDestino(String destino)
        {
            this.destino = destino;
        }
        public void setFecha(String fecha)
        {
            this.fecha = fecha;
        }
        public void setDificultad(String dificultad)
        {
            this.dificultad = dificultad;
        }
        public void setGuia(Guia guia)
        {
            this.guia = guia;
        }
        public void setNum_escursionistas(int num_escursionistas)
        {
            this.num_excursionistas= num_escursionistas;
        }
        public void setTiempo(int tiempo)
        {
            this.tiempo = tiempo;
        }
        public void setAcceso(String acceso)
        {
            this.acceso = acceso;
        }
        public void setVuelta(String vuelta)
        {
            this.vuelta = vuelta;
        }
        public void setMaterial(String material)
        {
            this.material = material;
        }
        public void setPdi(Pdi pdi)
        {
            this.pdi = pdi;
        }
        public void setCheck(Boolean check)
        {
            this.check = check;
        }

        public static implicit operator Ruta(List<Ruta> v)
        {
            throw new NotImplementedException();
        }
    }
}
