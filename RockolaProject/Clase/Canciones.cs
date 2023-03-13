using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RockolaProject.Clase
{
    public class Canciones 
    {
        public int? id { get; set; }
        public int? idsong { get; set; }
        public string? artista { get; set; }
        public string? Cancion { get; set; }
        public string? Duracion { get; set; }

        public Canciones(int id, int idsong, string artista, string cancion, string duracion)
        {
            this.id = id;
            this.idsong = idsong;
            this.artista = artista;
            this.Cancion = cancion;
            this.Duracion = duracion;
        }

        public Canciones() { 
            
        }
    }
}
