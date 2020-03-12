using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcialAplicada.Models
{
    public class CallsDetail
    {
        [Key]
        public int DetalleId { get; set; }
        public int CallId { get; set; }  
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public CallsDetail()
        {
            DetalleId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
           
        }
    }
}
