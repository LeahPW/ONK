using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ONK1.Models
{
    public class Vaerktoejskasse
    {
        public Haandvaerker Haandvaerker { get; set; }
        public DateTime VTKAnskaffet { get; set; }

        [ForeignKey("Haandvaerker")]
        public int VTKEjesAf {get;set;}
        public string VTKfabrikat { get; set; }
        public string VTKFarve { get; set; }
        [Key]
        public int VTKId { get; set; }
        public string VTKModel { get; set; }
        public string VTKSerienummer { get; set; }    

        public List<Vaerktoej> Vaerktoejer { get; set; }
    }
}
