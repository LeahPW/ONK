using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONK1.Models
{
    public class Vaerktoej
    {
        public Vaerktoejskasse Vaerktoejskasse { get; set; }

        [ForeignKey("Vaerktoejskasse")]
        public int LiggerIVTK { get; set; }
        public DateTime VTAnskaffet { get; set; }
        public string VTFabrikat { get; set; }
        [Key]
        public int VTId { get; set; }
        public string VTModel { get; set; }
        public string VTSerienummer { get; set; }
        public string VTType { get; set; }
    }
}
