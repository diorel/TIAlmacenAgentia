//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlmacenTI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dispositivo_Estatus
    {
        public long Dispositivo_EstatusID { get; set; }
        public int DispostivoID { get; set; }
        public byte EstatusID { get; set; }
        public string Usuario { get; set; }
        public System.DateTime FechaHora { get; set; }
    
        public virtual Dispositivo Dispositivo { get; set; }
        public virtual Estatus Estatus { get; set; }
    }
}
