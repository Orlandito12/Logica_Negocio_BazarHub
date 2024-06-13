using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SWLNBazarHub.Entidades {
    [DataContract]
    public class EComentariosValoraciones {
        [DataMember]
        public int ComentarioID { get; set; }

        [DataMember]
        public int UsuarioID { get; set; }

        [DataMember]
        public int ProductoID { get; set; }

        [DataMember]
        public string Comentario { get; set; }

        [DataMember]
        public int Valoracion { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        public EComentariosValoraciones() {
            ComentarioID = 0;
            UsuarioID = 0;
            ProductoID = 0;
            Comentario = string.Empty;
            Valoracion = 0;
            Fecha = DateTime.Now;
        }
    }
}