﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONK1.Models
{
    public class Haandvaerker
    {
        public DateTime HVAnsaettelsesdato { get; set; }
        public string HVEfternavn { get; set; }
        public string HVFagomraade { get; set; }
        public string HVFornavn { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HaandvaerkerId { get; set; }

        public List<Vaerktoejskasse> Vaerktoejskasser { get; set; }
    }
}
