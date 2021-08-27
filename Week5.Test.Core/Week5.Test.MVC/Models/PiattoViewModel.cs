using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Week5.Test.Core.Models;

namespace Week5.Test.MVC.Models
{
    public class PiattoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]
        public Tipologia Tipologia { get; set; }
        [Required]
        public decimal Prezzo { get; set; }
    }
}
