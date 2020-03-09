using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Haandvaerker
    {
        public DateTime HVAnsaettelsesdato { get; set; }
        public string HVEfternavn { get; set; }
        public string HVFagomraade { get; set; }
        public string HVFornavn { get; set; }
        [Key]
        public int HaandvaerkerId { get; set; }

        public List<Vaerktoejskasse> Vaerktoejskasser { get; set; }
    }
}
