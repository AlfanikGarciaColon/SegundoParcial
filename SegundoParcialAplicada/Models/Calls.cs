using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcialAplicada.Models
{
    public class Calls
    {
        [Key]
        public int CallId { get; set; }
        [Required(ErrorMessage = "Es obligartorio escribir una Descripcion")]
        public string Descripcion { get; set; }

        [ForeignKey("CallId")]
        public List<CallsDetail> Detalles { get; set; }
        public Calls()
        {
            CallId = 0;
            Descripcion = string.Empty;
            Detalles = new List<CallsDetail>();
        }

    }
   
}
